module AccordionTests

open Expecto
open Fabulosa.Extensions
open Fabulosa.Accordion
open Fabulosa.Icon
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
            let opt, req = ([], { Kind = Forward })
            let rendered = (opt |> P.addProp (P.ClassName "mr-1"), req)
            accordion ([],
              [ AccordionItem ([ Icon (opt, req) ],
                   { Header = "Header One"
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] })
                AccordionItem ([ Icon (opt, req) ],
                   { Header = "Header One"
                     Body =
                       [ R.a [] [ R.str "Item One" ]
                         R.a [] [ R.str "Item Two" ] ] }) ])
            |> ReactNode.unit
            |> hasChild 2 (icon rendered |>  ReactNode.unit)
        }

    ]