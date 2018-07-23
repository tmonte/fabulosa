module ResponsiveTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Responsive tests" [

        test "Responsive props should map to classes" {
            let responsiveProps = [Responsive.Hide Responsive.XS; Responsive.Show Responsive.LG]
            let subject = List.map Responsive.classes responsiveProps
            Expect.containsAll subject ["hide-xs"; "show-lg"] "Should contain show and hide class"
        }

        test "Responsive without should be a react html node" {
            let node = R.Node ("div", [ClassName "responsive"], [])
            let subject = Responsive.responsive [] R.div [] []
            compareNode subject node
        }

        test "Responsive with props should be a react html node" {
            let custom _ props _ = R.div props []
            let node = R.Node ("div", [ClassName "responsive"], [])
            let subject = Responsive.responsiveP [] custom [] [] []
            compareNode subject node
        }

    ]