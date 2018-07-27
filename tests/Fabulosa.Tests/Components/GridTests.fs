module GridTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Grid tests" [

        test "Grid should be a react html node" {
            let node = R.Node ("div", [ClassName "container"], [])
            let subject = Grid.grid [] []
            compareNode subject node
        }

        test "Columns props should map to classes" {
            let columnsProps = [
                Grid.Columns.Kind Grid.Columns.Gapless
            ]
            let subject = List.map Grid.Columns.propToClass columnsProps
            Expect.contains subject "col-gapless" "Should contain columns gapless class"
        }

        test "Columns should be a react html node" {
            let node = R.Node ("div", [ClassName "columns"], [])
            let subject = Grid.columns [] [] []
            compareNode subject node
        }

        test "Column props should map to classes" {
            let columnProps = [
                Grid.Column.Kind Grid.Column.MLAuto;
                Grid.Column.Size 3;
                Grid.Column.MediumSize 5
            ]
            let subject = List.map Grid.Column.propToClass columnProps
            Expect.containsAll subject ["col-ml-auto"; "col-3"; "col-md-5"] "Should contain column classes"
        }

        test "Column should be a react html node" {
            let node = R.Node ("div", [ClassName "column"], [])
            let subject = Grid.column [] [] []
            compareNode subject node
        }

    ]