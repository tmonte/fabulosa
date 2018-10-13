namespace Fabulosa

module Accordion =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    type AccordionItemOptional =
        | Icon of Icon.T
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

    let createIcon optional =
        optional
        |> List.tryPick someIcon
        |> Option.orElse
             (Some
                { Icon.props with
                    Kind = Icon.Kind.ArrowRight })
        |> Option.map
             (fun props ->
                { props with
                    HTMLProps = props.HTMLProps
                    |> addProp (ClassName "mr-1") })
        |> Option.get

    let accordionItem (c: AccordionItem) =
        let optional, children = c
        let icon = createIcon optional
        R.details
            [ ClassName "accordion" ]
            [ R.summary
                [ ClassName "accordion-header" ]
                [ Icon.ƒ icon
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