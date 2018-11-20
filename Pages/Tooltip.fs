module TooltipPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer
open Fabulosa.Grid
open Fabulosa.Button
open Fabulosa.Tooltip

let style = Style [Background "#f8f9fa"]

(*** define: tooltip-sample ***)
let demo = 
    let tooltipExample orientation =   
        let tooltipText = sprintf "%A" orientation  
        let buttonText = sprintf "%A tooltip" orientation  
        Column ([ Grid.Size 3 ], [
                tooltip ([Orientation orientation], Content [R.str tooltipText], Children [ button ([ Kind Primary ], [ R.str buttonText ]) ] )
            ])
            
    grid ([],
          [ Row ([],
              [ tooltipExample Orientation.Left
                tooltipExample Orientation.Top
                tooltipExample Orientation.Bottom
                tooltipExample Orientation.Right ]) ])
(*** hide ***)

let render () =
    tryMount "tooltip-demo" demo
(**

<div id="tooltip">

<h2 class="s-title">Tooltips</h2>

Tooltips provide context information labels that appear on hover and focus.

#### Example

<div class="demo" id="tooltip-demo"></div>

*)
(*** include: tooltip-sample ***)
(**

</div>

*)
