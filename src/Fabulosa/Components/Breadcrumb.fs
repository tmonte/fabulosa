namespace Fabulosa

module Breadcrumb =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open Fable.Import.React
    module P = R.Props

    type Text = string

    type Href = string
        
    type BreadcrumbLinkRequired =
        | Href of Href

    type BreadcrumbItemChildren =
        | Text of Text

    type BreadcrumbLink =
        P.HTMLProps * BreadcrumbLinkRequired * BreadcrumbItemChildren
               
    let breadcrumbLink (c: BreadcrumbLink) =
        let optional, (Href href), (Text text) = c
        optional
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> R.div
        <| [ R.a [ P.Href href ] [ R.str text ] ]

    type BreadcrumbTextOptional = P.HTMLProps
    
    type BreadcrumbText =
        BreadcrumbTextOptional * BreadcrumbItemChildren

    let breadcrumbText (c: BreadcrumbText) =
        let optional, (Text text) = c
        optional
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> R.div
        <| [ R.str text ]

    type BreadcrumbElementsOptional = P.HTMLProps
    
    type BreadcrumbElementsChildren = ReactElement list

    type BreadcrumbElements =
        BreadcrumbElementsOptional * BreadcrumbElementsChildren

    let breadcrumbElements (c: BreadcrumbElements) =
        let optional, children = c
        optional
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> R.div
        <| children

    type BreadcrumbOptional = P.HTMLProps
    
    type BreadcrumbChildren =
        | BreadcrumbElements of BreadcrumbElements
        | BreadcrumbLink of BreadcrumbLink
        | BreadcrumbText of BreadcrumbText

    type Breadcrumb =
        BreadcrumbOptional * BreadcrumbChildren list

    let breadcrumb (c: Breadcrumb) =
        let optional, children = c
        optional
        |> P.addProp (P.ClassName "breadcrumb")
        |> R.ul
        <| List.map
            (function
             | BreadcrumbElements elements -> breadcrumbElements elements
             | BreadcrumbLink link -> breadcrumbLink link
             | BreadcrumbText text -> breadcrumbText text)
            children
