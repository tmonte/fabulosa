namespace Fabulosa
open Fable.Import.React

open Fable.Import
module R = Fable.Helpers.React
open R.Props
open Extensions.Fable.Helpers.React.Props
open Fable.Core
open Fable.Helpers

module Tooltip =
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React
    
    type Orientation =
        | Top
        | Bottom
        | Right
        | Left 

    type TooltipChildren = 
        | Children of ReactElement list
        
    type TooltipContent =
        | Content of ReactElement list
    
    type TooltipOptional =
        | Orientation of Orientation
        interface IHTMLProp
    
    type Tooltip = HTMLProps * TooltipContent * TooltipChildren       
    
    let private pick fn (props:HTMLProps) =
                props |> List.tryPick fn
    
    let private orientation =
        fun (prop: IHTMLProp) ->
            match prop with
            | :? TooltipOptional as opt ->
                let (Orientation ori) = opt
                Some ori
            | _ -> None
        |> pick
        
    [<RequireQualifiedAccess>]
    module BaseTooltip =
        module R = Fable.Helpers.React
        open R.Props
        open Fable.Import.React
        open Fabulosa.Extensions
        open Extensions.Fable.Helpers.React.Props
        open Fable.Import
        
        type BaseTooltipOptional =
            | Reference of (Browser.Element -> unit)
            | Orientation of Orientation
            interface IHTMLProp
        
        type BaseTooltip = HTMLProps * TooltipContent
                  
        let positionClassName =
            function
                | Some Orientation.Top -> "tooltip-top"
                | Some Orientation.Right -> "tooltip-right"
                | Some Orientation.Bottom -> "tooltip-bottom"
                | Some Orientation.Left -> "tooltip-left"
                | None -> ""
                >> ClassName    
                      
        let private reference =
            fun (prop: IHTMLProp) ->
                match prop with
                | :? BaseTooltipOptional as opt ->
                    match opt with
                    | Reference ref ->
                        Some (Prop.Ref ref)
                    | _ -> None
                | _ -> None
            |> pick      
      
        let baseTooltip (tooltip: BaseTooltip) =
            let opt, TooltipContent.Content children = tooltip
            
            opt
            |> Unmerged
            |> addProps 
                [ ClassName "fab-tooltip"  
                  positionClassName (orientation opt) ]
            |> addPropOpt (opt |> reference|> Option.map (fun x -> upcast x))
            |> merge
            |> R.span
            <| children
        

    [<RequireQualifiedAccess>]
    module Hover =
        module R = Fable.Helpers.React
        open Extensions
        open R.Props
        open Fable.Import.React
        open Extensions.Fable.Helpers.React.Props
        open Fable.Import
        open Fabulosa
        open Fabulosa.Extensions
                
        type Hover = 
        | Hovering
        | NotHovering   
        
        type Props =
            { HTMLProps: IHTMLProp list
              Orientation: Orientation 
              TooltipContent: TooltipContent }
                 
        type State = { Style: HTMLAttr; Hover: Hover }
               
        type HoverClass(refCallBack) =
            inherit PureComponent<Props, State>(refCallBack)
            do base.setInitState { Style =  Style []; Hover = NotHovering }
                  
            let mutable targetElement = None
            let mutable tooltipElement = None  

            let padding = 10                
                
            let bottomPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let horizontalCenter = target.Left + (target.Width / 2) - (tooltip.Width / 2)
                Style [Top (sprintf "%dpx" (target.Bottom + padding));Left (sprintf "%dpx" horizontalCenter)]
            
            let topPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let horizontalCenter = target.Left + (target.Width / 2) - (tooltip.Width / 2)
                Style [Top (sprintf "%dpx" (target.Top - tooltip.Height - padding));Left (sprintf "%dpx" horizontalCenter)]
                
            let leftPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let verticalCenter = target.Top + (target.Height / 2) - (tooltip.Height / 2)
                Style [Top (sprintf "%dpx" verticalCenter);Left (sprintf "%dpx" (target.Left - tooltip.Width - padding))]
            
            let rightPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let verticalCenter = target.Top + (target.Height / 2) - (tooltip.Height / 2)
                Style [Top (sprintf "%dpx" verticalCenter); Left (sprintf "%dpx" (target.Left + target.Width + padding))]
                                        
            let calculatePosition (targetElement:Browser.Element) (tooltipElement:Browser.Element) orientation =
                let targetBoundaries = targetElement.getBoundingClientRect() |> BoundingRect.OfClientRectType
                let tooltipBoundaries = tooltipElement.getBoundingClientRect() |> BoundingRect.OfClientRectType
                match orientation with 
                 | Orientation.Top -> topPosition
                 | Orientation.Right -> rightPosition
                 | Orientation.Bottom -> bottomPosition
                 | Orientation.Left -> leftPosition
                <|| (targetBoundaries, tooltipBoundaries)
                
            let setTooltipRef (ref:Browser.Element) = 
                if ref <> null then
                    tooltipElement <- Some ref
            
            let setTargetRef (ref:Browser.Element) = 
                if ref <> null then
                    targetElement <- Some ref
            
            let hoverClassName =
                function
                | Hovering -> ClassName "tooltip-active" :> IHTMLProp |> Some 
                | NotHovering -> None
                        
            override this.componentDidMount () = this.updatePosition NotHovering
            
            member this.onMouseEnter (event: MouseEvent) =
                this.updatePosition Hovering
                
            member this.onMouseLeave (event: MouseEvent) =
                this.updatePosition NotHovering
                
            member this.updatePosition hover =
                let mapElements target tooltip = 
                    let style = calculatePosition target tooltip this.props.Orientation
                    this.setState { Style = style; Hover = hover}
                    
                Option.map2 mapElements targetElement tooltipElement
                |> ignore 
                
            member this.basetooltipProps () =
                Unmerged this.props.HTMLProps
                |> addPropOpt (hoverClassName this.state.Hover)
                |> addProps 
                  [ this.state.Style
                    Ref setTooltipRef
                    Orientation this.props.Orientation ]
                |> merge
            
            override this.render() =
                R.fragment [] 
                    [ R.span [Ref setTargetRef; OnMouseEnter this.onMouseEnter; OnMouseLeave this.onMouseLeave; Style [Display "inline-block"]] this.children
                      BaseTooltip.baseTooltip (this.basetooltipProps(), this.props.TooltipContent)
                      |> Portal.ƒ "tooltip-portal"]
            
    let tooltip (tooltip: Tooltip) =
        let opt, content, TooltipChildren.Children children = tooltip
        
        let tooltipOrientation =
            match orientation opt with 
            | Some s -> s
            | None -> Orientation.Top
                                    
        React.ofType<Hover.HoverClass, Hover.Props, _> 
            { HTMLProps = opt
              Orientation = tooltipOrientation
              TooltipContent = content }
            children
      