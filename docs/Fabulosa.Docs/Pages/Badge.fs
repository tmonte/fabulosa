module BadgePage

open Fabulosa
open Fabulosa.Badge
open Fabulosa.Avatar
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React

(*** define: badge-div-span-sample ***)
let div = badge ([], Value 1, Div ([], [ R.str "Text" ]))

let span = badge ([], Value 2, Span ([], [ R.str "Text" ]))
(*** define: badge-button-avatar-sample ***)
let button = badge ([], Value 3, Button ([], [ R.str "Button" ]))

let avatar = badge ([], Value 4, Avatar ([ Size Large ], Url "Assets/avatar-1.png"))
(*** hide ***)
let render () =
    tryMount "badge-div-demo" div
    tryMount "badge-span-demo" span
    tryMount "badge-button-demo" button
    tryMount "badge-avatar-demo" avatar
    tryMount "badge-params-table"
        (PropTable.paramTable
            None
            (Some typeof<FabulosaValue>)
            (Some typeof<BadgeChildren>))
(**

<div id="badges">

<h2 class="s-title">Badge</h2>

Badges are often used as unread number indicators.

#### Parameters

<div class="props-table" id="badge-params-table"></div>

#### Div or Span

Badges can be rendered on top
of div or span elements.

<div class="demo">
    <span id="badge-div-demo"></span>
    <br/>
    <span id="badge-span-demo"></span>
</div>

*)
(*** include: badge-div-span-sample ***)
(**

#### Button or Avatar

Badges can also be render on top
of the button and avatar components.

<div class="demo">
    <span id="badge-button-demo"></span>
    <span id="badge-avatar-demo"></span>
</div>

*)
(*** include: badge-button-avatar-sample ***)
(**

</div>

*)