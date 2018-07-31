namespace Fabulosa.Docs.JavascriptMapping
open Fable.Helpers
open Fable.Helpers.React.Props
open Fabulosa
open System
open Fable.Core.JsInterop
open Fable.Core
open Fable.Import.React
open ReactElementStringExtensions

module Prism =
    importAll "prismjs/prism.js"
    importAll "prismjs/components/prism-clike.js"
    importAll "prismjs/components/prism-fsharp.js"

    [<Emit("Prism.languages.fsharp")>]
    let private prismFsharpLanguage: obj = jsNative
    
    [<Import("highlight", from="prismjs")>] 
    let private highlightCode(element: string, language: obj, languageText: string) = jsNative
    
    let highlight code = { __html = highlightCode(code, prismFsharpLanguage, "fsharp") }
