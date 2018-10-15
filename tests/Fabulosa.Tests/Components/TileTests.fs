module TileTests

open Expecto
open Fabulosa
open Fabulosa.Icon
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect


[<Tests>]
let tests =
    testList "Tile tests" [

        test "Tile default" {
           Tile.ƒ
               (Tile.props, Tile.children)
            |> ReactNode.unit
            |> hasUniqueClass "tile"
        }

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

        test "Tile icon" {
            let tileIcon =
                (Tile.TileIcon.props, ([], { Kind = Download }))

            Tile.ƒ
                (Tile.props,
                 { Tile.children with
                     Icon = Some tileIcon })
            |> ReactNode.unit
            |> hasChild 1 (Tile.TileIcon.ƒ tileIcon |> ReactNode.unit)

            Tile.TileIcon.ƒ tileIcon
            |> ReactNode.unit
            |> hasUniqueClass "tile-icon"
        }

        test "Tile content" {
            let content: Tile.Content.T =
                (Tile.Content.props,
                 { Title = "Title"
                   SubTitle = "SubTitle" })

            Tile.ƒ
                (Tile.props,
                 { Tile.children with
                     Content = content })
            |> ReactNode.unit
            |> hasChild 1 (Tile.Content.ƒ content |> ReactNode.unit)

            Tile.Content.ƒ content
            |> ReactNode.unit
            |>! hasUniqueClass "tile-content"
            |> hasOrderedDescendentClass 1 "tile-title tile-subtitle text-gray"
        }

        test "Tile action" {
            let child =
                button
                    ([],
                     [ R.str "Button" ])
            let action: Tile.Action.T =
                (Tile.Action.props,
                 [ child ])

            Tile.ƒ
                (Tile.props,
                 { Tile.children with
                     Action = action })
            |> ReactNode.unit
            |> hasChild 1 (Tile.Action.ƒ action |> ReactNode.unit)

            Tile.Action.ƒ action
            |> ReactNode.unit
            |>! hasUniqueClass "tile-action"
            |> hasChild 1 (child |> ReactNode.unit)
        }
        
    ]