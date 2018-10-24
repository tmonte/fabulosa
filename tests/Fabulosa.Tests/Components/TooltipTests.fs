module TooltipTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect
open ReactNode

(*[<FTests>]
let tests =
    testList "Tooltip.Content" [
        test "renders with text" {
            let child =  R.str "Eine kleine narcht musik"
            
            Tooltip.Content.ƒ (Tooltip.props, Tooltip.Content.Children.Elements [ child ]) 
            |> ReactNode.unit
            |>! hasUniqueClass "tooltip"
            |> hasChild 1 (child |> ReactNode.unit)
        }
        
        test "renders different positions" {
            let child =  R.str "Eine kleine narcht musik"
            
            Tooltip.Content.ƒ ({ Tooltip.props with Orientation = Tooltip.Orientation.Top }, Tooltip.Content.Children.Elements [ child ]) 
            |> ReactNode.unit
            |> hasUniqueClass "tooltip"
            
            Tooltip.Content.ƒ ({ Tooltip.props with Orientation = Tooltip.Orientation.Right }, Tooltip.Content.Children.Elements [ child ]) 
            |> ReactNode.unit
            |> hasClass "tooltip tooltip-right"
            
            Tooltip.Content.ƒ ({ Tooltip.props with Orientation = Tooltip.Orientation.Bottom }, Tooltip.Content.Children.Elements [ child ]) 
            |> ReactNode.unit
            |> hasClass "tooltip tooltip-bottom"

            Tooltip.Content.ƒ ({ Tooltip.props with Orientation = Tooltip.Orientation.Left }, Tooltip.Content.Children.Elements [ child ]) 
            |> ReactNode.unit
            |> hasClass "tooltip tooltip-left"
            
        }
    ]*)