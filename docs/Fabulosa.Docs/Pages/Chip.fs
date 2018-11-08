module ChipPage

open Fabulosa
open Fabulosa.Chip
open Fabulosa.Docs
open Fabulosa.Avatar
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Fable.Import.JS
open Microsoft.FSharp.Core

(*** define: chip-default-sample ***)
let def = chip ([], Text "Chip")
(*** define: chip-removable-sample ***)
let fn _ = console.log "removed"

let removable = chip ([ OnRemove fn ], Text "Chip")
(*** define: chip-avatar-sample ***)
let avatar = chip ([ Avatar (Url "Assets/avatar-1.png") ], Text "Chip")
(*** hide ***)
let render () =
    tryMount "chip-default-demo" def
    tryMount "chip-removable-demo" removable
    tryMount "chip-avatar-demo" avatar
    tryMount "chip-params"
        (PropTable.paramTable
            (Some typeof<ChipOptional>)
            None
            (Some typeof<FabulosaText>))
(**

<div id="chips">

<h2 class="s-title">
    Chips
</h2>

Chips are complex entities in small blocks.

</div>

<div id="chip-params">

<h3 class="s-title">
    Parameters
</h3>

<div class="props-table" id="chip-params-table"></div>

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