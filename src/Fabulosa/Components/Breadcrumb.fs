namespace Fabulosa

module Breadcrumb =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open Fable.Import.React
    open R.Props
        
    type BreadcrumbLinkRequired =
        { Href: string }

    type BreadcrumbLinkChildren =
        { Text: string }

    type BreadcrumbLink =
        HTMLProps * BreadcrumbLinkRequired * BreadcrumbLinkChildren
               
    let breadcrumbLink (c: BreadcrumbLink) =
        let optional, required, children = c
        optional
        |> addProp (ClassName "breadcrumb-item")
        |> R.div
        <| [ R.a [ Href required.Href ] [ R.str children.Text ] ]

    type BreadcrumbTextOptional = HTMLProps
    
    type BreadcrumbTextChildren =
        { Text: string }

    type BreadcrumbText =
        BreadcrumbTextOptional * BreadcrumbTextChildren

    let breadcrumbText (c: BreadcrumbText) =
        let optional, children = c
        optional
        |> addProp (ClassName "breadcrumb-item")
        |> R.div
        <| [ R.str children.Text ]

    type BreadcrumbElementsOptional = HTMLProps
    
    type BreadcrumbElementsChildren = ReactElement list

    type BreadcrumbElements =
        BreadcrumbElementsOptional * BreadcrumbElementsChildren

    let breadcrumbElements (c: BreadcrumbElements) =
        let optional, children = c
        optional
        |> addProp (ClassName "breadcrumb-item")
        |> R.div
        <| children

    type BreadcrumbOptional = HTMLProps
    
    type BreadcrumbChildren =
        | BreadcrumbElements of BreadcrumbElements
        | BreadcrumbLink of BreadcrumbLink
        | BreadcrumbText of BreadcrumbText

    type Breadcrumb =
        BreadcrumbOptional * BreadcrumbChildren list

    let breadcrumb (c: Breadcrumb) =
        let optional, children = c
        optional
        |> addProp (ClassName "breadcrumb")
        |> R.ul
        <| List.map
            (function
             | BreadcrumbElements elements -> breadcrumbElements elements
             | BreadcrumbLink link -> breadcrumbLink link
             | BreadcrumbText text -> breadcrumbText text)
            children
