module MenuTests

open Expecto
open Fabulosa.Menu
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Menu tests" [

        test "Menu default" {
           menu ([], Trigger ([], [R.str "Trigger"]), [])
           |> ReactNode.unit
           |>! hasDescendentClass "btn"
           |> hasText "Trigger"
        }

        test "Menu with single item" {
           let link =
               R.a
                   [ ClassName "custom" ]
                   [ R.str "link" ]
           menu ([ IsOpen true ], Trigger ([], [R.str "Trigger"]), [ Item [ link ] ])
           |> ReactNode.unit
           |>! hasChild 1 (link |> ReactNode.unit)
           |> hasDescendentClass "menu-item"
        }

        test "Menu with item and empty divider" {
           let link =
               R.a
                   [ ClassName "custom" ]
                   [ R.str "link" ]
           menu ([ IsOpen true ], Trigger ([], [R.str "Trigger"]), [ Item [ link ]; Divider [] ])
           |> ReactNode.unit
           |>! hasChild 1 (link |> ReactNode.unit)
           |>! hasDescendentClass "menu-item"
           |> hasDescendentClass "divider"
        }
    
    ]