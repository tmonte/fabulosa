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
    type HighlightResult = 
        {
            language: string
            relevance: int
            value: string
        }

    [<Emit("hljs")>]
    let private highlighJs: obj = jsNative
    
    [<Import("highlight", from="highlight.js")>] 
    let private highlightCode(name: string, value: string, ignoreIllegals):HighlightResult = jsNative
    
    let highlight language code = { __html = highlightCode(language, code, true).value }
    
    let fsharp = highlight "fsharp"
    let html = highlight "html"
    