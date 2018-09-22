module ChipTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Chip tests" [

        test "Chip default" {
            Chip.ƒ
                (Chip.props,
                 Chip.children)
            |> ReactNode.unit
            |> hasUniqueClass "chip"
        }

        test "Chip html props" {
            Chip.ƒ
                ({ Chip.props with 
                     HTMLProps = [ClassName "custom"] },
                 Chip.children)
            |> ReactNode.unit
            |> hasClass "chip custom"
        }

        test "Chip removable" {
            let fn = ignore
            Chip.ƒ
                ({ Chip.props with
                    OnRemove = Some fn },
                 Chip.children)
            |> ReactNode.unit
            |> hasDescendentProp (OnClick fn)
        }

        test "Chip with children" {
            let avatar =
                Avatar.ƒ
                    { Avatar.props with
                        Size = Avatar.Size.Small }
                |> ReactNode.unit
            let text =
                R.str "Text"
                |> ReactNode.unit
            Chip.ƒ
                (Chip.props,
                 { Chip.children with
                     Avatar = Some Avatar.props
                     Text = "Text" })
            |> ReactNode.unit
            |>! hasChild 1 avatar
            |>! hasChild 1 text
            |> ignore
        }
    ]