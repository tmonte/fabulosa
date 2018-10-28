module PageNavPage

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
      [ Prev ([],
          (Title "Page 1",
           Subtitle "Previous",
           Link ""))
        Next ([],
          (Title "Page 3",
           Subtitle "Next",
           Link "")) ])
(*** hide ***)
let render () =
    tryMount "pagenav-default-demo" def
    //tryMount "pagenav-props-table"
        //(PropTable.propTable typeof<PageNav.Props> PageNav.props)
(**

<div id="pagenav">

<h2 class="s-title">
    Page Nav
</h2>

The page nav component is used for navigation with
previous and next pages only. 

</div>

<div id="pagenav-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="pagenav-props-table"></div>

</div>

<div id="pagenav-default">

<h3 class="s-title">
    Default
</h3>

A simple pagenav component with a previous and
next page.

<div class="demo" id="pagenav-default-demo"></div>

*)

(*** include: pagenav-default-sample ***)

(**

</div>

*)