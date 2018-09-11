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
    
    let ƒ props = 
        R.span [] [R.str "Die welt sing laut bis zehn"]
        
    let f = ƒ