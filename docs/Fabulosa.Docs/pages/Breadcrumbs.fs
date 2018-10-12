module BreadcrumbPage

open Fabulosa.Breadcrumb
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: breadcrumbs-demo ***)
let element =
    breadcrumb ([],
        [ BreadcrumbText ([], { Text = "Text" })
          BreadcrumbLink ([], { Href = "#" }, { Text = "Link" })
          BreadcrumbElements ([], [ R.str "Hey: "; R.a [] [ R.str "Jude" ] ]) ])
(*** hide ***)
let render () =
    tryMount "breadcrumbs-demo" element
    //tryMount "breadcrumbs-props-table"
    //    (PropTable.propTable typeof<BreadcrumbProps> Breadcrumb.props)
    //tryMount "breadcrumb-items-props-table"
        //(PropTable.propTable typeof<BreadcrumbItemProps> BreadcrumbItem.props)
(**
<div id="breadcrumbs">

<h2 class="s-title">Breadcrumbs</h2>

Breadcrumbs are used as navigational
hierarchies to indicate current location.

</div>

<div id="breadcrumb-props">
    <h3 class="s-title">Props</h3>
    <div class="props-table" id="breadcrumbs-props-table"></div>
</div>

<div id="breadcrumb-example">
<h3 class="s-title">Example</h3>
<div id="breadcrumbs-demo"></div>
</div>
*)

(*** include: breadcrumbs-demo ***)

(**
<div id="breadcrumb-items">
<h3 class="s-title">Breadcrumb Item Props</h3>
<div class="props-table" id="breadcrumb-items-props-table"></div>
</div>
*)