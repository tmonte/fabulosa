module CardPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: card-default-sample ***)
let card =
    Card.ƒ
        Card.defaults
        { Header =
            [ R.h2 [] [ R.str "Title" ]
              R.p [] [ R.str "Sub title" ] ]
          Body =
            [ R.p [] [ R.str "A body text" ] ]
          Footer =
            [ Button.ƒ Button.defaults [ R.str "Action" ] ]
          Image = Media.Image.defaults }

(*** hide ***)
let render () =
    tryMount "card-default-demo" card
    tryMount "card-props-table" (PropTable.propTable typeof<Card.Props> Card.defaults)
(**

<div id="cards">

<h2 class="s-title">
    Cards
</h2>

Cards are flexible content containers.

</div>

<div id="card-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="card-props-table"></div>

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