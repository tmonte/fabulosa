module PopoverPage

open Fabulosa.Popover
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

(*** define: popover-default-sample ***)
let def =
    popover ([ Position Right ],
        (Trigger [ button ([], [ R.str "Popover" ]) ],
         Content [ CardPage.def ]))
(*** hide ***)
let render () =
    tryMount "popover-default-demo" def
    //tryMount "popover-props-table"
        //(PropTable.propTable typeof<Popover.Props> Popover.props)
(**

<div id="popover">

<h2 class="s-title">
    Popover
</h2>

Popovers are small overlay content containers

</div>

<div id="popover-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="popover-props-table"></div>

</div>

<div id="popover-default">

<h3 class="s-title">
    Default
</h3>

A simple popover component that pops up

<div class="demo" id="popover-default-demo"></div>

*)

(*** include: popover-default-sample ***)

(**

</div>

*)