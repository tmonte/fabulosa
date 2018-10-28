module NavbarTests

open Expecto
open Expect
open Fabulosa.Navbar
module R = Fable.Helpers.React
open R.Props

[<Tests>]
let tests =
    testList "Navbar tests" [

        test "Navbar header default" {
            navbar ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "navbar"
        }

        test "Navbar header html props" {
            navbar ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Navbar section default" {
            navbarSection ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "navbar-section"
        }

        test "Navbar section html props" {
            navbarSection ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Navbar center default" {
            navbarCenter ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "navbar-center"
        }

        test "Navbar center html props" {
            navbarCenter ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Navbar brand default" {
            navbarBrand ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "navbar-brand"
        }

        test "Navbar brand html props" {
            navbarBrand ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]