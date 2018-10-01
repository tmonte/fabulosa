module ModalPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: modal-sample ***)
let modal = 
    Modal.f (Modal.defaults, Modal.children)

(*** hide ***)
let demo = R.div [Style [MaxWidth "50%"]] [modal]

let render () =
    tryMount "modal-demo" demo
    tryMount "modal-props-table" (PropTable.propTable typeof<Modal.Props> Modal.defaults)
(**

<div id="modal">
    <h2 class="s-title">Cards</h2>
    Cards are flexible content containers.
</div>

<div id="modal-props">
    <h3 class="s-title">Props</h3>
    <div class="props-table" id="modal-props-table"></div>
</div>

<div id="modal-default">
    <h3 class="s-title">Default</h3>
    The default modal
    <div class="demo" id="modal-demo"></div>
</div>
*)

(*** include: modal-sample ***)

