module TooltipTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect
open ReactNode
open Fabulosa.Tooltip
open Fabulosa.Tooltip.BaseTooltip

[<Tests>]
let tests =
    testList "BaseTooltip" [
        test "renders with child" {
            let child =  R.str "Pele >>> Maradona"
            
            baseTooltip ([], Content  [child])
            |> ReactNode.unit
            |>! hasClass "fab-tooltip tooltip-top"
            |> hasChild 1 (child |> ReactNode.unit)
        }
        
        test "renders different positions" {
            let content = Content [ R.str "Maradona > Messi" ]
            
            baseTooltip ([BaseOrientation Top], content) 
            |> ReactNode.unit
            |> hasClass "fab-tooltip tooltip-top"
            
            baseTooltip ([BaseOrientation Bottom], content) 
            |> ReactNode.unit
            |> hasClass "fab-tooltip tooltip-bottom"
            
            baseTooltip ([BaseOrientation Left], content) 
            |> ReactNode.unit
            |> hasClass "fab-tooltip tooltip-left"
            
            baseTooltip ([BaseOrientation Right], content) 
            |> ReactNode.unit
            |> hasClass "fab-tooltip tooltip-right"
        }
    ]