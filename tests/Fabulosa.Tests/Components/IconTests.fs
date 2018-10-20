module IconTests

open Expecto
open Fabulosa.Icon
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Icon tests" [

        test "Icon default" {
            icon ([], Kind Download)
            |> ReactNode.unit
            |> hasClass "icon icon-download"
        }

        test "Icon size x2" {
            icon ([ Size X2 ], Kind Download)
            |> ReactNode.unit
            |> hasClass "icon-2x"
        }

        test "Icon size x3" {
            icon ([ Size X3 ], Kind Download)
            |> ReactNode.unit
            |> hasClass "icon-3x"
        }

        test "Icon size x4" {
            icon ([ Size X4 ], Kind Download)
            |> ReactNode.unit
            |> hasClass "icon-4x"
        }

        test "Icon kind" {
            icon ([ Size X2 ], Kind Apps)
            |> ReactNode.unit
            |> hasClass "icon-apps"
        }

        test "Icon html props" {
            icon ([ P.ClassName "custom" ], Kind Download)
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]