module NavPage

open Fabulosa
open Fabulosa.Nav
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
                
(*** define: nav-default-sample ***)
let def =
    nav ([],
      [ Item ([], Text "Item One")
        Nav ([], [ Item ([], Text "Item One Nested") ])
        Item ([], Text "Item Two") ])
(*** hide ***)
let render () =
    tryMount "nav-default-demo" def
    tryMount "nav-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<NavChild>))
    tryMount "nav-item-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<FabulosaText>))
(**

<div id="navs">

<h2 class="s-title">Navs</h2>

Navs is the default component
for navigation lists

#### Parameters

<div class="props-table" id="nav-params-table"></div>

#### Item Parameters

<div class="props-table" id="nav-item-params-table"></div>

#### Example

The default nav component.

<div class="demo" style="width: 50%" id="nav-default-demo"></div>

*)
(*** include: nav-default-sample ***)
(**

</div>

*)