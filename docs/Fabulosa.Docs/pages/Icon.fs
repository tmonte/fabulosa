module IconPage

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
    tryMount "icon-props-table"
        (PropTable.unionPropTable typeof<IconRequired>)
    tryMount "icon-optional-props-table"
        (PropTable.unionPropTable typeof<IconOptional>)

(**

<div id="icon">

<h2 class="s-title">
    Icons
</h2>

Icons are single-element, responsive
and pure CSS icons. You can include
spectre-icons.css located in the dist
folder to your web <head> to have these CSS icons.

</div>

<div id="kind">

<h3 class="s-title">
    Kind
</h3>

The kind of the icon to be shown

<div class="demo" id="icon-demo"></div>

*)

(*** include: icon-sample ***)

(**

</div>

<div id="size">

<h3 class="s-title">
    Size
</h3>

Icons can have doubled, tripled, or quadrupled sizes

<div class="demo" id="icon-size-demo"></div>

*)

(*** include: icon-size-sample ***)

(**

</div>

<div id="icon-props">

<h3 class="s-title">
    Required props
</h3>

<div class="props-table" id="icon-props-table"></div>

</div>

<div id="icon-optional-props">

<h3 class="s-title">
    Optional props
</h3>

<div class="props-table" id="icon-optional-props-table"></div>

</div>

*)
