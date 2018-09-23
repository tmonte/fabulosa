module BadgePage

open Fabulosa
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React

(*** define: badge-div-span-sample ***)
let div =
    Badge.ƒ
        ({ Badge.props with
             Badge = 1 },
         Badge.Child.Div
           ([], [ R.str "Text" ]))

let span =
    Badge.ƒ
        ({ Badge.props with
             Badge = 2 },
         Badge.Child.Span
           ([], [ R.str "Text" ]))
(*** define: badge-button-avatar-sample ***)
let button =
    Badge.ƒ
        ({ Badge.props with
             Badge = 3 },
         Badge.Child.Button
           (Button.props,
            [ R.str "Button" ]))

let avatar =
    Badge.ƒ
        ({ Badge.props with
             Badge = 4 },
         Badge.Child.Avatar
           { Avatar.props with
               Source = "assets/avatar-1.png"
               Size = Avatar.Size.Large })
(*** hide ***)
let render () =
    tryMount "badge-div-demo" div
    tryMount "badge-span-demo" span
    tryMount "badge-button-demo" button
    tryMount "badge-avatar-demo" avatar
    tryMount "badge-props-table"
        (PropTable.propTable typeof<Badge.Props> Badge.props)
(**
<div id="badges">

<h2 class="s-title">
    Badge
</h2>

Forms provide the most common control styles
used in forms, including input, textarea,
select, checkbox, radio and switch.

</div>

<div id="badge-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="badge-props-table"></div>

</div>

<div id="divorspan">

<h3 class="s-title">
    Div or Span
</h3>

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

</div>

<div id="buttonoravatar">

<h3 class="s-title">
    Button or Avatar
</h3>

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