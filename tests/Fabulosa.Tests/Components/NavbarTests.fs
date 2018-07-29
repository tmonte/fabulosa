module NavbarTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
open Fabulosa
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Navbar tests" [

        test "Navbar header should be a react html node" {
            let node = R.Node ("header", [ClassName "navbar"], [])
            let subject = Navbar.header [] []
            compareNode subject node
        }

        test "Navbar section should be a react html node" {
            let node = R.Node ("section", [ClassName "navbar-section"], [])
            let subject = Navbar.section [] []
            compareNode subject node
        }

        test "Navbar center should be a react html node" {
            let node = R.Node ("section", [ClassName "navbar-center"], [])
            let subject = Navbar.center [] []
            compareNode subject node
        }

        test "Navbar brand should be a react html node" {
            let node = R.Node ("a", [ClassName "navbar-brand"], [])
            let subject = Navbar.brand [] []
            compareNode subject node
        }

    ]