namespace Fabulosa

module R = Fable.Helpers.React
open R.Props
open Fabulosa.Extensions

[<RequireQualifiedAccess>]
module Modal =
    open Fable.Import.React
    open Extensions.Fable.Helpers.React.Props
    
    module Header =
        type Props = {
            HTMLProps: IHTMLProp list
        }
               
        type Children =
        | Element of ReactElement list
        | Text of string
        
        let defaults = {
             HTMLProps = []
        }
                
        let ƒ props children = 
            let children =
                match children with 
                | Text t -> [R.div [ClassName "modal-title h5"] [R.str t]]
                | Element e -> [R.div [ClassName "modal-title"] e]
            
            props.HTMLProps
            |> addProp (ClassName "modal-header")
            |> R.div 
            <| children
            
        let f = ƒ

    module Footer =
        type Props = {
            HTMLProps: IHTMLProp list
        }
               
        type Children =
        | Element of ReactElement list
        | Buttons of Button.Props * ReactElement list list
        
        let defaults = {
             HTMLProps = []
        }
        
        let ƒ props children = R.span [] []
            
        let f = ƒ
    
    type Size =
    | Small
    | Medium
    | Large
    
    type OnClose = unit -> unit
    
    type Props = {
        HTMLProps: IHTMLProp list
        OnClose: OnClose option
        Size: Size
    }
      
    type Children = {
        Header: Header.Props option
        Body: ReactElement list
        Footer: Footer.Props option
    }
    
    let defaults = {
         HTMLProps = []
         OnClose = None
         Size = Size.Medium
    }
    
    let children = {
        Header = None
        Body =  []
        Footer =  None
    }
    
    let ƒ props children = R.span [] [] 
        
    let f = ƒ
    