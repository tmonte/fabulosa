(*** hide ***)
module PageNavPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa.PageNav
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Fable.Import.JS
open Renderer
open Microsoft.FSharp.Core

(*** define: pagenav-default-sample ***)
let def =
    pageNav ([],
      (Prev
         (Some ([],
            (Title "Page 1",
             Subtitle "Previous",
             Link ""))),
       Next
         (Some([],
            (Title "Page 3",
             Subtitle "Next",
             Link "")))))
(*** hide ***)
let render () =
    tryMount "pagenav-default-demo" def
    tryMount "pagenav-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<PageNavChildren>))
    tryMount "pagenav-item-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<PageNavItemChildren>))
(**

<div id="pagenav">

<h2 class="s-title">Page Nav</h2>

The page nav component is used for navigation with
previous and next pages only. 

#### Parameters

<div class="props-table" id="pagenav-params-table"></div>

#### Item Parameters

<div class="props-table" id="pagenav-item-params-table"></div>

#### Example

A simple pagenav component with a previous and
next page.

<div class="demo" id="pagenav-default-demo"></div>

*)
(*** include: pagenav-default-sample ***)
(**

</div>

*)