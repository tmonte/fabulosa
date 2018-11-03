module SelectTests

open Expecto
open Fabulosa
open Fabulosa.Select
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Select tests" [

        test "Select default" {
            select ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "form-select"
        }

        test "Select size small" {
            select ([ Size Small ], [])
            |> ReactNode.unit
            |> hasClass "select-sm"
        }

        test "Select size large" {
            select ([ Size Large ], [])
            |> ReactNode.unit
            |> hasClass "select-lg"
        }

        test "Select html props" {
            select ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Option default" {
            selectOption ([], Text "Value")
            |> ReactNode.unit
            |> hasText "Value"
        }

        test "Option html props" {
            selectOption ([ P.ClassName "custom"; P.Value "1" ], Text "Value")
            |> ReactNode.unit
            |>! hasClass "custom"
            |>! hasProp (P.Value "1")
            |> hasText "Value"
        }

        test "Option group default" {
            selectOptionGroup ([],
                [ Option ([], Text "Option")
                  Group ([], [ Option ([], Text "Nested") ]) ])
            |> ReactNode.unit
            |>! hasChild 1 (selectOption ([], Text "Option") |> ReactNode.unit)
            |> hasChild 1 (selectOption ([], Text "Nested") |> ReactNode.unit)
        }

        test "Option group html props" {
            selectOptionGroup ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]