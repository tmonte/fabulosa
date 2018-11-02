module CheckboxTests

open Expecto
open Fabulosa
open Fabulosa.Checkbox
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Checkbox tests" [

        test "Checkbox default" {
           let input =
               R.input [Type "checkbox"]
               |> ReactNode.unit
           let icon =
               R.i [ClassName "form-icon"] []
               |> ReactNode.unit
           let label =
               R.str "Checkbox"
               |> ReactNode.unit

           checkbox ([], Text "Checkbox")
           |> ReactNode.unit
           |>! hasUniqueClass "form-checkbox"
           |>! hasChild 1 input
           |>! hasChild 1 icon
           |>! hasChild 1 label
           |> hasText "Checkbox"

        }

        test "Checkbox inline" {
           checkbox ([ Inline ], Text "Checkbox")
           |> ReactNode.unit
           |> hasClass "form-inline"
        }

        test "Checkbox html props" {
           let prop = ClassName "custom"
           checkbox ([ prop ], Text "Checkbox")
           |> ReactNode.unit
           |>! hasUniqueClass "form-checkbox"
           |> hasDescendentProp prop
        }

    ]