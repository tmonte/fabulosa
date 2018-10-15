module BadgeTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Badge tests" [

        test "Badge default" {
            Badge.ƒ
                (Badge.props, Badge.children)
            |> ReactNode.unit
            |> hasUniqueClass "badge"
        }

        test "Badge data" {
            Badge.ƒ
                ({ Badge.props with Badge = 1 },
                 Badge.children)
            |> ReactNode.unit
            |> hasProp (Data ("badge", 1))
        }

        test "Badge div" {
            let child = R.str "Text"
            Badge.ƒ
                (Badge.props,
                 Badge.Child.Div
                   ([ ClassName "custom" ],
                    [ child ]))
            |> ReactNode.unit
            |>! hasClass "custom"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Badge span" {
            let child = R.str "Text"
            Badge.ƒ
                (Badge.props,
                 Badge.Child.Span
                   ([ ClassName "custom" ],
                    [ child ]))
            |> ReactNode.unit
            |>! hasClass "custom"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Badge button" {
            let child = R.str "Text"
            Badge.ƒ
                (Badge.props,
                 Badge.Child.Button
                   ([], [ child ]))
            |> ReactNode.unit
            |>! hasClass "btn"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Badge avatar" {
            Badge.ƒ
                (Badge.props,
                 Badge.Child.Avatar
                   Avatar.props)
            |> ReactNode.unit
            |> hasClass "avatar"
        }

    ]