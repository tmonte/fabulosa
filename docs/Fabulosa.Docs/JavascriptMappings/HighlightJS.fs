namespace Fabulosa.Docs.JavascriptMapping
open Fable.Helpers
open Fable.Helpers.React.Props
open Fabulosa
open System
open Fable.Core.JsInterop
open Fable.Core
open Fable.Import.React
open ReactElementStringExtensions

module Highlight =
    importAll "highlight.js/lib/highlight.js"
//    importAll "prismjs/components/prism-clike.js"
//    importAll "prismjs/components/prism-fsharp.js"


    type HighlightResult = 
        {
            language: string
            relevance: int
            value: string
        }

    [<Emit("hljs")>]
    let private highlighJs: obj = jsNative
    
    [<Import("highlight", from="highlight.js")>] 
    let private highlightCode(name, value, ignoreIllegals):HighlightResult = jsNative
    
    let highlight code = { __html = highlightCode("fsharp", code, true).value }
