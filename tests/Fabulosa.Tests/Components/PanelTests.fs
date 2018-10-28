module PanelTests

open Expecto
open Fabulosa.Tab
open Fabulosa.Panel
module R = Fable.Helpers.React
module P = R.Props
open Expect


[<Tests>]
let tests =
    testList "Panel tests" [

        test "Panel default" {
            panel ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "panel"
        }

        test "Panel html props" {
            panel ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Panel header" {
            let header = ([], [ Title "Comments" ])
            panel ([], [ Header header ])
            |> ReactNode.unit
            |> hasChild 1 (panelHeader header |> ReactNode.unit)
            panelHeader header
            |> ReactNode.unit
            |> hasDescendentClass "panel-title"
        }

        test "Panel nav" {
            let nav = [ R.str "Nav" ]
            let child = ([], [ Item ([], [ R.a [] [ R.str "Tab 1" ] ]) ])
            panel ([], [ Nav ([], (Tab child)) ])
            |> ReactNode.unit
            |> hasChild 1 (tab child |> ReactNode.unit)
        }

        test "Panel body" {
            let body = ([], [ R.str "Body" ])
            panel ([], [ Body body ])
            |> ReactNode.unit
            |> hasChild 1 (panelBody body |> ReactNode.unit)
            panelBody body
            |> ReactNode.unit
            |> hasUniqueClass "panel-body"
        }

        test "Panel footer" {
            let footer = ([], [ R.str "Footer" ])
            panel ([], [ Footer footer ])
            |> ReactNode.unit
            |> hasChild 1 (panelFooter footer |> ReactNode.unit)
            panelFooter footer
            |> ReactNode.unit
            |> hasUniqueClass "panel-footer"
        }

    ]