module AvatarTests

open Expecto
open Fabulosa.Avatar
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Avatar tests" [

        test "Avatar default" {
            avatar ([], Initial "FA")
            |> ReactNode.unit
            |> hasUniqueClass "avatar"
        }

        test "Avatar size small" {
            avatar ([ Size Small ], Initial "FA")
            |> ReactNode.unit
            |> hasUniqueClass "avatar avatar-sm"
        }

        test "Avatar data initial" {
            avatar ([], Initial "FA")
            |> ReactNode.unit
            |> hasProp (P.Data ("initial", "FA"))
        }

        test "Avatar image" {
            avatar ([], Url "FA")
            |> ReactNode.unit
            |> hasDescendentProp (P.Src "FA")
        }

        test "Avatar image with presence" {
            avatar ([ Presence Online ], Initial "FA")
            |> ReactNode.unit
            |> hasDescendentClass "avatar-presence online"
        }

        test "Avatar html props" {
            avatar ([ P.ClassName "custom" ], Initial "FA")
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]