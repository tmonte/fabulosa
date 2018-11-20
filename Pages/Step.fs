module StepPage

open Fabulosa
open Fabulosa.Step
open Fabulosa.Docs
module R = Fable.Helpers.React
open Fable.Import.React
open Renderer

(*** define: step-default-sample ***)
let def =
    step ([],
      [ Item ([], [ R.str "Step 1" ])
        Item ([ Active ], [ R.str "Step 2" ])
        Item ([], [ R.str "Step 3" ]) ])
(*** hide ***)
let render () =
    tryMount "step-default-demo" def
    tryMount "step-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<StepChild>))
(**

<div id="step">

<h2 class="s-title">Step</h2>

Steps are progress indicators of a
sequence of task steps

#### Parameters

<div class="props-table" id="step-params-table"></div>

#### Example

A simple step component with three steps
and an active step

<div class="demo" id="step-default-demo"></div>

*)
(*** include: step-default-sample ***)
(**

</div>

*)