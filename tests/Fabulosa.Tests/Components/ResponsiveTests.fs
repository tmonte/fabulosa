module ResponsiveTests

open Expecto
open Fabulosa.Responsive
open Fabulosa.Button
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Responsive tests" [
         test "Responsive default" {
            let child = R.str "text"
            responsive ([], [ child ])
            |> ReactNode.unit
            |>! hasClass "responsive"
            |> hasChild 1 (child |> ReactNode.unit)
         }

         test "Responsive hide small" {
            let child = button ([], [ R.str "text" ])
            responsive ([ Hide SM ], [ child ])
            |> ReactNode.unit
            |>! hasClass "responsive hide-sm"
            |> hasChild 1 (child |> ReactNode.unit)
         }

         test "Responsive show large" {
            let child = button ([], [ R.str "text" ])
            responsive ([ Show LG ], [ child ])
            |> ReactNode.unit
            |>! hasClass "responsive show-lg"
            |> hasChild 1 (child |> ReactNode.unit)
         }

         test "Responsive children with name" {
            let grandChild = R.span [] []
            let child = R.div [] [ grandChild ]
            responsive ([], [ child ])
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
         }

         test "Responsive children with class" {
            let grandChild = R.span [ ClassName "grand-child" ] []
            let child = R.div [ ClassName "child" ] [ grandChild ]
            responsive ([], [ child ])
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
         }
    ]