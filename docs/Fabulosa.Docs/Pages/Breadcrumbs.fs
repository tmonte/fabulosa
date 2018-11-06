module BreadcrumbPage

open Fabulosa
open Fabulosa.Breadcrumb
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: breadcrumbs-demo ***)
let element =
    breadcrumb ([],
        [ String ([], Text "Text")
          Link ([], Href "#", Text "Link")
          Elements ([], [ R.str "Hey: "; R.a [] [ R.str "Jude" ] ]) ])
(*** hide ***)
type Definition = Breadcrumb of Breadcrumb

let render () =
    tryMount "breadcrumbs-demo" element
    tryMount "breadcrumb-definition"
        (PropTable.definition typeof<Definition>)
    tryMount "breadcrumb-params-table"
        (PropTable.paramTable
            (Some typeof<BreadcrumbOptional>)
            None
            (Some typeof<BreadcrumbChildren>))
    tryMount "breadcrumb-string-params-table"
        (PropTable.paramTable
            (Some typeof<BreadcrumbTextOptional>)
            None
            (Some typeof<FabulosaText>))
    tryMount "breadcrumb-link-params-table"
        (PropTable.paramTable
            None
            (Some typeof<BreadcrumbLinkRequired>)
            (Some typeof<FabulosaText>))
(**

<div id="breadcrumbs">

<h2 class="s-title">
    Breadcrumbs
</h2>

Breadcrumbs are used as navigational
hierarchies to indicate current location.

<div id="breadcrumb-def">

<h4>Definition</h4>

<div id="breadcrumb-definition"></div>

</div>

</div>

<div id="breadcrumb-params">

<h3 class="s-title">
    Parameters
</h3>

<div class="props-table" id="breadcrumb-params-table"></div>

</div>

<div id="breadcrumb-string-params">

<h3 class="s-title">
    Text Parameters
</h3>

<div class="props-table" id="breadcrumb-string-params-table"></div>

</div>

<div id="breadcrumb-link-params">

<h3 class="s-title">
    Link Parameters
</h3>

<div class="props-table" id="breadcrumb-link-params-table"></div>

</div>

<div id="breadcrumb-example">

<h3 class="s-title">
    Example
</h3>

<div id="breadcrumbs-demo"></div>

</div>

*)

(*** include: breadcrumbs-demo ***)