module ChipTests

open Expecto
open Fabulosa
open Fabulosa.Avatar
module R = Fable.Helpers.React
module P = R.Props
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
                     HTMLProps = [P.ClassName "custom"] },
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
            |> hasDescendentProp (P.OnClick fn)
        }

        test "Chip with children" {
            let av =
                avatar ([ Size Small ], Initial "FA")
                |> ReactNode.unit
            let text =
                R.str "Text"
                |> ReactNode.unit
            Chip.ƒ
                (Chip.props,
                 { Chip.children with
                     Avatar = Some ([], Initial "FA")
                     Text = "Text" })
            |> ReactNode.unit
            |>! hasChild 1 av
            |>! hasChild 1 text
            |> ignore
        }
    ]