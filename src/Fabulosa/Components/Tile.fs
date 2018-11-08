namespace Fabulosa

module Tile =

    open Fabulosa.Extensions
    open Fabulosa.Icon
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type TileContentTitle =
        Title of string

    type TileContentSubtitle =
        Subtitle of string

    type private TileContentChildren =
        TileContentTitle * TileContentSubtitle

    type private TileContent =
        HTMLProps * TileContentChildren

    let tileContent (comp: TileContent) =
        let opt, (Title ttl, Subtitle sttl) = comp
        Unmerged opt
        |> addProp (ClassName "tile-content")
        |> merge
        |> R.div
        <| [ R.p
               [ ClassName "tile-title" ]
               [ R.str ttl ]
             R.p
               [ ClassName "tile-subtitle text-gray" ]
               [ R.str sttl ] ]

    type private TileAction =
        HTMLProps * ReactElement list

    let tileAction (comp: TileAction) =
        let opt, chi = comp
        Unmerged opt
        |> addProp (ClassName "tile-action")
        |> merge
        |> R.div <| chi

    type TileOptional =
        | Compact
        | Icon of Icon
        interface IHTMLProp

    type Content =
        Content of TileContent

    type Action =
        Action of TileAction

    type TileChildren =
        Content * Action

    type private Tile =
        HTMLProps * TileChildren

    let private compact (prop: IHTMLProp) =
        match prop with
        | :? TileOptional as opt ->
            match opt with
            | Compact -> className "tile-centered"
            | _ -> prop
        | _ -> prop

    let private tileIcon (props: HTMLProps) =
        props
        |> List.tryPick
            (function
            | :? TileOptional as opt ->
                match opt with
                | Icon icn ->
                    Some (R.div [ ClassName "tile-icon example-tile-icon" ] [ icon icn ])
                | _ -> None
            | _ -> None)
        |> R.ofOption

    let tile (comp: Tile) =
        let opt, (Content con, Action act) = comp
        Unmerged opt
        |> addProp (ClassName "tile")
        |> map compact
        |> merge
        |> R.div
        <| [ tileIcon opt
             tileContent con
             tileAction act ]
