(*** hide ***)
module MenuPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa.Menu
open Fabulosa.Icon
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
open Fable.Import.React
                
(*** define: menu-default-sample ***)
let def =
    menu
        ([], Trigger ([], [ icon ([], Kind Menu) ]),
         [ Item [ R.a [] [ R.str "Links" ] ]
           Divider ([])
           Item [ R.a [] [ R.str "Link 1" ] ]
           Divider ([ Text "DIVIDER" ])
           Item [ R.a [] [ R.str "Link 2" ] ] ])
(*** hide ***)
let render () =
    tryMount "menu-default-demo" def
    tryMount "menu-params-table"
        (PropTable.paramTable
            None
            (Some typeof<MenuRequired>)
            (Some typeof<MenuChild>))
(**

<div id="menus">

<h2 class="s-title">Menus</h2>

Menus are vertical list of links or
buttons for actions and navigation.

The menu is rendered to its own container through
React Portals.

#### Parameters

<div class="props-table" id="menu-params-table"></div>

#### Example

A simple menu with default parametes.

<div class="demo" style="width: 50%" id="menu-default-demo"></div>

*)
(*** include: menu-default-sample ***)
(**

</div>

*)