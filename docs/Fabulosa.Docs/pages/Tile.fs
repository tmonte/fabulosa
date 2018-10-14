module TilePage

open Fabulosa
open Fabulosa.Docs
open Fabulosa.Icon
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Microsoft.FSharp.Core

let contentProps =
    { Tile.Content.props
        with HTMLProps = [ ClassName "tile-p" ] }

(*** define: tile-default-sample ***)
let tile =
    Tile.ƒ
        (Tile.props,
         { Icon = Some
             ({ Tile.TileIcon.props with
                  HTMLProps =
                    [ ClassName "example-tile-icon" ] },
              ([], { Kind = People }))
           Content =
             (contentProps,
                { Title = "The Avengers"
                  SubTitle = "Earth's Mightiest Heroes joined
                    forces to take on threats that were too
                    big for any one hero to tackle..." })
           Action =
             (Tile.Action.props,
              [ Button.ƒ
                  ({ Button.props with
                       Kind = Button.Kind.Primary },
                   [ R.str "Action" ]) ]) })
(*** define: tile-compact-sample ***)
let compact =
    Tile.ƒ
        ({ Tile.props with
             Compact = true },
         { Icon = Some
             ({ Tile.TileIcon.props with
                  HTMLProps =
                    [ ClassName "example-tile-icon" ] },
              ([], { Kind = Mail }))
           Content =
             (contentProps,
                { Title = "fabulosa-docs.pdf"
                  SubTitle = "14MB · Public · 1 Jan, 2017" })
           Action =
             (Tile.Action.props,
              [ icon ([], { Kind = MoreHoriz }) ]) })
(*** hide ***)
let render () =
    tryMount "tile-default-demo" tile
    tryMount "tile-compact-demo" compact
    tryMount "tile-props-table"
        (PropTable.propTable typeof<Tile.Props> Tile.props)
(**

<div id="tile">

<h2 class="s-title">
    Tile
</h2>

Tiles are repeatable or embeddable information blocks

</div>

<div id="tile-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="tile-props-table"></div>

</div>

<div id="tile-default">

<h3 class="s-title">
    Default
</h3>

A simple tile component with an icon,
content and action

<div class="demo" id="tile-default-demo"></div>

*)

(*** include: tile-default-sample ***)

(**

</div>

<div id="tile-compact">

<h3 class="s-title">
    Compact
</h3>

A compact tile

<div class="demo" id="tile-compact-demo"></div>

*)

(*** include: tile-compact-sample ***)

(**

</div>

*)