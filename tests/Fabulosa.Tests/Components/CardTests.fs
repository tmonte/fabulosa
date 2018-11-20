module CardTests

open Expecto
open Fabulosa
open Fabulosa.Card
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect
open Fable.Helpers.React.Props
open Fabulosa.Card

[<Tests>]
let tests =
    testList "Card tests" [

        test "Card default" {
            let header = ([], (Title "Apple", SubTitle "Hardware and software"))
            let body =
                ([], [ R.p [] [ R.str "To make a contribution to
                  the world by making tools for the mind
                  that advance humankind." ] ])
            let footer = ([], [ button ([], [ R.str "Purchase" ]) ])
            let image = [ P.Src "Assets/macos-sierra-2.jpg" :> IHTMLProp ]
            card ([],
              [ Image image
                Header header
                Body body
                Footer footer ])
            |> ReactNode.unit
            |>! hasUniqueClass "card"
            |>! hasChild 1 (Image.image image |> ReactNode.unit)
            |>! hasChild 1 (cardHeader header |> ReactNode.unit)
            |>! hasChild 1 (cardBody body |> ReactNode.unit)
            |> hasChild 1 (cardFooter footer |> ReactNode.unit)
        }

    ]