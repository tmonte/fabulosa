module AccordionTests

open Expecto
open Fabulosa.Accordion
open Fabulosa
module R = Fable.Helpers.React
module P = R.Props
open Expect

[<Tests>]
let tests =
    testList "Accordion tests" [

        test "Accordion default" {
            accordion ([],
              [ AccordionItem ([],
                  { Header = "Header One"
                    Body =
                      [ R.a [] [ R.str "Item One" ]
                        R.a [] [ R.str "Item Two" ] ] })
                AccordionItem ([],
                   { Header = "Header One"
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] }) ])
            |> ReactNode.unit
            |> hasOrderedDescendentClass 2 "accordion accordion-header accordion-body"
        }

        test "Accordion custom icon" {
            let icon =
                { Icon.props with
                    Kind = Icon.Kind.Forward }
            let renderedIcon =
                { icon with
                    HTMLProps = [ P.ClassName "mr-1" ] }
            accordion ([],
              [ AccordionItem ([ Icon icon ],
                   { Header = "Header One"
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] })
                AccordionItem ([ Icon icon ],
                   { Header = "Header One"
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] }) ])
            |> ReactNode.unit
            |> hasChild 2 (Icon.ƒ renderedIcon |>  ReactNode.unit)
        }

    ]