module StepStep

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

(*** define: step-default-sample ***)
let step =
    Step.ƒ
        (Step.props,
         [ (Step.Item.props,
            [ R.str "Step 1" ])
           ({ Step.Item.props with
                Active = true },
            [ R.str "Step 2" ])
           (Step.Item.props,
            [ R.str "Step 3" ]) ])
(*** hide ***)
let render () =
    tryMount "step-default-demo" step
    tryMount "step-props-table"
        (PropTable.propTable typeof<Step.Props> Step.props)
    tryMount "step-item-props-table"
        (PropTable.propTable typeof<Step.Item.Props> Step.Item.props)
(**

<div id="step">

<h2 class="s-title">
    Step
</h2>

Steps are progress indicators of a
sequence of task steps

</div>

<div id="step-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="step-props-table"></div>

</div>

<div id="step-default">

<h3 class="s-title">
    Default
</h3>

A simple step component with three steps
and an active step

<div class="demo" id="step-default-demo"></div>

*)

(*** include: step-default-sample ***)

(**

</div>

<div id="step-item">

<h2 class="s-title">
    Step Item
</h2>

Step items are child elements for steps

</div>

<div id="step-item-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="step-item-props-table"></div>

</div>

*)