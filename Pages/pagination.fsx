(*** hide ***)
module PaginationPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa
open Fabulosa.Pagination
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Fable.Import.JS
open Renderer
open Microsoft.FSharp.Core

(*** define: pagination-default-sample ***)
let pagCh = OnPageChanged (fun page -> console.log page)

let pages =
    seq { 1 .. 9 }
    |> Seq.map
         (fun n ->
            if n = 5 then Item ([ Active ], (pagCh, Value n), Text (string n))
            else Item ([], (pagCh, Value n), Text (string n)))
    |> Seq.toList

let def =
    pagination
        ([],
         Item ([], (pagCh, Value -2), Text "Prev")
         :: pages @ [ Item ([], (pagCh, Value -1), Text "Next") ])
(*** hide ***)
let render () =
    tryMount "pagination-default-demo" def
    tryMount "pagination-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<PaginationChild>))
    tryMount "pagination-item-params-table"
        (PropTable.paramTable
            (Some typeof<PaginationItemOptional>)
            (Some typeof<PaginationItemRequired>)
            None)
(**

<div id="pagination">

<h2 class="s-title">Pagination</h2>

The pagination component is fully customizable,
with props for active, disabled, and a callback
that gives you the clicked page

#### Parameters

<div class="props-table" id="pagination-params-table"></div>

#### Page Item

Page items are child elements for pagination

#### Parameters

<div class="props-table" id="pagination-item-params-table"></div>

#### Example

A simple pagination component that shows all pages.
If you want collapsed pages you can use the disabled prop.

<div class="demo" id="pagination-default-demo"></div>

*)
(*** include: pagination-default-sample ***)
(**

</div>

*)