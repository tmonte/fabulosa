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
              [ Item ([],
                  (OptIcon None,
                   Header "Header One",
                   Body
                     [ R.a [] [ R.str "Item One" ]
                       R.a [] [ R.str "Item Two" ] ] ))
                Item ([],
                   (OptIcon None,
                    Header "Header One",
                    Body
                      [ R.a [] [ R.str "Item One" ]
                        R.a [] [ R.str "Item Two" ] ] )) ])
            |> ReactNode.unit
            |> hasOrderedDescendentClass 2 "accordion accordion-header accordion-body"
        }

        test "Accordion custom icon" {
            let opt, req = ([], Kind Forward)
            let rendered = (P.Unmerged opt |> P.addProp (P.ClassName "mr-1") |> P.merge, req)
            accordion ([],
              [ Item ([],
                  (OptIcon (Some (opt, req)),
                   Header "Header One",
                   Body
                     [ R.a [] [ R.str "Item One" ]
                       R.a [] [ R.str "Item Two" ] ]))
                Item ([],
                  (OptIcon (Some (opt, req)),
                   Header "Header One",
                   Body
                     [ R.a [] [ R.str "Item One" ]
                       R.a [] [ R.str "Item Two" ] ])) ])
            |> ReactNode.unit
            |> hasChild 2 (icon rendered |>  ReactNode.unit)
        }

    ]