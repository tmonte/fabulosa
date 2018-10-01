module PanelTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect


[<Tests>]
let tests =
    testList "Panel tests" [

        test "Panel default" {
           Panel.ƒ
               (Panel.props, Panel.children)
            |> ReactNode.unit
            |> hasUniqueClass "panel"
        }

        test "Panel html props" {
            Panel.ƒ
                ({ Panel.props with
                     HTMLProps =
                       [ ClassName "custom" ] },
                 Panel.children)
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Panel header" {
            let header = [ R.str "Header" ]
            Panel.ƒ
                (Panel.props,
                 { Panel.children with
                     Header = Some header })
            |> ReactNode.unit
            |> hasChild 1 (Panel.Header.ƒ header |> ReactNode.unit)
        }

        test "Panel nav" {
            let nav = [ R.str "Nav" ]
            Panel.ƒ
                (Panel.props,
                 { Panel.children with
                     Nav = Some nav })
            |> ReactNode.unit
            |> hasChild 1 (Panel.Nav.ƒ nav |> ReactNode.unit)
        }

        test "Panel body" {
            let body = [ R.str "Body" ]
            Panel.ƒ
                (Panel.props,
                 { Panel.children with
                     Body = Some body })
            |> ReactNode.unit
            |> hasChild 1 (Panel.Body.ƒ body |> ReactNode.unit)
        }

        test "Panel footer" {
            let footer = [ R.str "Footer" ]
            Panel.ƒ
                (Panel.props,
                 { Panel.children with
                     Footer = Some footer })
            |> ReactNode.unit
            |> hasChild 1 (Panel.Footer.ƒ footer |> ReactNode.unit)
        }

    ]