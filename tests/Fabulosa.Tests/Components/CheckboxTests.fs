module CheckboxTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Checkbox tests" [

        test "Checkbox default" {
            let props = Checkbox.props
            let checkbox = Checkbox.ƒ props
            let input =
                R.input [Type "checkbox"]
                |> ReactNode.unit
            let icon =
                R.i [ClassName "form-icon"] []
                |> ReactNode.unit
            let label =
                R.str "Label"
                |> ReactNode.unit

            checkbox
            |> ReactNode.unit
            |>! hasUniqueClass "form-checkbox"
            |>! hasChild 1 input
            |>! hasChild 1 icon
            |> hasChild 1 label
        }

        test "Checkbox inline" {
            let props = { Checkbox.props with Inline = true }
            let checkbox = Checkbox.ƒ props

            checkbox
            |> ReactNode.unit
            |> hasClass "form-checkbox form-inline"
        }

        test "Checkbox text" {
            let props = { Checkbox.props with Text = "custom" }
            let checkbox = Checkbox.ƒ props
            let label =
                R.str "custom"
                |> ReactNode.unit
            
            checkbox
            |> ReactNode.unit
            |>! hasUniqueClass "form-checkbox"
            |> hasChild 1 label
        }

        test "Checkbox html props" {
            let props = { Checkbox.props with HTMLProps = [ClassName "custom"] }
            let checkbox = Checkbox.ƒ props
            let input =
                R.input
                    [ ClassName "custom"
                      Type "checkbox" ]
                |> ReactNode.unit
            
            checkbox
            |> ReactNode.unit
            |>! hasUniqueClass "form-checkbox"
            |> hasChild 1 input
        }

    ]