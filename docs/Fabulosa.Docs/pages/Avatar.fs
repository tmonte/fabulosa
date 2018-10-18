module AvatarPage

open Fabulosa.Avatar
open Fabulosa.Docs
open Fable.Import.React
module R = Fable.Helpers.React
open Renderer

(*** define: avatar-initial-sample ***)
let def = avatar ([], Initial "FA")
(*** define: avatar-source-sample ***)
let source = avatar ([], Url "assets/avatar-1.png")
(*** define: avatar-sizes-sample ***)
let extraSmall = avatar ([ Size ExtraSmall ], Initial "FA")
(*** hide ***)
let small = avatar ([ Size Small ], Initial "FA")

let medium = avatar ([], Initial "FA")

let large = avatar ([ Size Large ], Initial "FA")

let extraLarge = avatar ([ Size ExtraLarge ], Initial "FA")
(*** define: avatar-presence-sample ***)
let presence = avatar ([ Presence Online ], Url "assets/avatar-1.png")
(*** hide ***)
let render () =
    tryMount "avatar-initial-demo" def
    tryMount "avatar-source-demo" source
    tryMount "avatar-xs-demo" extraSmall
    tryMount "avatar-sm-demo" small
    tryMount "avatar-md-demo" medium
    tryMount "avatar-lg-demo" large
    tryMount "avatar-xl-demo" extraLarge
    tryMount "avatar-presence-demo" presence
    tryMount "avatar-props-table"
        (PropTable.unionPropTable typeof<AvatarChildren>)
    tryMount "avatar-optional-props-table"
        (PropTable.unionPropTable typeof<AvatarOptional>)
(**
<div id="avatars">

<h2 class="s-title">
    Avatars
</h2>

Avatars are user profile pictures.

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

<div id="avatar-presence">

<h3 class="s-title">
    Presence
</h3>

Avatar can have a presence indicator.

<div class="demo">
    <span id="avatar-presence-demo"></span>
</div>

*)

(*** include: avatar-presence-sample ***)

(**

</div>

<div id="avatar-optional-props">

<h3 class="s-title">
    Optional props
</h3>

<div class="props-table" id="avatar-optional-props-table"></div>

</div>

<div id="avatar-props">

<h3 class="s-title">
    Child options
</h3>

<div class="props-table" id="avatar-props-table"></div>

</div>

*)