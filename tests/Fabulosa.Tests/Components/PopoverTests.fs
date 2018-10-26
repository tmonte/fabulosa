module PopoverTests

open Expecto
open Fabulosa.Popover
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect


[<Tests>]
let tests =
    testList "Popover tests" [

        test "Popover default" {
            popover ([], (Trigger [], Content []))
            |> ReactNode.unit
            |> hasUniqueClass "popover"
        }

        test "Popover html props" {
            popover ([ P.ClassName "custom" ], (Trigger [], Content []))
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Popover left" {
            popover ([ Position Left ], (Trigger [], Content []))
            |> ReactNode.unit
            |> hasClass "popover-left"
        }

        test "Popover trigger" {
            let trigger = button ([], [ R.str "Button" ])
            popover ([], (Trigger [ trigger ], Content []))
            |> ReactNode.unit
            |> hasChild 1 (trigger |> ReactNode.unit)
        }

        test "Popover content" {
            let content =
                R.div
                    [ P.ClassName "my-content" ]
                    [ R.str "Some content here..." ]
            popover ([], (Trigger [], Content [ content ]))
            |> ReactNode.unit
            |>! hasChild 1 (content |> ReactNode.unit)
            |> hasDescendentClass "popover-container"
        }

    ]