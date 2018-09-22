module ChipPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Fable.Import.JS
open Microsoft.FSharp.Core

(*** define: chip-default-sample ***)
let chip =
    Chip.ƒ
        (Chip.props,
         { Chip.children with Text = "Chip" })
(*** define: chip-removable-sample ***)
let fn _ = console.log "removed"

let removable =
    Chip.ƒ
        ({ Chip.props with
             OnRemove = Some fn },
         { Chip.children with Text = "Chip" })
(*** define: chip-avatar-sample ***)
let avatar =
    Chip.ƒ
        (Chip.props,
         { Chip.children with
             Text = "Chip"
             Avatar = Some
               { Avatar.defaults with
                   Source = "assets/avatar-1.png" } })
(*** hide ***)
let render () =
    tryMount "chip-default-demo" chip
    tryMount "chip-removable-demo" removable
    tryMount "chip-avatar-demo" avatar
    tryMount "chip-props-table" (PropTable.propTable typeof<Chip.Props> Chip.props)
(**

<div id="chips">

<h2 class="s-title">
    Chips
</h2>

Chips are complex entities in small blocks.

</div>

<div id="chip-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="chip-props-table"></div>

</div>

<div id="chip-default">

<h3 class="s-title">
    Default
</h3>

The default chip.

<div class="demo" id="chip-default-demo"></div>

*)

(*** include: chip-default-sample ***)

(**

</div>

<div id="chip-removable">

<h3 class="s-title">
    Removable
</h3>

Chips can include a remove button and action.

<div class="demo" id="chip-removable-demo"></div>

*)

(*** include: chip-removable-sample ***)

(**

</div>

<div id="chip-avatar">

<h3 class="s-title">
    Avatar
</h3>

Chips can also include an avatar.
The avatar size is always set to small.

<div class="demo" id="chip-avatar-demo"></div>

*)

(*** include: chip-avatar-sample ***)

(**

</div>

*)