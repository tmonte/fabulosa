module TileTests

open Expecto
open Fabulosa.Tile
open Fabulosa.Icon
module R = Fable.Helpers.React
module P = R.Props
open Expect


[<Tests>] 
let tests =
    testList "Tile tests" [

        test "Tile default" {
            let child = R.div [P.ClassName "child"] []
            tile ([],
              (Content ([],
                 (Title "Title",
                  Subtitle "Subtitle")),
               Action ([], [child])))
            |> ReactNode.unit
            |>! hasUniqueClass "tile"
            |>! hasText "Title Subtitle"
            |>! hasOrderedDescendentClass 1 "tile-content tile-title tile-subtitle text-gray tile-action child"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        //test "Tile html props" {
        //    tile
        //        ({ [] with
        //             HTMLProps =
        //               [ ClassName "custom" ] },
        //         Tile.children)
        //    |> ReactNode.unit
        //    |> hasClass "custom"
        //}

        //test "Tile centered" {
        //   tile
        //       ({ [] with
        //            Compact = true },
        //        Tile.children)
        //    |> ReactNode.unit
        //    |> hasClass "tile-centered"
        //}

        test "Tile icon" {
            let icn = ([], Kind Download)
            tile ([ Icon icn ],
              (Content ([],
                 (Title "Title",
                  Subtitle "SubTitle")),
               Action ([], [])))
            |> ReactNode.unit
            |>! hasChild 1 (icon icn |> ReactNode.unit)
            |> hasDescendentClass "tile-icon"
        }

        
    ]