namespace Fabulosa

module R = Fable.Helpers.React
open R.Props
open Fabulosa.Extensions

[<RequireQualifiedAccess>]
module Breadcrumbs =
    open Fable.Import.React
    open Extensions.Fable.Helpers.React.Props

    type Props = {
        HTMLProps: IHTMLProp list
    }
    
    let defaults = {
         HTMLProps = []
    }
    
    let ƒ props children = 
        props.HTMLProps
        |> addProp (ClassName "breadcrumb")
        |> R.ul
        <| children
        
    let f = ƒ

[<RequireQualifiedAccess>]
module BreadcrumbItem =
    open Extensions.Fable.Helpers.React.Props
    open Fable.Import.React

    type Link = {
        Href: string
        Text: string
    }

    type Children = 
    | Elements of ReactElement list
    | Link of Link
    | Text of string
    
    type Props = {
        HTMLProps: IHTMLProp list
    }    
    
    let defaults = {
        HTMLProps = []
    }
    
    let ƒ props children = 
        let c = 
            match children with 
            | Text t -> [R.fragment [] [R.str t]]
            | Link l -> [R.a [Href l.Href] [R.str l.Text]]
            | Elements e -> e 
        
        props.HTMLProps
        |> addProp (ClassName "breadcrumb-item")
        |> R.li
        <| c
        
    let f = ƒ