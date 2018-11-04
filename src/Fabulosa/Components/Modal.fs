namespace Fabulosa

module R = Fable.Helpers.React
open R.Props
open Fabulosa.Extensions
open Fabulosa.Button

module Modal =
    open Fable.Import.React
    open Extensions.Fable.Helpers.React.Props
    
    type HeaderChildren =
        | Elements of ReactElement list
        | Text of string
        
    type FooterChildren =
        | Elements of ReactElement list
        | Buttons of Button list
    
    type HeaderData = HTMLProps * HeaderChildren    
    type FooterData = HTMLProps * FooterChildren
            
    type ModalHeader =
        | Header of HeaderData option
        
    type ModalFooter =
        | Footer of FooterData option
    
    let header (header: HeaderData) =
        let props, children = header
        let children =
            match children with 
            | Text t -> [R.div [ClassName "modal-title h5"] [R.str t]]
            | HeaderChildren.Elements e -> [R.div [ClassName "modal-title"] e]
        R.span props children

    let footer (footer: FooterData) =
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
    
    type Size =
    | Small
    | Medium
    | Large
    
    type OnClose = MouseEvent -> unit
   
    type ModalOptional =
        | OnRequestClose of OnClose
        | Size of Size
        | Open of bool
        interface IHTMLProp
           
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
    
    let ƒheader headerData (onRequestClose: IHTMLProp option) =
        match headerData, onRequestClose with 
        | Some h, Some onClick -> R.div [ClassName "modal-header"] [R.a [ClassName "btn btn-clear float-right"; onClick] []; header h] |> Some
        | Some h, None -> R.div [ClassName "modal-header"] [ header h] |> Some
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
    
    let private isOpen props =
        let getOpenValue =
            fun (prop: IHTMLProp) ->
                match prop with
                | :? ModalOptional as opt ->
                    match opt with
                    | Open o -> Some o                        
                    | _ -> None
                | _ -> None
        props
        |> List.tryPick getOpenValue
        |> Option.defaultValue false 
    
    let private sizeClass =
        function
        | Small -> ClassName "modal-sm"                        
        | Medium -> ClassName "modal-md"                        
        | Large -> ClassName "modal-lg"                        
    
    let size (props: HTMLProps) =
         let getSize =
             fun (prop: IHTMLProp) ->
                 match prop with
                 | :? ModalOptional as opt ->
                     match opt with
                     | Size s -> Some s                        
                     | _ -> None
                 | _ -> None
         props
         |> List.tryPick getSize
         |> Option.defaultValue Medium 
    
    let modal (modal: Modal) =
        let props, children = modal
        let (Header header), (Body body), (Footer footer) = children
        let onRequestClose = onRequestClose props
        
        match isOpen props with 
        | true ->
            props
            |> Unmerged
            |> addProp (ClassName "modal active")
            |> addProp (props |> size |> sizeClass)
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
        | false -> null
    
    let addProps (p : HTMLProps) (modal: Modal) =
        let props, children = modal
        let props: HTMLProps = 
            props
            |> Unmerged
            |> addProps p
            |> merge
            
        props, children
    
    let setOpen newValue (modal: Modal)  =
        let props, children = modal
        let props: HTMLProps = 
            props
            |> Unmerged
            |> addProp (Open newValue)
            |> merge
            
        props, children
    
    let setOnRequestClose newValue (modal: Modal)  =
        let props, children = modal
        let props: HTMLProps = 
            props
            |> Unmerged
            |> addProp (OnRequestClose newValue)
            |> merge
            
        props, children
        

    