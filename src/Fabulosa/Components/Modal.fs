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
        | Elements of ReactElement list
        | Text of string
        
        [<RequireQualifiedAccess>]
        type T = Props * Children
        
        let props = {
            HTMLProps = []
        }
                
        let ƒ (header: T) = 
            let props, children = header
            let children = match children with 
            | Text t -> [R.div [ClassName "modal-title h5"] [R.str t]]
            | Elements e -> [R.div [ClassName "modal-title"] e]
            
            props.HTMLProps
            |> R.span 
            <| children
            
        let f = ƒ

    module Footer =
        type Props = {
            HTMLProps: IHTMLProp list
        }
               
        type Children =
        | Elements of ReactElement list
        | Buttons of Button.T list
        
        [<RequireQualifiedAccess>]
        type T = Props * Children
                
        let props = {
             HTMLProps = []
        }
        
        let ƒ (footer: T) =
            let props, children = footer
            let children =
                match children with
                | Elements e -> e
                | Buttons b -> b |> List.map Button.ƒ 
         
            props.HTMLProps
            |> addProp (ClassName "modal-footer")
            |> R.div 
            <| children
            
        let f = ƒ
    
    type Size =
    | Small
    | Medium
    | Large
    
    type OnClose = MouseEvent -> unit
    
    type Props = {
        HTMLProps: IHTMLProp list
        OnRequestClose: OnClose option
        Size: Size
        IsOpen: bool
    }
      
    type Children = {
        Header: Header.T option
        Body: ReactElement list
        Footer: Footer.T option
    }
    
    [<RequireQualifiedAccess>]
    type T = Props * Children
    
    let props = {
         HTMLProps = []
         OnRequestClose = None
         Size = Size.Medium
         IsOpen = true
    }
    
    let children = {
        Header = None
        Body =  []
        Footer =  None
    }
    
    let modalOverLay onRequestClose =
        let props = 
            match onRequestClose with 
            | Some fn -> [OnClick fn :> IHTMLProp]
            | None -> []
        
        props
        |> addProp (ClassName "modal-overlay")
        |> R.a
        <| []
    
    let getClassFromSize = 
        function
        | Small -> "modal-sm"
        | Medium -> ""
        | Large -> "modal-lg"
    
    let getClasses size =
        getClassFromSize size
        |> sprintf "modal active %s"
        |> ClassName 
    
    
    let ƒheader (header: Header.T option) (onRequestClose: OnClose option) =
        match header, onRequestClose with 
        | Some h, Some f -> R.div [ClassName "modal-header"] [R.a [ClassName "btn btn-clear float-right"; OnClick f] []; Header.ƒ h] |> Some
        | Some h, None -> R.div [ClassName "modal-header"] [Header.ƒ h] |> Some
        | None, Some f -> R.div [ClassName "modal-header"] [R.a [ClassName "btn btn-clear float-right"; OnClick f] []] |> Some
        | None, None -> None
        
    let ƒfooter =
        function
        | Some f -> R.div [ClassName "modal-footer"] [f |> Footer.ƒ] |> Some
        | None -> None
        
    let ƒ modal = 
        let props, children = modal
        match props.IsOpen with 
        | true ->
            props.HTMLProps
            |> addProp (getClasses props.Size)
            |> R.div 
            <| [
                modalOverLay props.OnRequestClose
                R.div [ClassName "modal-container"] [
                    ƒheader children.Header props.OnRequestClose |> R.ofOption
                    R.div [ClassName "modal-body"] children.Body
                    ƒfooter children.Footer |> R.ofOption
                ]
            ] |> Portal.ƒ "modal-portal"
        | false -> null
        
    let f = ƒ
      