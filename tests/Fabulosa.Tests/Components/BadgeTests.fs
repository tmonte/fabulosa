module BadgeTests

open Expecto
open Fabulosa.Badge
open Fabulosa.Avatar
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Badge tests" [

        test "Badge default" {
            badge ([], Value 1, BadgeDiv ([], [ R.str "Badge" ]))
            |> ReactNode.unit
            |>! hasUniqueClass "badge"
            |>! hasProp (P.Data ("badge", 1))
            |> hasText "Badge"
        }

        test "Badge span" {
            badge ([], Value 2, BadgeSpan ([], [ R.str "Badge" ]))
            |> ReactNode.unit
            |>! hasUniqueClass "badge"
            |>! hasProp (P.Data ("badge", 2))
            |> hasText "Badge"
        }

        test "Badge button" {
            badge ([], Value 3, BadgeButton ([], [ R.str "Badge" ]))
            |> ReactNode.unit
            |>! hasUniqueClass "btn badge"
            |>! hasProp (P.Data ("badge", 3))
            |> hasText "Badge"
        }

        test "Badge avatar" {
            badge ([], Value 1, BadgeAvatar ([], Initial "FA"))
            |> ReactNode.unit
            |>! hasClass "avatar badge"
            |> hasProp (P.Data ("badge", 1))
        }

        test "Badge avatar size" {
            badge ([], Value 99, BadgeAvatar ([ Size Large ], Initial "FA"))
            |> ReactNode.unit
            |>! hasUniqueClass "avatar avatar-lg badge"
            |> hasProp (P.Data ("badge", 99))
        }

    ]