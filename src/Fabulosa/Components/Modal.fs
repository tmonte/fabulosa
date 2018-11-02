namespace Fabulosa

module R = Fable.Helpers.React
open R.Props
open Fabulosa.Extensions
open Fabulosa.Button

module Modal =
    open Fable.Import.React
    open Extensions.Fable.Helpers.React.Props
    
    module Header =
        type HeaderChildren =
        | Elements of ReactElement list
        | Text of string
                
        type Header = HTMLProps * HeaderChildren 
                
        let header (header: Header) = 
            let props, children = header
            let children =
                match children with 
                | Text t -> [R.div [ClassName "modal-title h5"] [R.str t]]
                | Elements e -> [R.div [ClassName "modal-title"] e]
            R.span props children

    module Footer =
        type FooterChildren =
        | Elements of ReactElement list
        | Buttons of Button list
        
        type Footer = HTMLProps * FooterChildren
        
        let footer (footer: Footer) =
            let props, children = footer
            let children =
                match children with
                | Elements e -> e
                | Buttons b -> b |> List.map button 
         
            props
            |> Unmerged
            |> addProp (ClassName "modal-footer")
            |> merge
            |> R.div 
            <| children
    open Header
    open Footer
    
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
    
    type ModalOptional =
        | OnRequestClose of OnClose
        | Size of Size
        | Open of bool
        interface IHTMLProp
   
    type ModalHeader =
        | Header of Header option
        
    type ModalFooter =
        | Footer of Footer option
        
    type ModalBody = 
        | Body of ReactElement list 
    
    type ModalChildren = ModalHeader * ModalBody * ModalFooter

    type Modal = HTMLProps * ModalChildren

    let modalOverLay onRequestClose =
        [ ClassName "modal-overlay" :> IHTMLProp]
        |> Unmerged
        |> addPropOpt onRequestClose
        |> merge
        |> R.a
        <| []
    
    let ƒheader header (onRequestClose: IHTMLProp option) =
        match header, onRequestClose with 
        | Some h, Some onClick -> R.div [ClassName "modal-header"] [R.a [ClassName "btn btn-clear float-right"; onClick] []; Header.header h] |> Some
        | Some h, None -> R.div [ClassName "modal-header"] [ Header.header h] |> Some
        | None, Some onClick -> R.div [ClassName "modal-header"] [R.a [ClassName "btn btn-clear float-right"; onClick] []] |> Some
        | None, None -> None
        
    let ƒfooter =
        function
        | Some footerElement -> R.div [ClassName "modal-footer"] [footer footerElement] |> Some
        | None -> None
    
    let private onRequestClose =
        fun (prop: IHTMLProp) ->
            match prop with
            | :? ModalOptional as opt ->
                match opt with
                | OnRequestClose fn -> OnClick fn :> IHTMLProp |> Some
                | _ -> None
            | _ -> None
        |> List.tryPick
    
    let private isOpen =
        fun (prop: IHTMLProp) ->
            match prop with
            | :? ModalOptional as opt ->
                match opt with
                | Open o -> Some o                        
                | _ -> None
            | _ -> None
    
    let private size =
        fun (prop: IHTMLProp) ->
            match prop with
            | :? ModalOptional as opt ->
                match opt with
                | Size Small -> className "modal-sm" |> Some                        
                | Size Medium -> className "modal-md" |> Some                        
                | Size Large -> className "modal-lg" |> Some                        
                | _ -> None
            | _ -> None
    
    let modal (modal: Modal) =
        let props, children = modal
        let (Header header), (Body body), (Footer footer) = children
        let onRequestClose = onRequestClose props
        
        match List.tryPick isOpen props with 
        | Some true ->
            props
            |> Unmerged
            |> addProp (ClassName "modal active")
            |> addOptionOrElse size (ClassName "modal-md")
            |> merge
            |> R.div 
            <| [
                modalOverLay onRequestClose
                R.div [ClassName "modal-container"] [
                    ƒheader header onRequestClose |> R.ofOption
                    R.div [ClassName "modal-body"] body
                    ƒfooter footer |> R.ofOption
                ]
            ] |> Portal.ƒ "modal-portal"
        | Some false
        | None -> null