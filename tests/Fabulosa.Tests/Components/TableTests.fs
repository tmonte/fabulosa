module TableTests

open Expecto
open Expect
open Fable.Helpers.React.Props
open Fabulosa.Table
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Table tests" [

        test "Table default" {
            table ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "table"
        }

        test "Table kind striped" {
            table
                ([ Kind Striped ], [])
            |> ReactNode.unit
            |> hasClass "table-striped"
        }

        test "Table kind hover" {
            table
                ([ Kind Hover ], [])
            |> ReactNode.unit
            |> hasClass "table-hover"
        }

        test "Table html props" {
            table([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Table head and body" {
            let head = ([], [])
            let body = ([], [])
            table
                ([],
                 [ Head head
                   Body body ])
            |> ReactNode.unit
            |>! hasChild 1 (tableHead head |> ReactNode.unit)
            |> hasChild 1 (tableBody body |> ReactNode.unit)
        }

        test "Table rows and columns" {
            let tableTitleColumn1 =
                ([], [ R.str "Title One" ])
            let tableTitleColumn2 =
                ([], [ R.str "Title Two" ])
            let headRow =
                ([],
                 [ TitleColumn tableTitleColumn1
                   TitleColumn tableTitleColumn2 ])
            let column1 = ([], [ R.str "One" ])
            let column2 = ([], [ R.str "Two" ])
            let row =
                ([],
                 [ Column column1
                   Column column2 ])
            let head = ([], [ Row headRow ])
            let body = ([], [ Row row ])
            table
                ([],
                 [ Head head
                   Body body ])
            |> ReactNode.unit
            |>! hasChild 1 (tableHead head |> ReactNode.unit)
            |>! hasChild 1 (tableRow headRow |> ReactNode.unit)
            |>! hasChild 1 (tableTitleColumn tableTitleColumn1 |> ReactNode.unit)
            |>! hasChild 1 (tableTitleColumn tableTitleColumn2 |> ReactNode.unit)
            |>! hasChild 1 (tableBody body |> ReactNode.unit)
            |>! hasChild 1 (tableRow row |> ReactNode.unit)
            |>! hasChild 1 (tableColumn column1 |> ReactNode.unit)
            |> hasChild 1 (tableColumn column2 |> ReactNode.unit)
        }

        test "Head html props" {
            tableHead  
                ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Body html props" {
            tableBody  
                ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Row html props" {
            tableRow  
                ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Title column html props" {
            tableTitleColumn  
                ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Column html props" {
            tableColumn  
                ([ ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]