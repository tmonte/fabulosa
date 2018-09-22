module NavbarTests

open Expecto
open Expect
open Fabulosa

[<Tests>]
let tests =
    testList "Navbar tests" [

        test "Navbar header default" {
            Navbar.ƒ
                ( Navbar.props, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar"
        }

        test "Navbar section default" {
            Navbar.Section.ƒ
                ( Navbar.props, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar-section"
        }

        test "Navbar center default" {
            Navbar.Center.ƒ
                ( Navbar.props, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar-center"
        }

        test "Navbar brand default" {
            Navbar.Brand.ƒ
                ( Navbar.props, [] )
            |> ReactNode.unit
            |> hasUniqueClass "navbar-brand"
        }

    ]