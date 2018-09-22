module GridTests

open Expecto
open Fable.Helpers.React.Props
open Fabulosa
open Expect
module R = Fable.Helpers.React


[<Tests>]
let tests =
    testList "Grid tests" [

        test "Grid default" {
            Grid.ƒ
                ( Grid.props, [] )
            |> ReactNode.unit
            |> hasUniqueClass "container"
        }

        test "Grid html props" {
            Grid.ƒ
                ( { Grid.props with
                      HTMLProps = [ ClassName "custom" ] },
                  [] )
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Grid row" {
            let props = Grid.Row.props
            let children = []
            let row =
                Grid.Row.ƒ ( props, children )
            Grid.ƒ
                ( Grid.props,
                  [ props, children ] )
            |> ReactNode.unit
            |> hasChild 1 (row |> ReactNode.unit)
        }

        test "Grid row column" {
            let colProps = Grid.Column.props
            let colChildren = [ R.str "Text" ]
            let column = Grid.Column.ƒ ( colProps, colChildren )
            let rowProps = Grid.Row.props
            let rowChildren = [ colProps, colChildren ]
            let row = Grid.Row.ƒ ( rowProps, rowChildren )
            Grid.ƒ
                ( Grid.props,
                  [ rowProps, rowChildren ] )
            |> ReactNode.unit
            |>! hasChild 1 (row |> ReactNode.unit)
            |>! hasChild 1 (column |> ReactNode.unit)
            |> hasText "Text"
        }

        test "Row default" {
            Grid.Row.ƒ
                ( Grid.Row.props, [] )
            |> ReactNode.unit
            |> hasUniqueClass "columns"
        }

        test "Row html props" {
            Grid.Row.ƒ
                ( { Grid.Row.props with
                      HTMLProps = [ClassName "custom"] },
                  [] )
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Row gapless" {
            Grid.Row.ƒ
                ( { Grid.Row.props with
                      Gapless = true },
                  [] )
            |> ReactNode.unit
            |> hasClass "col-gapless"
        }

        test "Row one line" {
            Grid.Row.ƒ
                ( { Grid.Row.props with
                      OneLine = true },
                  [] )
            |> ReactNode.unit
            |> hasClass "col-oneline"
        }

        test "Column default" {
            Grid.Column.ƒ
                ( Grid.Column.props, [] )
            |> ReactNode.unit
            |> hasClass "column col-12 col-xs-0 col-sm-0 col-md-0 col-lg-0 col-xl-0"
        }

        test "Column html props" {
            Grid.Column.ƒ
                ( { Grid.Column.props with
                      HTMLProps = [ClassName "custom"] },
                  [] )
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Column size" {
            Grid.Column.ƒ
                ( { Grid.Column.props with
                      Size = 4 },
                  [] )
            |> ReactNode.unit
            |> hasClass "col-4"
        }

        test "Column medium size" {
            Grid.Column.ƒ
                ( { Grid.Column.props with
                      MDSize = 4 },
                  [] )
            |> ReactNode.unit
            |> hasClass "col-md-4"
        }

        test "Column kind" {
            Grid.Column.ƒ
                ( { Grid.Column.props with
                      Kind = Grid.Column.Kind.MLAuto },
                  [] )
            |> ReactNode.unit
            |> hasClass "col-ml-auto"
        }

    ]