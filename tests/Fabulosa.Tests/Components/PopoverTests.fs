module PopoverTests

open Expecto
open Fabulosa
open Fabulosa.Button
module R = Fable.Helpers.React
open R.Props
open Expect


[<Tests>]
let tests =
    testList "Popover tests" [

        test "Popover default" {
           Popover.ƒ
               (Popover.props,
                { Trigger = []
                  Content = [] })
            |> ReactNode.unit
            |> hasUniqueClass "popover"
        }

        test "Popover html props" {
            Popover.ƒ
                ({ Popover.props with
                     HTMLProps =
                       [ ClassName "custom" ] },
                 { Trigger = []
                   Content = [] })
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Popover left" {
            Popover.ƒ
                ({ Popover.props with
                     Position = Popover.Position.Left },
                 { Trigger = []
                   Content = [] })
            |> ReactNode.unit
            |> hasClass "popover-left"
        }

        test "Popover trigger" {
            let trigger = [ button ([], [ R.str "Button" ]) ]
            Popover.ƒ
                (Popover.props,
                 { Trigger = trigger
                   Content = [] })
            |> ReactNode.unit
            |> hasChild 1 (Popover.Trigger.ƒ trigger |> ReactNode.unit)
        }

        test "Popover content" {
            let content =
                [ R.div
                    [ ClassName "my-content" ]
                    [ R.str "Some content here..." ] ]
            Popover.ƒ
                (Popover.props,
                 { Trigger = []
                   Content = content })
            |> ReactNode.unit
            |> hasChild 1 (Popover.Content.ƒ content |> ReactNode.unit)
            Popover.Content.ƒ content
            |> ReactNode.unit
            |> hasUniqueClass "popover-container"
        }

    ]