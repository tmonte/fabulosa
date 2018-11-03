module TextareaTests

open Expecto
open Expect
open Fabulosa
open Fabulosa.Textarea
module R = Fable.Helpers.React
open R.Props

[<Tests>]
let tests =
    testList "Textarea tests" [

        test "Textarea default" {
            textarea ([], Text "Text")
            |> ReactNode.unit
            |>! hasUniqueClass "form-input"
            |> hasText "Text"
        }

        test "Textarea html props" {
            textarea ([ ClassName "custom" ], Text "Text")
            |> ReactNode.unit
            |>! hasClass "custom"
            |> hasText "Text"
        }

    ]