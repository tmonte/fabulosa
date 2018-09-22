module SwitchTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React
open R.Props

[<Tests>]
let tests =
    testList "Switch tests" [

        test "Switch default" {
            let props = Switch.props
            let switch = Switch.ƒ props
            let input =
                R.input [Type "checkbox"]
                |> ReactNode.unit
            let icon =
                R.i [ClassName "form-icon"] []
                |> ReactNode.unit
            let label =
                R.str "Label"
                |> ReactNode.unit

            switch
            |> ReactNode.unit
            |>! hasUniqueClass "form-switch"
            |>! hasChild 1 input
            |>! hasChild 1 icon
            |> hasChild 1 label
        }

        test "Switch text" {
            let props = { Switch.props with Text = "custom" }
            let switch = Switch.ƒ props
            let label =
                R.str "custom"
                |> ReactNode.unit

            switch
            |> ReactNode.unit
            |>! hasUniqueClass "form-switch"
            |> hasChild 1 label
        }

        test "Switch html props" {
            let props = { Switch.props with HTMLProps = [ClassName "custom"] }
            let switch = Switch.ƒ props
            
            switch
            |> ReactNode.unit
            |>! hasUniqueClass "form-switch"
            |> hasDescendentClass "custom"
        }

    ]