module CardPage

open Fabulosa
open Fabulosa.Grid
open Fabulosa.Card
open Fabulosa.Button
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: card-default-sample ***)
let def =
    card ([],
      [ Header ([], (Title "Apple", SubTitle "Hardware and software"))
        Image ([P.Src "Assets/macos-sierra-2.jpg"])
        Body ([],
          [ R.p [] [ R.str "To make a contribution to
              the world by making tools for the mind
              that advance humankind." ] ])
        Footer ([], [ button ([], [ R.str "Purchase" ]) ]) ])
(*** hide ***)
let demo =
    grid ([],
        [ Row ([],
            [ Column ([ SMSize 12; Size 6 ], [ def ]) ]) ])
let render () =
    tryMount "card-default-demo" demo
    tryMount "card-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<CardChild>))
(**

<div id="cards">

<h2 class="s-title">
    Cards
</h2>

Cards are flexible content containers.

<div id="card-params">

<h3 class="s-title">
    Parameters
</h3>

<div class="props-table" id="card-params-table"></div>

</div>

</div>

<div id="card-default">

<h3 class="s-title">
    Default
</h3>

The default card

<div class="demo" id="card-default-demo"></div>

*)

(*** include: card-default-sample ***)

(**

</div>

*)