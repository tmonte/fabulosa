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
               
    let breadcrumbLink (comp: BreadcrumbLink) =
        let opt, (Href hrf), (Text txt) = comp
        opt
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> R.div
        <| [ R.a [ P.Href hrf ] [ R.str txt ] ]

    type BreadcrumbTextOptional = P.HTMLProps
    
    type BreadcrumbText =
        BreadcrumbTextOptional * BreadcrumbItemChildren

    let breadcrumbText (comp: BreadcrumbText) =
        let opt, (Text txt) = comp
        opt
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> R.div
        <| [ R.str txt ]

    type BreadcrumbElementsOptional = P.HTMLProps
    
    type BreadcrumbElementsChildren = ReactElement list

    type BreadcrumbElements =
        BreadcrumbElementsOptional * BreadcrumbElementsChildren

    let breadcrumbElements (comp: BreadcrumbElements) =
        let opt, chi = comp
        opt
        |> P.addProp (P.ClassName "breadcrumb-item")
        |> R.div
        <| chi

    type BreadcrumbOptional = P.HTMLProps
    
    type BreadcrumbChildren =
        | BreadcrumbElements of BreadcrumbElements
        | BreadcrumbLink of BreadcrumbLink
        | BreadcrumbText of BreadcrumbText

    type Breadcrumb =
        BreadcrumbOptional * BreadcrumbChildren list

    let breadcrumb (comp: Breadcrumb) =
        let opt, chi = comp
        opt
        |> P.addProp (P.ClassName "breadcrumb")
        |> R.ul
        <| List.map
            (function
             | BreadcrumbElements elements -> breadcrumbElements elements
             | BreadcrumbLink link -> breadcrumbLink link
             | BreadcrumbText text -> breadcrumbText text)
            chi
