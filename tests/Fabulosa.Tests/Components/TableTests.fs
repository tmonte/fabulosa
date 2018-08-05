module TableTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
open Fabulosa
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Table tests" [

        test "Table should be a react html node" {
            let node = R.Node ("table", [ClassName "table"], [])
            let subject = Table.ƒ Table.defaults []
            compareNode subject node
        }

        test "Head should be a react html node" {
            let node = R.Node ("thead", [], [])
            let subject = Table.thead [] []
            compareNode subject node
        }
        
        test "Body should be a react html node" {
            let node = R.Node ("tbody", [], [])
            let subject = Table.tbody [] []
            compareNode subject node
        }

        test "Row props should map to classes" {
            let rowProps = [Table.Row.Kind Table.Row.Active]
            let subject = List.map Table.Row.propToClass rowProps
            Expect.contains subject "active" "Should contain active class"
        }

        test "Row should be a react html node" {
            let node = R.Node ("tr", [ClassName ""], [])
            let subject = Table.tr [] [] []
            compareNode subject node
        }

        test "Cell should be a react html node" {
            let node = R.Node ("td", [], [])
            let subject = Table.td [] []
            compareNode subject node
        }

        test "Header cell should be a react html node" {
            let node = R.Node ("th", [], [])
            let subject = Table.th [] []
            compareNode subject node
        }
    ]