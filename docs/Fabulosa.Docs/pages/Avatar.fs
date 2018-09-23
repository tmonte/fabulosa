module AvatarPage

open Fabulosa
open Fabulosa.Docs
open Fable.Import.React
module R = Fable.Helpers.React
open Renderer

(*** define: avatar-initial-sample ***)
let avatar =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA" }
(*** define: avatar-source-sample ***)
let source =
    Avatar.ƒ
        { Avatar.props with
            Source = "assets/avatar-1.png" }
(*** define: avatar-sizes-sample ***)
let extraSmall =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA"
            Size = Avatar.Size.ExtraSmall }
(*** hide ***)
let small =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA"
            Size = Avatar.Size.Small }

let medium =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA"
            Size = Avatar.Size.Medium }

let large =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA"
            Size = Avatar.Size.Large }

let extraLarge =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA"
            Size = Avatar.Size.ExtraLarge }
(*** define: avatar-kinds-sample ***)
let icon =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA"
            Kind = Avatar.Kind.Icon "assets/avatar-1.png" }

let presence =
    Avatar.ƒ
        { Avatar.props with
            Initial = "FA"
            Kind = Avatar.Kind.Presence Avatar.Presence.Online }
(*** hide ***)
let render () =
    tryMount "avatar-initial-demo" avatar
    tryMount "avatar-source-demo" source
    tryMount "avatar-xs-demo" extraSmall
    tryMount "avatar-sm-demo" small
    tryMount "avatar-md-demo" medium
    tryMount "avatar-lg-demo" large
    tryMount "avatar-xl-demo" extraLarge
    tryMount "avatar-icon-demo" icon
    tryMount "avatar-presence-demo" presence
    tryMount "avatar-props-table"
        (PropTable.propTable typeof<Avatar.Props> Avatar.props)
(**
<div id="avatars">

<h2 class="s-title">
    Avatars
</h2>

Avatars are user profile pictures.

</div>

<div id="avatar-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="avatar-props-table"></div>

</div>

<div id="avatar-initial">

<h3 class="s-title">
    Initial
</h3>

Avatars can have an Initial prop with name initials instead of images.

<div class="demo" id="avatar-initial-demo"></div>

*)

(*** include: avatar-initial-sample ***)

(**

</div>

<div id="avatar-source">

<h3 class="s-title">
    Source
</h3>

Avatars can also have a source image

<div class="demo" id="avatar-source-demo"></div>

*)

(*** include: avatar-source-sample ***)

(**

</div>

<div id="avatar-sizes">

<h3 class="s-title">
    Sizes
</h3>

Avatar can be ExtraSmall, Small, Medium, Large and ExtraLarge.

<div class="demo">
    <span id="avatar-xs-demo"></span>
    <span id="avatar-sm-demo"></span>
    <span id="avatar-md-demo"></span>
    <span id="avatar-lg-demo"></span>
    <span id="avatar-xl-demo"></span>
</div>

*)

(*** include: avatar-sizes-sample ***)

(**

</div>

<div id="avatar-kinds">

<h3 class="s-title">
    Kind
</h3>

Avatar can have kinds of Icon or Presence.

<div class="demo">
    <span id="avatar-icon-demo"></span>
    <span id="avatar-presence-demo"></span>
</div>

*)

(*** include: avatar-kinds-sample ***)

(**
</div>
*)