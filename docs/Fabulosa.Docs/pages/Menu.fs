module MenuPage

open Fabulosa.Menu
open Renderer
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
                
(*** define: menu-default-sample ***)
let def =
    menu
        ([], Trigger ([], [ R.str "text" ]),
         [ Item [ R.a [] [ R.str "Links" ] ]
           Divider ([])
           Item [ R.a [] [ R.str "Link 1" ] ]
           Item [ R.a [] [ R.str "Link 2" ] ] ])
(*** hide ***)
let render () =
    tryMount "menu-default-demo" def

(**

<div id="menus">

<h2 class="s-title">
    Menus
</h2>

Menus are vertical list of links or
buttons for actions and navigation.

</div>

<div id="menu-default">

<h3 class="s-title">
    Default
</h3>

The default menu.

<div class="demo" style="width: 50%" id="menu-default-demo"></div>

*)

(*** include: menu-default-sample ***)

(**

</div>

*)