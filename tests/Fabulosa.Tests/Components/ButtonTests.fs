module ButtonTests

open Expecto
open Fabulosa
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button default" {
            let child =
                R.div
                    [ P.ClassName "custom" ]
                    [ R.str "text" ]
            button ([], [ child ] )
            |> ReactNode.unit
            |>! hasUniqueClass "btn"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button custom class" {
            let child =
                R.div [] [ R.str "text" ]
            button ([ P.ClassName "custom"], [child])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Button kind primary" {
            let child = R.str "text"
            button
                ([ Kind Primary ], [ child ] )
            |> ReactNode.unit 
            |>! hasClass "btn btn-primary"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button kind link" {
            let child = R.str "text"
            button ([ Kind Link ], [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-link"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button color success" {
            let child = R.str "text"
            button ([ Color Success ], [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-success"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button color error" {
            let child = R.str "text"
            button ([ Color Error ], [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-error"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button size small" {
            let child = R.str "text"
            button ([ Size Small ], [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-sm"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button size large" {
            let child = R.str "text"
            button ([ Size Large ], [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn btn-lg"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button state disabled" {
            let child = R.str "text"
            button ([ State Disabled ], [ child ] )
            |> ReactNode.unit
            |>! hasClass "btn disabled"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button state active" {
            let child = R.str "text"
            button ([ State Active ], [ child ])
            |> ReactNode.unit
            |>! hasClass "btn active"
            |> hasChild 1 (child |> ReactNode.unit)
        }
        
        test "Button state loading" {
            let child = R.str "text"
            button ([ State Loading ], [ child ])
            |> ReactNode.unit
            |>! hasClass "btn loading"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button format squared action" {
            let child = R.str "text"
            button ([ Shape Squared ], [ child ])
            |> ReactNode.unit
            |>! hasClass "btn btn-action"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button format round action" {
            let child = R.str "text"
            button ([ Shape Round ], [ child ])
            |> ReactNode.unit
            |>! hasClass "btn btn-action circle"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Button children with name" {
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            button ([], [ child ])
            |> ReactNode.unit
            |>! hasClass "btn"
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }
        
        test "Button children with class" {
            let grandChild = R.span [ P.ClassName "grand-child" ] []
            let child = R.div [ P.ClassName "child" ] [ grandChild ]
            button ([ Size Small ], [ child ])
            |> ReactNode.unit
            |>! hasClass "btn btn-sm"
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

    ]