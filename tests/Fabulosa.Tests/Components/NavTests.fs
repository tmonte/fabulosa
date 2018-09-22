module NavTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Nav tests" [

        test "Nav default" {
            Nav.ƒ
                (Nav.props, [])
            |> ReactNode.unit
            |> hasUniqueClass "nav"
        }

        test "Nav html props" {
            Nav.ƒ
                ({ Nav.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Nav item defaults" {
            Nav.ƒ
                (Nav.props,
                  [ Nav.Child.Item Nav.Item.props ])
            |> ReactNode.unit
            |>! hasDescendentClass "nav-item"
            |>! hasDescendentProp (Href "#")
            |> hasText ""
        }

        test "Nav item text" {
            let text = "Item"
            Nav.ƒ
                (Nav.props,
                 [ Nav.Child.Item
                     { Nav.Item.props with Text = text } ])
            |> ReactNode.unit
            |> hasText text
        }

        test "Nav item href" {
            let href = "https://google.com"
            Nav.ƒ
                (Nav.props,
                 [ Nav.Child.Item
                     { Nav.Item.props with Href = href } ])
            |> ReactNode.unit
            |> hasDescendentProp (Href href)
        }

        test "Nav multiple items" {
            let text1 = "Item 1"
            let href1 = "https://google.com"
            let text2 = "Item 2"
            let href2 = "https://bing.com"
            Nav.ƒ
                (Nav.props,
                 [ Nav.Child.Item
                     { Nav.Item.props with
                         Href = href1
                         Text = text1 }
                   Nav.Child.Item
                     { Nav.Item.props with
                         Href = href2
                         Text = text2 } ])
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 2 "nav-item"
            |>! hasDescendentProp (Href href1)
            |>! hasDescendentProp (Href href2)
            |> hasText (String.concat " " [ text1;text2 ] )
        }

        test "Nav multiple nested items" {
            let text1 = "Item 1"
            let href1 = "https://google.com"
            let text2 = "Item 2"
            let href2 = "https://bing.com"
            let text3 = "Item 3"
            let href3 = "https://yahoo.com"
            Nav.ƒ
                (Nav.props,
                 [ Nav.Child.Item
                     { Nav.Item.props with
                         Href = href1
                         Text = text1 }
                   Nav.Child.Nav
                     ( Nav.props,
                       [ Nav.Child.Item
                             { Nav.Item.props with
                                 Href = href3
                                 Text = text3 } ] )
                   Nav.Child.Item
                     { Nav.Item.props with
                         Href = href2
                         Text = text2 } ])
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 3 "nav-item"
            |>! hasDescendentProp (Href href1)
            |>! hasDescendentProp (Href href2)
            |>! hasDescendentProp (Href href3)
            |> hasText (String.concat " " [ text1; text3; text2 ])
        }
    
    ]