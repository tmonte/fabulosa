(*** hide ***)
module IconPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa.Icon
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
open Fable.Import.React

(*** define: icon-sample ***)
let def = icon ([], Kind Download)
(*** define: icon-size-sample ***)
let x4 = icon ([ Size X4 ], Kind Upload)
(*** hide ***)
let render () =
    tryMount "icon-demo" def
    tryMount "icon-size-demo" x4
    tryMount "icon-params-table"
        (PropTable.paramTable
            (Some typeof<IconOptional>)
            (Some typeof<IconRequired>)
            None)

(**

<div id="icon">

<h2 class="s-title">Icons</h2>

Icons are single-element, responsive
and pure CSS icons. You can include
spectre-icons.css located in the dist
folder to your web <head> to have these CSS icons.

#### Parameters

<div class="props-table" id="icon-params-table"></div>

#### Kind

The kind of the icon to be shown

<div class="demo" id="icon-demo"></div>

*)
(*** include: icon-sample ***)
(**

#### Size

Icons can have doubled, tripled, or quadrupled sizes

<div class="demo" id="icon-size-demo"></div>

*)
(*** include: icon-size-sample ***)
(**

</div>

*)
