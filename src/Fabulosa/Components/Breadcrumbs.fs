namespace Fabulosa

module R = Fable.Helpers.React
open R.Props
open Fabulosa.Extensions

[<RequireQualifiedAccess>]
module Breadcrumbs =
    open Fable.Import.React

    type Props = {
        BreadcrumbItems: ReactElement list
    }
    
    let defaults = {
         BreadcrumbItems = []
    }
    
    let breadcrumbItem el =
        R.li [ClassName "breadcrumb-item"] [el]
    
    let ƒ props = 
        props.BreadcrumbItems
        |> List.map breadcrumbItem 
        |> R.ul [ClassName "breadcrumb"]
        
    let f = ƒ