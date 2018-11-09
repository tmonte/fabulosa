module ResponsivePage

open Fabulosa.Responsive
open Fabulosa.Docs
open Fabulosa.Button
module R = Fable.Helpers.React
open R.Props
open Renderer

(*** define: responsive-sample ***)
let hideSmall =
    responsive
        ([ Hide SM ], [ button ([], [ R.str "Hide small" ]) ])

let showLarge =
    responsive
        ([ Show LG ], [ button ([], [ R.str "Show large" ]) ])
(*** hide ***)
let render () =
    tryMount "responsive-demo-hide" hideSmall
    tryMount "responsive-demo-show" showLarge
    tryMount "responsive-params-table"
        (PropTable.paramTable
            (Some typeof<ResponsiveOptional>)
            None
            None)
(**

<div id="responsive">

<h2 class="s-title">Responsive</h2>

Spectre provides a neat responsive
layout grid system and responsive
visibility utilities.

#### Parameters

<div class="props-table" id="responsive-params-table"></div>

#### Hide and Show

Show or hide elements based
on the viewport size

<div class="demo" style="display:flex">
    <span id="responsive-demo-hide"></span>
    &nbsp;
    <span id="responsive-demo-show"></span>
</div>

*)
(*** include: responsive-sample ***)
(**

</div>

*)