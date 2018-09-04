#r "paket: groupref netcorebuild //"
#load @".fake/build.fsx/intellisense.fsx"
#if !FAKE
#r "Facades/netstandard"
#r "netstandard"
#endif

#nowarn "52"

open System
open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.Tools.Git
open Fake.JavaScript
open Fake.DotNet
open System.IO
open Fake.DotNet.FSFormatting

let runFable args =
    let result =
        DotNet.exec
            (DotNet.Options.withWorkingDirectory __SOURCE_DIRECTORY__)
            "fable" args
    if not result.OK then
        failwithf "dotnet fable failed with code %i" result.ExitCode

let rec deleteFiles srcPath pattern includeSubDirs =
    
    if not <| System.IO.Directory.Exists(srcPath) then
        let msg = System.String.Format("Source directory does not exist or could not be found: {0}", srcPath)
        raise (System.IO.DirectoryNotFoundException(msg))

    for file in System.IO.Directory.EnumerateFiles(srcPath, pattern) do
        let tempPath = System.IO.Path.Combine(srcPath, file)
        System.IO.File.Delete(tempPath)

    if includeSubDirs then
        let srcDir = new System.IO.DirectoryInfo(srcPath)
        for subdir in srcDir.GetDirectories() do
            deleteFiles subdir.FullName pattern includeSubDirs

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "docs/**/bin"
    ++ "docs/**/obj"
    ++ "tests/**/bin"
    ++ "tests/**/obj"
    ++ "obj"
    ++ "bin"
    ++ "output"
    |> Shell.cleanDirs
    let docs = Path.Combine(__SOURCE_DIRECTORY__, "docs/Fabulosa.Docs");
    deleteFiles (Path.Combine(docs, "pages")) "*.fsx" false
    deleteFiles docs "*.html" false
)

Target.create "DotnetRestore" (fun _ ->
    DotNet.restore
        (DotNet.Options.withWorkingDirectory __SOURCE_DIRECTORY__)
        "Fabulosa.sln"
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

let generateDocs file =
    let pattern =
        match file with
        | Some name -> name
        | None -> "*.fs"
    let source = __SOURCE_DIRECTORY__
    let docs = Path.Combine(source, "docs/Fabulosa.Docs")
    let pages = Path.Combine(docs, "pages")
    let hide = "(*** hide ***)\n"
    let scriptImports = """
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"
"""
    let files = Directory.EnumerateFiles(pages, pattern, SearchOption.TopDirectoryOnly)
    Seq.iter (fun file ->
        let moduleName = File.readLine file
        let demo = File.ReadAllText(file).Replace(moduleName, "");
        let fileName = Path.GetFileName(file) |> String.toLower;
        File.WriteAllText(pages + "/" + fileName + "x", hide + moduleName + scriptImports + demo)
    ) files
    try 
        FSFormatting.createDocs(fun _ -> {
            FSFormatting.defaultLiterateArguments with
                Source = Path.Combine(docs, "pages")
                Template = Path.Combine(docs, "assets/template.html")
                OutputDirectory = docs
                LayoutRoots = [docs]
                ProjectParameters = [("", "")]
        })
    with |x -> printfn "%A" x
    printfn "<<<< Successfully generated docs >>>>"

Target.create "GenerateDocPages" (fun _ ->
    generateDocs None
)

Target.create "BuildDocs" (fun _ ->
    runFable "webpack-cli"
)

Target.create "YarnInstall" (fun _ ->
    Yarn.install id
)

Target.create "Watch" (fun _ ->
    //runFable "webpack-dev-server"
    let pages = Path.Combine(__SOURCE_DIRECTORY__, "docs/Fabulosa.Docs/pages")
    let changes (changed: FileChange seq) =
        let status =
            if Environment.isMacOS
            then FileStatus.Created
            else FileStatus.Changed
        let created =
            Seq.tryFind
                (fun file -> file.Status = status)
                changed
        match created with
        | Some file -> generateDocs (Some file.Name)
        | None -> ()
    use watcher =
        !! (pages + "/*.fs")
        |> ChangeWatcher.run changes
    printfn "<<<< Start watch >>>>"
    runFable "webpack-dev-server"
)

Target.create "BuildTests" (fun _ ->
    !! "tests/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)
let opts (def:DotNet.Options) = def

Target.create "Test" (fun _ ->
    !! "tests/**/*.*proj"
    |> Seq.iter (fun proj -> DotNet.exec opts ("run --project " + proj) "" |> ignore)
)

// Where to push generated documentation
let githubLink = "git@github.com:tmonte/fabulosa.git"
let publishBranch = "gh-pages"
let fableRoot   = __SOURCE_DIRECTORY__
let temp        = fableRoot </> "temp"
let docsOuput = fableRoot </> "output"

// --------------------------------------------------------------------------------------
// Release Scripts
Target.create "PublishDocs" (fun _ ->
    Shell.cleanDir temp
    Repository.cloneSingleBranch "" githubLink publishBranch temp

    Shell.copyRecursive docsOuput temp true |> Trace.logfn "%A"
    Staging.stageAll temp
    Commit.exec temp (sprintf "Update site (%s)" (DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
    Branches.push temp
)

// // Build order
"Clean"
    ==> "DotnetRestore"
    ==> "Build"
    ==> "YarnInstall"
    ==> "GenerateDocPages"
    ==> "BuildTests"
    ==> "Test"
    ==> "BuildDocs"

"GenerateDocPages"
    ==> "Watch"

"Build"
    ==> "Test"
    ==> "PublishDocs"

// start build
Target.runOrDefault "BuildDocs"