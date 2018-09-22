module BreadcrumbPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Fabulosa
open Renderer

(*** define: breadcrumbs-demo ***)
let breadcrumb =
    Breadcrumbs.ƒ { Breadcrumbs.props with HTMLProps = [Id "breadcrumb-id"] } [
        BreadcrumbItem.f BreadcrumbItem.props (BreadcrumbItem.Text "Just Text")
        BreadcrumbItem.f BreadcrumbItem.props (BreadcrumbItem.Link { Href = "ubuntu.com"; Text = "Ubuntu"})
        BreadcrumbItem.f BreadcrumbItem.props (BreadcrumbItem.Elements [R.str "Hey: "; R.a [] [R.str "Jude" ]])
    ]

(*** hide ***)
let render () =
    tryMount "breadcrumbs-demo" breadcrumb
    tryMount "breadcrumbs-props-table" (PropTable.propTable typeof<Breadcrumbs.Props> Breadcrumbs.props)
    tryMount "breadcrumb-items-props-table" (PropTable.propTable typeof<BreadcrumbItem.Props> BreadcrumbItem.props)
(**

<div id="breadcrumbs">

<h2 class="s-title">
    Breadcrumbs
</h2>

Breadcrumbs are used as navigational hierarchies to indicate current location.

</div>

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="breadcrumbs-props-table"></div>

<h3 class="s-title">
    Example
</h3>

<div id="breadcrumbs-demo"> </div>
*)

(*** include: breadcrumbs-demo ***)

(**

<h2 class="s-title">
    Breadcrumb Items
</h2>

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="breadcrumb-items-props-table"></div>
*)