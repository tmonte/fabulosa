(*** hide ***)
module ChipPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


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
    tryMount "chip-params-table"
        (PropTable.paramTable
            (Some typeof<ChipOptional>)
            None
            (Some typeof<FabulosaText>))
(**

<div id="chips">

<h2 class="s-title">Chips</h2>

Chips are complex entities in small blocks.

#### Parameters

<div class="props-table" id="chip-params-table"></div>

#### Example

A simple chip with some text.

<div class="demo" id="chip-default-demo"></div>

*)
(*** include: chip-default-sample ***)
(**

#### Removable

A removable chip.

<div class="demo" id="chip-removable-demo"></div>

*)
(*** include: chip-removable-sample ***)
(**

#### Avatar

Chips can also include an avatar.
The avatar size when inside the chip is always set to small.

<div class="demo" id="chip-avatar-demo"></div>

*)
(*** include: chip-avatar-sample ***)
(**

</div>

*)