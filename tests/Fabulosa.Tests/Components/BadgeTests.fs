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
            let props = Badge.props
            let badge = Badge.ƒ props

            badge
            |> ReactNode.unit
            |> hasUniqueClass "badge"
        }

        test "Badge data" {
            let props = { Badge.props with Badge = 1 }
            let badge = Badge.ƒ props

            badge
            |> ReactNode.unit
            |> hasProp (Data ("badge", 1))
        }

        test "Badge div" {
            let child = R.str "Text"
            let props = {
                Badge.props with
                    Kind = Badge.Kind.Div
                        ([ClassName "custom"], [child])
            }
            let badge = Badge.ƒ props

            badge
            |> ReactNode.unit
            |>! hasClass "custom"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Badge span" {
            let child = R.str "Text"
            let props = {
                Badge.props with
                    Kind = Badge.Kind.Span
                        ([ClassName "custom"], [child])
            }
            let badge = Badge.ƒ props

            badge
            |> ReactNode.unit
            |>! hasClass "custom"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Badge button" {
            let child = R.str "Text"
            let props = {
                Badge.props with
                    Kind = Badge.Kind.Button
                        (Button.props, [child])
            }
            let badge = Badge.ƒ props

            badge
            |> ReactNode.unit
            |>! hasClass "btn"
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Badge avatar" {
            let props = {
                Badge.props with
                    Kind = Badge.Kind.Avatar
                        Avatar.props
            }
            let badge = Badge.ƒ props

            badge
            |> ReactNode.unit
            |> hasClass "avatar"
        }

    ]