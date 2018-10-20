module EmptyTests

open Expecto
open Fabulosa.Icon
open Fabulosa.Button
open Fabulosa.Empty
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Empty tests" [

        test "Empty default" {
            let icnOpt, icnReq = ([], IconRequired.Kind Mail)
            let icon =
                icon (icnOpt @ [ IconOptional.Size X3 ], icnReq)
                |> ReactNode.unit
            let btnOpt, btnReq = ([], [ R.str "Action" ])
            let action =
                button (btnOpt, btnReq)
            empty
                ([],
                 (Icon (icnOpt, icnReq),
                  Title "Title",
                  Subtitle "Subtitle",
                  Action [ action ]))
            |> ReactNode.unit
            |>! hasChild 1 icon
            |>! hasChild 1 (action |> ReactNode.unit)
            |>! hasText "Title Subtitle Action"
            |>! hasOrderedDescendentClass 1 "empty-icon empty-title empty-subtitle empty-action"
            |> ignore
        }

    ]