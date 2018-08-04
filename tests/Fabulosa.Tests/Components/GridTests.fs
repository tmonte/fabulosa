module GridTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
open Fabulosa
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Grid tests" [

        test "Grid should be a react html node" {
            let node = R.Node ("div", [ClassName "container"], [])
            let subject = Grid.ƒ Grid.defaults []
            compareNode subject node
        }

        test "Columns should be a react html node" {
            let node = R.Node ("div", [ClassName "columns"], [])
            let subject = Grid.Row.ƒ Grid.Row.defaults []
            compareNode subject node
        }

        test "Column should be a react html node" {
            let node = R.Node ("div", [ClassName "column col-12 col-sm-12 col-md-12 col-lg-12"], [])
            let subject = Grid.Column.ƒ Grid.Column.defaults []
            compareNode subject node
        }

    ]