module EmptyPage

open Fabulosa.Empty
open Fabulosa.Icon
open Fabulosa.Button
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: empty-default-sample ***)
let def =
    empty
        ([],
         (Icon ([], IconRequired.Kind Mail),
          Title "You have no new messages",
          Subtitle "Click the button to start a conversation",
          Action [ button ([], [ R.str "Send a message" ]) ] ))
(*** hide ***)
let render () =
    tryMount "empty-default-demo" def
    //tryMount "empty-props-table"
        //(PropTable.unionPropTable typeof<EmptyChildren>)
(**

<div id="empty">

<h2 class="s-title">
    Empty states
</h2>

Empty states/blank slates are commonly used
as placeholders for first time use, empty
data and error screens.

</div>

<div id="empty-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="empty-props-table"></div>

</div>

<div id="empty-default">

<h3 class="s-title">
    Default
</h3>

The empty state component. The icon is size
is always 3x bigger. Actions can be any
combination of React Elements.

<div class="demo" id="empty-default-demo"></div>

*)

(*** include: empty-default-sample ***)

(**

</div>

*)