namespace Fabulosa
open Fable.Import.React

module HoverContainer =
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React
    open Fabulosa.Extensions
    open Extensions.Fable.Helpers.React.Props
    open Fable.Import
    open R.ReactiveComponents

    type State =
       | Hovering of Browser.Element 
       | NotHovering
    
    [<RequireQualifiedAccess>]
    type Props = State -> ReactElement
 
    [<RequireQualifiedAccess>]
    type T = Props
    
    type Messages = 
    | MouseEnter of Browser.Element
    | MouseLeave
          
    let onMouseEnter dispatch (event: MouseEvent) =
        event.currentTarget 
        :?> Browser.Element
        |> MouseEnter
        |> dispatch 
    let onMouseLeave dispatch (event: MouseEvent) = dispatch MouseLeave 
          
    let props: Props = (fun _ -> R.fragment [] [])
           
    let private init (props: Props) = NotHovering

    let private update message state =
        match message with
        | MouseEnter element -> Hovering element
        | MouseLeave _ -> NotHovering
    
    let private view (model: Model<Props, State>) dispatch = 
            R.span [ OnMouseEnter (onMouseEnter dispatch)(*; OnMouseLeave (onMouseLeave dispatch)*) ] [ (model.props model.state) ]
     
    let ƒ (hover: T) =
        R.reactiveCom
            init
            update
            view
            ""
            hover
            []

open Fable.Import
module R = Fable.Helpers.React
open R.Props
open Extensions.Fable.Helpers.React.Props
open Fable.Core
open Fable.Helpers
open Fable.Import
open Fable.Import

module RefContainer =
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React
    open Fabulosa.Extensions
    open Extensions.Fable.Helpers.React.Props
    open Fable.Import
    open Fable.Import
    open R.ReactiveComponents

    type State = Browser.Element option 
       
    [<RequireQualifiedAccess>]
    type Props = State -> ReactElement
   
    [<RequireQualifiedAccess>]
    type T = Props
    
    type Messages = 
    | CaptureElement of Browser.Element
          
    let props: Props = (fun _ -> R.fragment [] [])
           
    let private init (props: Props) = None

    let private update message state =
            
        match message with
        | CaptureElement element -> Some element
    
    let private view (model: Model<Props, State>) dispatch = 
            R.span [ Ref (fun ref -> dispatch (CaptureElement ref)) ] [ (model.props model.state) ]
     
    let ƒ (menu: T) =
        let props = menu
        R.reactiveCom
            init
            update
            view
            ""
            props
            []

module Tooltip =
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React
    
    type Orientation =
        | Top
        | Bottom
        | Right
        | Left 
        
    type TooltipContent =
        | Text of string
        | Elements of ReactElement list
        
    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: IHTMLProp list
          Orientation: Orientation 
          TooltipContent: TooltipContent  }
    
    [<RequireQualifiedAccess>]
    type Children = ReactElement
    
    [<RequireQualifiedAccess>]
    type T = Props * Children       
    
    let props =
        { Props.HTMLProps = []
          Props.Orientation = Orientation.Top
          Props.TooltipContent = TooltipContent.Text "" }    
        
    [<RequireQualifiedAccess>]
    module BaseTooltip =
        module R = Fable.Helpers.React
        open R.Props
        open Fable.Import.React
        open Fabulosa.Extensions
        open Extensions.Fable.Helpers.React.Props
        open Fable.Import
        
        let positionClassName =
            function
                | Orientation.Top -> ""
                | Orientation.Right -> "tooltip-right"
                | Orientation.Bottom -> "tooltip-bottom"
                | Orientation.Left -> "tooltip-left"
                >> ClassName
        
        type Props = 
            { HTMLProps: IHTMLProp list
              Orientation: Orientation }
              
        type T = Props * TooltipContent  
        
        let props = 
            { HTMLProps = []
              Orientation = Orientation.Top }
                
        let ƒ (tooltipContent: T) =
            let props, children = tooltipContent
            let tooltipContent = 
                match children with 
                | Text t -> [ R.str t ]
                | Elements els -> els   
    
            props.HTMLProps
            |> addProps 
                [ ClassName "fab-tooltip"
                  positionClassName props.Orientation ]
            |> R.div
            <| match children with 
               | Text t -> [ R.str t ]
               | Elements els -> els   
        
    (*[<RequireQualifiedAccess>]
    module HoverTooltip =
        module R = Fable.Helpers.React
        open R.Props
        open Fable.Import.React
        open Fabulosa.Extensions
        open Extensions.Fable.Helpers.React.Props
        open Fable.Import
        open Fable.Import
        open Fabulosa
        
        let boundaries =
            function
            | HoverContainer.Hovering target -> target.getBoundingClientRect() |> BoundingRect.OfClientRectType |> Some
            | HoverContainer.NotHovering _ -> None
        
        let bottomPosition boundary =
            Style [Top (sprintf "%dpx" (boundary.Bottom)) ;Left (sprintf "%dpx" boundary.Left); Position "fixed"]
        
        let propsWithCoordinates (props:Props) hoverState =
            let position = hoverState |> boundaries
            
            position
            |> FSharp.Core.Option.map 
                (fun b ->
                    props.HTMLProps
                    |> addProp (bottomPosition b))
        
        let baseTooltip (props:Props) hoverState = 
            propsWithCoordinates props hoverState
            |> Option.map (fun htmlProps -> 
                { BaseTooltip.Props.HTMLProps = htmlProps
                  BaseTooltip.Props.Orientation = props.Orientation },
                props.TooltipContent
            )
        
        let build baseTooltipƒ (tooltip: T) =
            let props, children = tooltip 
            HoverContainer.ƒ (
                fun hoverState ->
                    R.fragment [] [
                        (baseTooltip props hoverState) 
                            |> Option.map
                                (fun tooltip ->
                                    X.reactive {
                                        RenderProp = 
                                            (fun getRef ->
                                                Browser.console.log("tooltip", getRef(), hoverState) 
                                                tooltip |> baseTooltipƒ )
                                             
                                    } |> Portal.ƒ "tooltip-yo")    
                            |> R.ofOption        
                        children
                    ]

                         
                )
        
        let ƒ tooltip = build BaseTooltip.ƒ tooltip*)

    [<RequireQualifiedAccess>]
    module AnotherHover =
        module R = Fable.Helpers.React
        open R.Props
        open Fable.Import.React
        open Fabulosa.Extensions
        open Extensions.Fable.Helpers.React.Props
        open Fable.Import
        open Fable.Import
        open Fabulosa
        
        
            
        //---------
        type GetElement = unit -> Browser.Element option
            
        type ReferProps = {
            HoverState: HoverContainer.State
            Tooltip: Props
        }
            
        type RefCompState = {
            Element: Browser.Element option
            Rendered: bool
        }
        
        type Refer(refCallBack) =
            inherit Component<ReferProps, RefCompState>(refCallBack)
            do base.setInitState { Element = None; Rendered = false }
            
            let mutable element = None  
            
            let setRef (ref:Browser.Element) = 
                if ref <> null then
                    let targetElement = ref
                    if targetElement <> null then 
                        element <- Some targetElement 
             
            let boundaries =
                function
                | HoverContainer.Hovering target -> target.getBoundingClientRect() |> BoundingRect.OfClientRectType |> Some
                | HoverContainer.NotHovering _ -> None
            
            let bottomPosition boundary =
                Style [Top (sprintf "%dpx" (boundary.Bottom)) ;Left (sprintf "%dpx" boundary.Left); Position "fixed"]
            
            let propsWithCoordinates (props:Props) hoverState =
                let position = hoverState |> boundaries
                
                position
                |> FSharp.Core.Option.map 
                    (fun b ->
                        props.HTMLProps
                        |> addProp (bottomPosition b))
            
            let baseTooltip (props:Props) hoverState = 
                propsWithCoordinates props hoverState
                |> Option.map (fun htmlProps -> 
                    { BaseTooltip.Props.HTMLProps = htmlProps
                      BaseTooltip.Props.Orientation = props.Orientation },
                    props.TooltipContent
                ) 
             
            override this.render() =
                R.fragment [] [
                    
                    
                ]
                
            
                R.span [ Ref setRef ] [ 
                    
                      |> Option.map (fun element -> 
                            Browser.console.log("render", element)
                            (baseTooltip this.props.Tooltip this.props.HoverState)
                            |> Option.map (
                                fun tooltip -> tooltip |> BaseTooltip.ƒ |> Portal.ƒ "tooltip-yo" )
                            )
                      |> Option.flatten
                      |> R.ofOption 
                ]
                    
                 
        let inline reactive props = React.ofType<Refer, ReferProps, _> props []
        
           
        //-----
        let build baseTooltipƒ (tooltip: T) =
            let props, children = tooltip 
            HoverContainer.ƒ (
                fun hoverState ->
                    R.fragment [] [
                        reactive {
                            HoverState = hoverState
                            Tooltip = props
                        }
                    
//                        (baseTooltip props hoverState) 
//                            |> Option.map
//                                (fun tooltip ->
// 
//                                    tooltip |> baseTooltipƒ 
//                                    |> Portal.ƒ "tooltip-yo")    
//                            |> R.ofOption        
                        children
                    ]

                         
                )
        
        let ƒ tooltip = build BaseTooltip.ƒ tooltip
        
        
    