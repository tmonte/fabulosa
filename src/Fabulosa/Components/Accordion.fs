namespace Fabulosa

module Accordion =

    open Fabulosa.Extensions
    open Fabulosa.Icon
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    type AccordionIcon =
        | OptIcon of (Icon option)

    type AccordionHeader =
        | Header of string

    type AccordionBody =
        | Body of (ReactElement list)

    type AccordionItemChildren =
        AccordionIcon * AccordionHeader * AccordionBody

    type AccordionItem =
        P.HTMLProps * AccordionItemChildren

    let private createIcon icn =
        match icn with
        | Some (opt, req) -> 
            icon (P.Unmerged opt
            |> P.addProp (P.ClassName "mr-1")
            |> P.merge, req)
        | None ->
            icon ([ P.ClassName "mr-1" ], Kind ArrowRight)

    let private accordionItem ((opt, (OptIcon icn, Header hdr, Body bod)): AccordionItem) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "accordion")
        |> P.merge
        |> R.details
        <| [ R.summary
               [ P.ClassName "accordion-header" ]
               [ createIcon icn
                 R.RawText "\n"
                 R.str hdr ]
             R.div
               [ P.ClassName "accordion-body" ]
               [ R.ul
                   [ P.ClassName "menu menu-nav"]
                   [ R.li
                       [ P.ClassName "menu-item" ] bod ] ] ]

    type AccordionChild =
        Item of AccordionItem
    
    type Accordion =
        P.HTMLProps * AccordionChild list

    let accordion ((opt, chi): Accordion) =
        R.div
            opt
            (Seq.map
               (fun (Item item) -> accordionItem item)
               chi)