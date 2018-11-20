module TabPage

open Fabulosa
open Fabulosa.Badge
open Fabulosa.Tab
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

(*** define: tab-default-sample ***)
let def =
    tab ([],
      [ Item ([], [ R.a [] [ R.str "Tab 1" ] ])
        Item ([ Active ], [ R.a [] [ R.str "Tab 2" ] ])
        Item ([],
          [ badge ([], Value 1, Anchor ([], [ R.str "Tab 3" ])) ]) ])
(*** hide ***)
let render () =
    tryMount "tab-default-demo" def
    tryMount "tab-params-table"
        (PropTable.paramTable
            (Some typeof<TabOptional>)
            None
            (Some typeof<TabChild>))
(**

<div id="tab">

<h2 class="s-title">Tab</h2>

Tabs enable quick switch between different views

#### Parameters

<div class="props-table" id="tab-params-table"></div>

#### Example

A simple tab component

<div class="demo" id="tab-default-demo"></div>

*)
(*** include: tab-default-sample ***)
(**

</div>

*)