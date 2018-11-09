module EmptyPage

open Fabulosa.Empty
open Fabulosa.Button
open Fabulosa.Icon
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: empty-default-sample ***)
let def =
    empty
        ([],
         [ Icon ([], Kind Mail)
           Title "You have no new messages"
           Subtitle "Click the button to start a conversation"
           Action [ button ([], [ R.str "Send a message" ]) ] ])
(*** hide ***)
let render () =
    tryMount "empty-default-demo" def
    tryMount "empty-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<EmptyChild>))
(**

<div id="empty">

<h2 class="s-title">Empty states</h2>

Empty states/blank states are commonly used
as placeholders for first time use, empty
data and error screens.

#### Parameters

<div class="props-table" id="empty-params-table"></div>

#### Example

The empty state component.
The icon inside the empty state is always
3x bigger. Actions can be any combination of React Elements.

<div class="demo" id="empty-default-demo"></div>

*)
(*** include: empty-default-sample ***)
(**

</div>

*)