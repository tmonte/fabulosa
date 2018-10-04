module TileTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect


[<Tests>]
let tests =
    testList "Tile tests" [

        //test "Tile default" {
        //   Tile.ƒ
        //       (Tile.props, Tile.children)
        //    |> ReactNode.unit
        //    |> hasUniqueClass "tile"
        //}

        //test "Tile html props" {
        //    Tile.ƒ
        //        ({ Tile.props with
        //             HTMLProps =
        //               [ ClassName "custom" ] },
        //         Tile.children)
        //    |> ReactNode.unit
        //    |> hasClass "custom"
        //}

        //test "Tile centered" {
        //   Tile.ƒ
        //       ({ Tile.props with
        //            Compact = true },
        //        Tile.children)
        //    |> ReactNode.unit
        //    |> hasClass "tile-centered"
        //}

        //test "Tile icon" {
        //    let tileIcon =
        //        (Tile.TileIcon.props, Icon.props)

        //    Tile.ƒ
        //        (Tile.props,
        //         { Tile.children with
        //             Icon = Some tileIcon })
        //    |> ReactNode.unit
        //    |> hasChild 1 (Tile.TileIcon.ƒ tileIcon |> ReactNode.unit)

        //    Tile.TileIcon.ƒ tileIcon
        //    |> ReactNode.unit
        //    |> hasUniqueClass "tile-icon"
        //}

        //test "Tile content" {
        //    let content =
        //        (Tile.Content.props, [ R.str "Content" ])

        //    Tile.ƒ
        //        (Tile.props,
        //         { Tile.children with
        //             Content = content })
        //    |> ReactNode.unit
        //    |> hasChild 1 (Tile.Content.ƒ content |> ReactNode.unit)

        //    Tile.Content.ƒ content
        //    |> ReactNode.unit
        //    |> hasUniqueClass "tile-content"
        //}

        //test "Tile action" {
        //    let button =
        //        Button.ƒ
        //            (Button.props,
        //             [ R.str "Button" ])
        //    Tile.ƒ
        //        ({ Tile.props with
        //             Action = Some [ button ] },
        //         [])
        //    |> ReactNode.unit
        //    |>! hasDescendentClass "tile-item tile-action"
        //    |> hasChild 1 (button |> ReactNode.unit)
        //}

        //test "Tile children" {
        //    let item =
        //        (Tile.Item.props,
        //         [ R.a [] [ R.str "Tile" ] ])
        //    Tile.ƒ
        //        (Tile.props, [ item ])
        //    |> ReactNode.unit
        //    |> hasChild 1 (Tile.Item.ƒ item |> ReactNode.unit)
        //}

        //test "Tile item defaults" {
        //    let child = R.a [] [ R.str "Tile" ]
        //    Tile.Item.ƒ
        //        (Tile.Item.props, [ child ])
        //    |> ReactNode.unit
        //    |> hasChild 1 (child |> ReactNode.unit)
        //}

        //test "Tile item active" {
        //    Tile.Item.ƒ
        //        ({ Tile.Item.props with
        //             Active = true }, [])
        //    |> ReactNode.unit
        //    |> hasClass "active"
        //}
        
    ]