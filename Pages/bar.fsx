(*** hide ***)
module BarPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa
open Fabulosa.Bar
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: bar-default-sample ***)
let def = bar ([], [ Item ([], Value 25) ])
(*** define: bar-small-sample ***)
let small = bar ([ Small ], [ Item ([], Value 25) ])
(*** define: bar-item-tooltip-sample ***)
let tooltip = bar ([], [ Item ([ Tooltip ], Value 25) ])
(*** define: bar-item-multiple-sample ***)
let multiple =
    bar ([],
        [ Item ([], Value 25)
          Item ([], Value 15)
          Item ([], Value 5) ])
(*** hide ***)
let render () =
    tryMount "bar-default-demo" def
    tryMount "bar-small-demo" small
    tryMount "bar-item-tooltip-demo" tooltip
    tryMount "bar-item-multiple-demo" multiple
    tryMount "bar-params-table"
        (PropTable.paramTable
            (Some typeof<BarOptional>)
            None
            (Some typeof<BarChild>))
    tryMount "bar-item-params-table"
        (PropTable.paramTable
            (Some typeof<BarItemOptional>)
            (Some typeof<FabulosaValue>)
            None)
(**

<div id="bars">

<h2 class="s-title">Bars</h2>

Bars represent the progress of a task or the
value within the known range. Bars are custom
components for displaying HTML5 progress, meter
and input range elements.

#### Parameters

<div class="props-table" id="bar-params-table"></div>

#### Item Parameters

<div class="props-table" id="bar-item-params-table"></div>

#### Example

A bar with default settings.

<div class="demo" id="bar-default-demo"></div>

*)
(*** include: bar-default-sample ***)
(**

#### Small

A small version of the bar

<div class="demo" id="bar-small-demo"></div>

*)
(*** include: bar-small-sample ***)
(**

#### Tooltips

Bar items can have tooltips

<div class="demo" id="bar-item-tooltip-demo"></div>

*)
(*** include: bar-item-tooltip-sample ***)
(**

#### Multiple items

Bar can also have multiple items

<div class="demo" id="bar-item-multiple-demo"></div>

*)
(*** include: bar-item-multiple-sample ***)
(**

</div>

*)