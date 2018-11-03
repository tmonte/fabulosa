module InputTests

open Expecto
open Fabulosa.Button
open Fabulosa.Icon
open Fabulosa.Input
open Fabulosa.IconInput
open Fabulosa
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Input tests" [

        test "Input default" {
           input ([])
           |> ReactNode.unit
           |> hasUniqueClass "form-input"
        }

        test "Input size small" {
           input ([ Size Small ])
           |> ReactNode.unit
           |> hasClass "input-sm"
        }

        test "Input size large" {
           input ([ Size Large ])
           |> ReactNode.unit
           |> hasClass "input-lg"
        }

        test "Input html props" {
           input ([ P.ClassName "custom" ])
           |> ReactNode.unit
           |> hasClass "custom"
        }

        test "IconInput default" {
            let iconNode =
                icon ([ P.ClassName "form-icon" ], Kind Download)
                |> ReactNode.unit
            let inputNode =
                input []
                |> ReactNode.unit

            iconInput ([], (LeftIcon ([], Kind Download), Input ([]) )) 
            |> ReactNode.unit
            |>! hasClass "has-icon-left"
            |>! hasChild 1 iconNode
            |> hasChild 1 inputNode
        }
    ]
open Fabulosa.InputGroup
[<Tests>]
let groupTests = [

        test "InputGroup default" {
            inputGroup ([], (OptText None, [ Input [] ], OptButton None))
            |> ReactNode.unit
            |>! hasClass "input-group"
            |> hasChild 1 (input [] |> ReactNode.unit)
        }

        test "InputGroup addons" {
            let btn = ([], [ R.str "Button" ])
            inputGroup ([],
                (OptText (Some "Text"),
                 [ Input [] ],
                 OptButton (Some btn)))
            |> ReactNode.unit
            |>! hasClass "input-group"
            |>! hasDescendentClass "input-group-addon"
            |>! hasChild 1 (input [] |> ReactNode.unit)
            |>! hasChild 1 (button btn |> ReactNode.unit)
            |> hasText "Text Button"
        }

    ]