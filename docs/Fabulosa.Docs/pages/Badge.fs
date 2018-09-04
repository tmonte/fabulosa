module BadgePage

open Fabulosa
open Fabulosa.Docs
open Renderer
module R = Fable.Helpers.React
open R.Props

(*** define: badge-div-span-sample ***)
let divBadge =
    Badge.ƒ
        { Badge.defaults with
            Kind = Badge.Kind.Div
                ([], [R.str "Text"])
            Badge = 1 }

let spanBadge =
    Badge.ƒ
        { Badge.defaults with
            Kind = Badge.Kind.Span
                ([], [R.str "Text"])
            Badge = 2 }
(*** define: badge-button-avatar-sample ***)
let buttonBadge =
    Badge.ƒ
        { Badge.defaults with
            Kind = Badge.Kind.Button
                (Button.defaults, [R.str "Button"])
            Badge = 3 }

let avatarBadge =
    Badge.ƒ
        { Badge.defaults with
            Kind = Badge.Kind.Avatar
                { Avatar.defaults with
                    Source = "assets/avatar-1.png"
                    Size = Avatar.Size.Large }
            Badge = 4 }
(*** hide ***)
let render () =
    tryMount "badge-div-demo" divBadge
    tryMount "badge-span-demo" spanBadge
    tryMount "badge-button-demo" buttonBadge
    tryMount "badge-avatar-demo" avatarBadge
    tryMount "badge-props-table" (PropTable.propTable typeof<Badge.Props> Badge.defaults)
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

<div id="badge-props-table"></div>

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