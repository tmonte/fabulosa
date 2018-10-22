module IndexPage

open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: sample ***)
let fabulous =
    anchor
        ([ Kind Primary
           P.Href "button.html" ],
         [ R.str "Fabulosa" ])
(*** hide ***)
let render () =
    tryMount "button-demo" fabulous
(**
<h2 class="s-title">
    Getting Started
</h2>

Create a fabulous button

*)

(*** include: sample ***)

(**
<div class="demo" id="button-demo">
</div>
*)
