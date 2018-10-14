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

    type AccordionItemChildren =
        { Header: string
          Body: ReactElement list }

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
        |> Option.orElse (Some ([], { Kind = ArrowRight }))
        |> Option.map (fun (iconOpt, iconReq) ->
             (iconOpt |> addProp (ClassName "mr-1"), iconReq))
        |> Option.get

    let accordionItem (c: AccordionItem) =
        let optional, children = c
        let i = createIcon optional
        R.details
            [ ClassName "accordion" ]
            [ R.summary
                [ ClassName "accordion-header" ]
                [ icon i
                  R.RawText "\n"
                  R.str children.Header ]
              R.div
                [ ClassName "accordion-body" ]
                [ R.ul
                     [ ClassName "menu menu-nav"] 
                     [ R.li
                        [ ClassName "menu-item" ]
                        children.Body ] ] ]

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