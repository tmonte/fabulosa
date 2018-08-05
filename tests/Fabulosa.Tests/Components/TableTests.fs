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
            let subject = Table.Head.ƒ Table.Head.defaults []
            compareNode subject node
        }
        
        test "Body should be a react html node" {
            let node = R.Node ("tbody", [], [])
            let subject = Table.Body.ƒ Table.Body.defaults []
            compareNode subject node
        }

        test "Row should be a react html node" {
            let node = R.Node ("tr", [ClassName ""], [])
            let subject = Table.Row.ƒ Table.Row.defaults []
            compareNode subject node
        }

        test "Cell should be a react html node" {
            let node = R.Node ("td", [], [])
            let subject = Table.Column.ƒ Table.Column.defaults []
            compareNode subject node
        }

        test "Header cell should be a react html node" {
            let node = R.Node ("th", [], [])
            let subject = Table.TitleColumn.ƒ Table.TitleColumn.defaults []
            compareNode subject node
        }
    ]