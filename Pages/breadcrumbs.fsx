(*** hide ***)
module BreadcrumbPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


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
let render () =
    tryMount "breadcrumbs-demo" element
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

<h2 class="s-title">Breadcrumbs</h2>

Breadcrumbs are used as navigational
hierarchies to indicate current location.

#### Parameters

<div class="props-table" id="breadcrumb-params-table"></div>

#### Text Parameters

<div class="props-table" id="breadcrumb-string-params-table"></div>

#### Link Parameters

<div class="props-table" id="breadcrumb-link-params-table"></div>

#### Example

A breadcrumb with different kinds of children

<div class="demo" id="breadcrumbs-demo"></div>

*)
(*** include: breadcrumbs-demo ***)
(**

</div>

*)