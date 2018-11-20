(*** hide ***)
module TilePage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa.Docs
open Fabulosa.Tile
open Fabulosa.Button
open Fabulosa.Icon
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: tile-default-sample ***)
let def =
    tile ([Icon ([], Kind People)],
      (Content ([],
         (Title "The Avengers",
          Subtitle
            "Earth's Mightiest Heroes joined
             forces to take on threats that were too
             big for any one hero to tackle...")),
       Action ([],
         [ button
             ([ ButtonOptional.Kind Primary ],
              [ R.str "Action" ]) ]) ))
(*** define: tile-compact-sample ***)
let compact =
    tile([ Compact; Icon ([], Kind Mail) ],
      (Content ([],
         (Title "fabulosa-docs.pdf",
          Subtitle "14MB · Public · 1 Jan, 2017")),
       Action ([],
         [ icon ([], Kind MoreHoriz) ]) ))
(*** hide ***)
let render () =
    tryMount "tile-default-demo" def
    tryMount "tile-compact-demo" compact
    tryMount "tile-params-table"
        (PropTable.paramTable
            (Some typeof<TileOptional>)
            None
            (Some typeof<TileChildren>))
(**

<div id="tile">

<h2 class="s-title">Tile</h2>

Tiles are repeatable or embeddable information blocks.

#### Parameters

<div class="props-table" id="tile-params-table"></div>

#### Example

A simple tile component with an icon,
content and action.

<div class="demo" id="tile-default-demo"></div>

*)
(*** include: tile-default-sample ***)
(**

#### Compact

A compact tile.

<div class="demo" id="tile-compact-demo"></div>

*)
(*** include: tile-compact-sample ***)
(**

</div>

*)