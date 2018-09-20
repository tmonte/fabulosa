module NavbarTests

open Expecto
open Expect
open Fabulosa

[<Tests>]
let tests =
    testList "Navbar tests" [

        test "Navbar header default" {
            Navbar.ƒ
                ( Navbar.defaults, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar"
        }

        test "Navbar section default" {
            Navbar.Section.ƒ
                ( Navbar.defaults, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar-section"
        }

        test "Navbar center default" {
            Navbar.Center.ƒ
                ( Navbar.defaults, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar-center"
        }

        test "Navbar brand default" {
            Navbar.Brand.ƒ
                ( Navbar.defaults, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar-brand"
        }

    ]