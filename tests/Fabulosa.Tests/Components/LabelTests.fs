module LabelTests

open Expecto
open Fabulosa
open Fabulosa.Label
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Label tests" [

        test "Label default" {
            label ([], Text "Label")
            |> ReactNode.unit
            |>! hasUniqueClass "form-label"
            |> hasText "Label"
        }

        test "Label size small" {
            label ([ Size Small ], Text "Label")
            |> ReactNode.unit
            |> hasClass "label-sm"
        }

        test "Label size large" {
            label ([ Size Large ], Text "Label")
            |> ReactNode.unit
            |> hasClass "label-lg"
        }
       
        test "Label html props" {
            label ([ P.ClassName "custom" ], Text "Label")
            |> ReactNode.unit
            |> hasClass "form-label custom"
        }

    ]