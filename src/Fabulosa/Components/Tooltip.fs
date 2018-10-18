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
            R.span [ ClassName "hover-container"; OnMouseEnter (onMouseEnter dispatch)(*; OnMouseLeave (onMouseLeave dispatch)*) ] [ (model.props model.state) ]
     
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
                 
        type State = {
            Style: HTMLAttr
            Hover: Hover
        }
               
        type HoverClass(refCallBack) =
            inherit PureComponent<Props, State>(refCallBack)
            do base.setInitState 
                { Style =  Style [Top (sprintf "%dpx" -9000); Left (sprintf "%dpx" -9000); Position "fixed"]
                  Hover = NotHovering }
                  
            let mutable targetElement = None
            let mutable tooltipElement = None  
            
            let bottomPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let horizontalCenter = target.Left + (target.Width / 2) - (tooltip.Width / 2)
                Style [Top (sprintf "%dpx" (target.Bottom));Left (sprintf "%dpx" horizontalCenter); Position "fixed"]
            
            let topPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let horizontalCenter = target.Left + (target.Width / 2) - (tooltip.Width / 2)
                Style [Top (sprintf "%dpx" (target.Top - tooltip.Height));Left (sprintf "%dpx" horizontalCenter); Position "fixed"]
                
            let leftPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let verticalCenter = target.Top + (target.Height / 2) - (tooltip.Height / 2)
                Style [Top (sprintf "%dpx" verticalCenter);Left (sprintf "%dpx" (target.Left - tooltip.Width)); Position "fixed"]
            
            let rightPosition (target: BoundingRect) (tooltip: BoundingRect) =
                let verticalCenter = target.Top + (target.Height / 2) - (tooltip.Height / 2)
                Style [Top (sprintf "%dpx" verticalCenter);Left (sprintf "%dpx" (target.Left + target.Width)); Position "fixed"]
                        
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
            
            override this.componentDidMount () = this.updatePosition ()
            member this.onMouseEnter (event: MouseEvent) = this.updatePosition ()
            member this.onMouseLeave (event: MouseEvent) = this.updatePosition ()
            member this.updateStyle style = this.setState { Style = style; Hover = this.state.Hover}
                
            member this.updatePosition () =
                let mapElements target tooltip = 
                    let style = calculatePosition target tooltip this.props.Orientation
                    this.updateStyle style
                    
                Option.map2 mapElements targetElement tooltipElement
                |> ignore 
             
            override this.render() =
                let updatedProps =
                    props.HTMLProps
                    |> addProp this.state.Style
            
                R.fragment [] 
                    [ R.span [Ref setTargetRef; OnMouseEnter this.onMouseEnter; OnMouseLeave this.onMouseLeave] 
                        [ R.str "Mein kinder von himmel"]
                      BaseTooltip.ƒ ( { Ref = setTooltipRef; HTMLProps = updatedProps; Orientation = props.Orientation}, this.props.TooltipContent)
                      |> Portal.ƒ "tooltip-yo" ]
                        
        let hoverTooltip props = React.ofType<HoverClass, Props, _> props []
            
        let build baseTooltipƒ (tooltip: T) =
            hoverTooltip { props with TooltipContent = TooltipContent.Text "I'm a tooltip"}

        let ƒ tooltip = build BaseTooltip.ƒ tooltip
        
        
    