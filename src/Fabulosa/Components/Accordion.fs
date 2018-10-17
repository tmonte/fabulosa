namespace Fabulosa

module Accordion =

    open Fabulosa.Extensions
    open Fabulosa.Icon
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    type AccordionItemOptional =
        | Icon of Icon
        interface IHTMLProp

    type AccordionHeader =
        | Header of string

    type AccordionBody =
        | Body of (ReactElement list)

    type AccordionItemChildren =
        AccordionHeader * AccordionBody

    type AccordionItem =
        HTMLProps * AccordionItemChildren

    let someIcon (optional: IHTMLProp) =
        match optional with
        | :? AccordionItemOptional as prop ->
            match prop with
            | Icon props -> Some props
        | _ -> None

    let createIcon opt =
        opt
        |> List.tryPick someIcon
        |> Option.orElse (Some ([], Icon.Kind ArrowRight))
        |> Option.map (fun (iconOpt, iconReq) ->
             (iconOpt |> addProp (ClassName "mr-1"), iconReq))
        |> Option.get

    let accordionItem (c: AccordionItem) =
        let optional, (Header header, Body body) = c
        let i = createIcon optional
        R.details
            [ ClassName "accordion" ]
            [ R.summary
                [ ClassName "accordion-header" ]
                [ icon i
                  R.RawText "\n"
                  R.str header ]
              R.div
                [ ClassName "accordion-body" ]
                [ R.ul
                     [ ClassName "menu menu-nav"] 
                     [ R.li
                        [ ClassName "menu-item" ]
                        body ] ] ]

    type AccordionChild =
        AccordionItem of AccordionItem
    
    type Accordion =
        HTMLProps * AccordionChild list

    let accordion (c: Accordion) =
        let optional, children = c
        R.div
            optional
            (Seq.map
               (fun (AccordionItem item) -> accordionItem item)
               children)