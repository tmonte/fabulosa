module CardPage

open Fabulosa
open Fabulosa.Card
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: card-default-sample ***)
let def =
    card ([],
      (Image ([P.Src "assets/macos-sierra-2.jpg"]),
       Header ([], (Title "Apple", SubTitle "Hardware and software")),
       Body ([],
         [ R.p [] [ R.str "To make a contribution to
             the world by making tools for the mind
             that advance humankind." ] ]),
       Footer ([], [ button ([], [ R.str "Purchase" ]) ]) ))
(*** hide ***)
let demo = R.div [ P.Style [ P.MaxWidth "50%" ] ] [ def ]
let render () =
    tryMount "card-default-demo" demo
(**

<div id="cards">

<h2 class="s-title">
    Cards
</h2>

Cards are flexible content containers.

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