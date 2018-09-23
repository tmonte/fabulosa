module TableTests

open Expecto
open Expect
open Fable.Helpers.React.Props
open Fabulosa
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Table tests" [

        test "Table default" {
            Table.ƒ (Table.props, [])
            |> ReactNode.unit
            |> hasUniqueClass "table"
        }

        test "Table kind striped" {
            Table.ƒ
                ({ Table.props with
                     Kind = Table.Kind.Striped }, [])
            |> ReactNode.unit
            |> hasClass "table-striped"
        }

        test "Table kind hover" {
            Table.ƒ
                ({ Table.props with
                     Kind = Table.Kind.Hover }, [])
            |> ReactNode.unit
            |> hasClass "table-hover"
        }

        test "Table html props" {
            Table.ƒ
                ({ Table.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Table head and body" {
            let head = (Table.Head.props, [])
            let body = (Table.Body.props, [])
            Table.ƒ
                (Table.props,
                 [ Table.Child.Head head
                   Table.Child.Body body ])
            |> ReactNode.unit
            |>! hasChild 1 (Table.Head.ƒ head |> ReactNode.unit)
            |> hasChild 1 (Table.Body.ƒ body |> ReactNode.unit)
        }

        test "Table rows and columns" {
            let titleColumn1 =
                (Table.TitleColumn.props,
                 [ R.str "Title One" ])
            let titleColumn2 =
                (Table.TitleColumn.props,
                 [ R.str "Title Two" ])
            let headRow =
                (Table.Row.props,
                 [ Table.Row.Child.TitleColumn titleColumn1
                   Table.Row.Child.TitleColumn titleColumn2 ])
            let column1 =
                (Table.Column.props,
                 [ R.str "One" ])
            let column2 =
                (Table.Column.props,
                 [ R.str "Two" ])
            let row =
                (Table.Row.props,
                 [ Table.Row.Child.Column column1
                   Table.Row.Child.Column column2 ])
            let head =
                (Table.Head.props, [ headRow ])
            let body =
                (Table.Body.props, [ row ])
            Table.ƒ
                (Table.props,
                 [ Table.Child.Head head
                   Table.Child.Body body ])
            |> ReactNode.unit
            |>! hasChild 1 (Table.Head.ƒ head |> ReactNode.unit)
            |>! hasChild 1 (Table.Row.ƒ headRow |> ReactNode.unit)
            |>! hasChild 1 (Table.TitleColumn.ƒ titleColumn1 |> ReactNode.unit)
            |>! hasChild 1 (Table.TitleColumn.ƒ titleColumn2 |> ReactNode.unit)
            |>! hasChild 1 (Table.Body.ƒ body |> ReactNode.unit)
            |>! hasChild 1 (Table.Row.ƒ row |> ReactNode.unit)
            |>! hasChild 1 (Table.Column.ƒ column1 |> ReactNode.unit)
            |> hasChild 1 (Table.Column.ƒ column2 |> ReactNode.unit)
        }

        test "Head html props" {
            Table.Head.ƒ  
                ({ Table.Head.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Body html props" {
            Table.Body.ƒ  
                ({ Table.Body.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Row html props" {
            Table.Row.ƒ  
                ({ Table.Row.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Title column html props" {
            Table.TitleColumn.ƒ  
                ({ Table.TitleColumn.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Column html props" {
            Table.Column.ƒ  
                ({ Table.Column.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

    ]