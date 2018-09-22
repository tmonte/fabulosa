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
            let table = Table.ƒ Table.props []
            
            table
            |> ReactNode.unit
            |> hasUniqueClass "table"
        }

        test "Table kind striped" {
            let table =
                Table.ƒ {
                    Table.props with
                        Kind = Table.Kind.Striped
                } []
            
            table
            |> ReactNode.unit
            |> hasClass "table-striped"
        }

        test "Table kind hover" {
            let table =
                Table.ƒ {
                    Table.props with
                        Kind = Table.Kind.Hover
                } []
            
            table
            |> ReactNode.unit
            |> hasClass "table-hover"
        }

        test "Table children with name" {
            let props = Table.props
            let grandChild = R.span [] []
            let child = R.div [] [grandChild]
            let table = Table.ƒ props [child]
            
            table
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Table children with class" {
            let props = Table.props
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let table = Table.ƒ props [child]
            
            table
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Head html props" {
            let head =
                Table.Head.ƒ { 
                    Table.Head.props with
                        HTMLProps = [ClassName "custom"]
                } []
            
            head
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Head children" {
            let props = Table.Head.props
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let head = Table.Head.ƒ props [child]
            
            head
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Body html props" {
            let body =
                Table.Body.ƒ { 
                    Table.Body.props with
                        HTMLProps = [ClassName "custom"]
                } []
            
            body
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Body children" {
            let props = Table.Body.props
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let body = Table.Body.ƒ props [child]
            
            body
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Row html props" {
            let row =
                Table.Row.ƒ { 
                    Table.Row.props with
                        HTMLProps = [ClassName "custom"]
                } []
            
            row
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Row children" {
            let props = Table.Row.props
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let row = Table.Row.ƒ props [child]
            
            row
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Row active" {
            let row =
                Table.Row.ƒ {
                    Table.Row.props with
                        Active = true
                } []
            
            row
            |> ReactNode.unit
            |> hasClass "active"
        }

        test "Column html props" {
            let column =
                Table.Column.ƒ { 
                    Table.Column.props with
                        HTMLProps = [ClassName "custom"]
                } []
            
            column
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Column children" {
            let props = Table.Column.props
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let column = Table.Column.ƒ props [child]
            
            column
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Title column html props" {
            let titleColumn =
                Table.TitleColumn.ƒ { 
                    Table.TitleColumn.props with
                        HTMLProps = [ClassName "custom"]
                } []
            
            titleColumn
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Title column children" {
            let props = Table.TitleColumn.props
            let grandChild = R.span [ClassName "grand-child"] []
            let child = R.div [ClassName "child"] [grandChild]
            let titleColumn = Table.TitleColumn.ƒ props [child]
            
            titleColumn
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }
    ]