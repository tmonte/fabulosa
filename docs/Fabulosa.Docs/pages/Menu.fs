module MenuPage

open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Microsoft.FSharp.Core
open Elmish
open Elmish.React

type Model =
    { Position: int * int
      Open: bool }

type Msg =
| Click of int * int

let init() : Model =
    { Position = 0, 0
      Open = false }

let update (msg:Msg) (model:Model) =
    match msg with
    | Click (x, y) ->
        { model with
            Position = x, y
            Open = not model.Open }

let updatePos dispatch pos =
    dispatch (Click pos)
    
(*** define: menu-default-sample ***)
let menu model dispatch =
    Menu.ƒ
        { Menu.defaults with
            Open = model.Open
            Position = model.Position
            GetPosition = updatePos dispatch
            Trigger = Button.defaults, "Menu" }
        [ Menu.Child.Item [ R.a [] [ R.str "Links" ] ]
          Menu.Child.Divider (Menu.Divider.Text "DIVIDER")
          Menu.Child.Item [ R.a [] [ R.str "Link 1" ] ]
          Menu.Child.Item [ R.a [] [ R.str "Link 2" ] ] ]
(*** hide ***)
let render () =
    Program.mkSimple init update menu
    |> Program.withReact "menu-default-demo"
    |> Program.withConsoleTrace
    |> Program.run

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