module RadioTests

open Expecto
open Fabulosa
open Fabulosa.Radio
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Radio tests" [

        test "Radio default" {
            let input =
                R.input [Type "radio"]
                |> ReactNode.unit
            let icon =
                R.i [ClassName "form-icon"] []
                |> ReactNode.unit
            let label =
                R.str "Radio"
                |> ReactNode.unit

            radio ([], Text "Radio")
            |> ReactNode.unit
            |>! hasUniqueClass "form-radio"
            |>! hasChild 1 input
            |>! hasChild 1 icon
            |>! hasChild 1 label
            |> hasText "Radio"
        }

        test "Radio inline" {
            radio ([ Inline ], Text "Radio")
            |> ReactNode.unit
            |> hasClass "form-inline"
        }

        test "Radio html props" {
            let prop = ClassName "custom"
            radio ([ prop ], Text "Radio")
            |> ReactNode.unit
            |>! hasUniqueClass "form-radio"
            |> hasDescendentProp prop
        }

    ]