module EmptyTests

open Expecto
open Fabulosa
open Fabulosa.Icon
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Empty tests" [

        test "Empty default" {
            Empty.ƒ
                (Empty.props,
                 Empty.children)
            |> ReactNode.unit
            |> hasUniqueClass "empty"
        }

        //test "Empty html props" {
        //    Empty.ƒ
        //        ({ Empty.props with 
        //             HTMLProps = [ClassName "custom"] },
        //         Empty.children)
        //    |> ReactNode.unit
        //    |> hasClass "empty custom"
        //}

        test "Empty with children" {
            let opt, req = ([], Icon.Kind Mail)
            let icon =
                icon (opt @ [ Icon.Size X3 ], req)
                |> ReactNode.unit
            let action =
                button ([], [R.str "Action"] )
            Empty.ƒ
                (Empty.props,
                 { Icon = (opt, req)
                   Title = "Title"
                   SubTitle = "SubTitle"
                   Action = [action] })
            |> ReactNode.unit
            |>! hasChild 1 icon
            |>! hasText "Title SubTitle Action"
            |>! hasOrderedDescendentClass 1 "empty-icon empty-title empty-subtitle empty-action"
            |> ignore
        }
    ]