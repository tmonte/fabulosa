﻿module NavbarPage

open Fabulosa.Navbar
open Fabulosa.Docs
module R = Fable.Helpers.React
open Fable.Import.React
open R.Props
open Renderer

(*** define: navbar-sample ***)
let def =
    navbar ([],
      [ Section ([],
          [ R.a [ ClassName "btn btn-link"] [ R.str "Left 1" ]
            R.a [ ClassName "btn btn-link"] [ R.str "Left 2" ] ])
        Center ([], [ R.a [ ClassName "btn btn-link"] [ R.str "Center" ] ])
        Section ([], [ R.a [ ClassName "btn btn-link"] [ R.str "Right" ] ]) ])
(*** hide ***)
let render () =
    tryMount "navbar-demo" def
    //tryMount "navbar-props-table"
        //(PropTable.propTable typeof<Navbar.Props> Navbar.props)
(**

<div id="navbar">

<h2 class="s-title">
    Navbar
</h2>

The navbar component can include
logo brand, nav links and buttons,
search box or any combination of
those elements. Each section with
the navbar-section class will be
evenly distributed in the container.

</div>

<div id="navbar-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="navbar-props-table"></div>

</div>

<div id="default">

<h3 class="s-title">
    Default
</h3>

A simple navbar

<div class="demo" id="navbar-demo"></div>

*)

(*** include: navbar-sample ***)

(**

</div>

*)