module TabTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect


[<Tests>]
let tests =
    testList "Tab tests" [

        test "Tab default" {
           Tab.ƒ
               (Tab.props, [])
            |> ReactNode.unit
            |> hasUniqueClass "tab"
        }

        test "Tab html props" {
            Tab.ƒ
                ({ Tab.props with
                     HTMLProps =
                       [ ClassName "custom" ] },
                 [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Tab action" {
            let button =
                Button.ƒ
                    (Button.props,
                     [ R.str "Button" ])
            Tab.ƒ
                ({ Tab.props with
                     Action = Some [ button ] },
                 [])
            |> ReactNode.unit
            |>! hasDescendentClass "tab-item tab-action"
            |> hasChild 1 (button |> ReactNode.unit)
        }

        test "Tab children" {
            let item =
                (Tab.Item.props,
                 [ R.a [] [ R.str "Tab" ] ])
            Tab.ƒ
                (Tab.props, [ item ])
            |> ReactNode.unit
            |> hasChild 1 (Tab.Item.ƒ item |> ReactNode.unit)
        }

        test "Tab item defaults" {
            let child = R.a [] [ R.str "Tab" ]
            Tab.Item.ƒ
                (Tab.Item.props, [ child ])
            |> ReactNode.unit
            |> hasChild 1 (child |> ReactNode.unit)
        }

        //test "Tab item badge" {
        //    Tab.Item.ƒ
        //        ({ Tab.Item.props with
        //             Badge = Some 1 }, [])
        //    |> ReactNode.unit
        //    |>! hasProp (Data ("badge", 1))
        //    |> hasClass "badge"
        //}
        
    ]