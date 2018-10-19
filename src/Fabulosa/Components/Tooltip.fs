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
        
    type TooltipRequired = 
        Content of ReactElement list
    
    type TooltipChildren = Target of ReactElement list
    
    type TooltipOptional =
        | Orientation of Orientation
        interface IHTMLProp
    
    type Tooltip = HTMLProps * TooltipRequired * TooltipChildren       
    
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
              Ref: Browser.Element -> unit  
              Orientation: Orientation }
              
        type T = Props * TooltipContent  
        
        let props = 
            { HTMLProps = []
              Ref = fun _ -> ()  
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
                  Ref props.Ref  
                  positionClassName props.Orientation ]
            |> R.span
            <| match children with 
               | Text t -> [ R.str t ]
               | Elements els -> els   
        

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
                 
        type State = { Style: HTMLAttr }
               
        type HoverClass(refCallBack) =
            inherit PureComponent<Props, State>(refCallBack)
            do base.setInitState { Style =  Style [] }
                  
            let mutable targetElement = None
            let mutable tooltipElement = None  
            
            let display =
                function 
                | Hovering -> Opacity "1"
                | NotHovering -> Opacity "0" 
    
            let bottomPosition (target: BoundingRect) (tooltip: BoundingRect) hover =
                let horizontalCenter = target.Left + (target.Width / 2) - (tooltip.Width / 2)
                Style [Top (sprintf "%dpx" (target.Bottom));Left (sprintf "%dpx" horizontalCenter); Position "fixed"; display hover]
            
            let topPosition (target: BoundingRect) (tooltip: BoundingRect) hover =
                let horizontalCenter = target.Left + (target.Width / 2) - (tooltip.Width / 2)
                Style [Top (sprintf "%dpx" (target.Top - tooltip.Height));Left (sprintf "%dpx" horizontalCenter); Position "fixed"; display hover]
                
            let leftPosition (target: BoundingRect) (tooltip: BoundingRect) hover =
                let verticalCenter = target.Top + (target.Height / 2) - (tooltip.Height / 2)
                Style [Top (sprintf "%dpx" verticalCenter);Left (sprintf "%dpx" (target.Left - tooltip.Width)); Position "fixed"; display hover]
            
            let rightPosition (target: BoundingRect) (tooltip: BoundingRect) hover =
                let verticalCenter = target.Top + (target.Height / 2) - (tooltip.Height / 2)
                Style [Top (sprintf "%dpx" verticalCenter);Left (sprintf "%dpx" (target.Left + target.Width)); Position "fixed"; display hover]
                                        
            let calculatePosition (targetElement:Browser.Element) (tooltipElement:Browser.Element) orientation hover =
                let targetBoundaries = targetElement.getBoundingClientRect() |> BoundingRect.OfClientRectType
                let tooltipBoundaries = tooltipElement.getBoundingClientRect() |> BoundingRect.OfClientRectType
                match orientation with 
                 | Orientation.Top -> topPosition
                 | Orientation.Right -> rightPosition
                 | Orientation.Bottom -> bottomPosition
                 | Orientation.Left -> leftPosition
                <||| (targetBoundaries, tooltipBoundaries, hover)
                
            let setTooltipRef (ref:Browser.Element) = 
                if ref <> null then
                    tooltipElement <- Some ref
            
            let setTargetRef (ref:Browser.Element) = 
                if ref <> null then
                    targetElement <- Some ref
                        
            override this.componentDidMount () = this.updatePosition NotHovering
            
            member this.onMouseEnter (event: MouseEvent) =
                this.updatePosition Hovering
                
            member this.onMouseLeave (event: MouseEvent) =
                this.updatePosition NotHovering
                
            member this.updatePosition hover =
                let mapElements target tooltip = 
                    let style = calculatePosition target tooltip this.props.Orientation hover
                    this.setState { Style = style;}
                    
                Option.map2 mapElements targetElement tooltipElement
                |> ignore 
                
            member this.basetooltipProps () =
                  props.HTMLProps
                  |> addProp this.state.Style    
            
            override this.render() =
                let updatedProps =
                    props.HTMLProps
                    |> addProp this.state.Style
            
                R.fragment [] 
                    [ R.span [Ref setTargetRef; OnMouseEnter this.onMouseEnter; OnMouseLeave this.onMouseLeave] this.children
                      BaseTooltip.ƒ ( { Ref = setTooltipRef; HTMLProps = this.basetooltipProps(); Orientation = props.Orientation}, this.props.TooltipContent)
                      |> Portal.ƒ "tooltip-portal"]

    let private pick fn (props:HTMLProps) =
            props |> List.tryPick fn

    let private orientation =
        fun (prop: IHTMLProp) ->
            match prop with
            | :? TooltipOptional as opt ->
                match opt with
                | Orientation ori ->
                    Some (ori)
                | _ -> None
            | _ -> None
        |> pick
            
    let tooltip (tooltip: Tooltip) =
        let opt, TooltipRequired.Content content, TooltipChildren.Target children = tooltip
        
        let tooltipOrientation =
            match orientation opt with 
            | Some s -> s
            | None -> Orientation.Top
                                    
        React.ofType<Hover.HoverClass, Props, _> 
            { HTMLProps = opt
              Orientation = tooltipOrientation
              TooltipContent = TooltipContent.Elements content }
            children
      