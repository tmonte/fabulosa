#load ".fake/build.fsx/intellisense.fsx"


open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let run (cmd:string) dir args  =
    if Process.execSimple (fun info ->
        { info with
            FileName = cmd
            WorkingDirectory =
                if not (String.isNullOrWhiteSpace dir) then dir else info.WorkingDirectory
            Arguments = args
        }
    ) System.TimeSpan.MaxValue <> 0 then
        failwithf "Error while running '%s' with args: %s " cmd args

let npm = run "npm" "./"

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "docs/**/bin"
    ++ "docs/**/obj"
    ++ "tests/**/bin"
    ++ "tests/**/obj"
    ++ "build"
    |> Shell.cleanDirs 
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "BuildDocs" (fun _ ->
    !! "docs/**/*.*.proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "NPMBuildDocs" (fun _ ->
    npm "install"
    npm "run build"
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

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "BuildDocs"
  ==> "NPMBuildDocs"
  ==> "BuildTests"
  ==> "Test"
  ==> "All"

Target.runOrDefault "All"
