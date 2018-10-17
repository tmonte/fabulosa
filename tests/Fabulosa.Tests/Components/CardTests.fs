module CardTests

open Expecto
open Fabulosa
open Fabulosa.Card
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Card tests" [

        test "Card default" {
            let cardHeader = ([], (Title "Apple", SubTitle "Hardware and software"))
            let cardBody =
                ([], [ R.p [] [ R.str "To make a contribution to
                  the world by making tools for the mind
                  that advance humankind." ] ])
            let cardFooter = ([], [ button ([], [ R.str "Purchase" ]) ])
            let cardImage =
                { Media.Image.props with
                    HTMLProps = [ P.Src "assets/macos-sierra-2.jpg" ] }
            card ([],
              (Image cardImage,
               Header cardHeader,
               Body cardBody,
               Footer cardFooter))
            |> ReactNode.unit
            |>! hasUniqueClass "card"
            |>! hasOrderedDescendentClass 1 "card-header card-title card-subtitle card-image card-body card-footer"
            |>! hasChild 1 (Media.Image.ƒ cardImage |> ReactNode.unit)
            |>! hasChild 1 (header cardHeader |> ReactNode.unit)
            |>! hasChild 1 (body cardBody |> ReactNode.unit)
            |> hasChild 1 (footer cardFooter |> ReactNode.unit)
        }

    ]