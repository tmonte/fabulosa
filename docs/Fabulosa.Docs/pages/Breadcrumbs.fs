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
    Breadcrumb.ƒ
        ({ Breadcrumb.props with
             HTMLProps = [ Id "breadcrumb-id" ] },
         [ (Breadcrumb.Item.props,
            Breadcrumb.Item.Children.Text "Just Text")
           (Breadcrumb.Item.props,
            Breadcrumb.Item.Children.Link
              { Href = "#"; Text = "Ubuntu" })
           (Breadcrumb.Item.props,
            Breadcrumb.Item.Children.Elements
              [ R.str "Hey: "
                R.a [] [ R.str "Jude" ] ]) ])

(*** hide ***)
let render () =
    tryMount "breadcrumbs-demo" breadcrumb
    tryMount "breadcrumbs-props-table"
        (PropTable.propTable typeof<Breadcrumb.Props> Breadcrumb.props)
    tryMount "breadcrumb-items-props-table"
        (PropTable.propTable typeof<Breadcrumb.Item.Props> Breadcrumb.Item.props)
(**

<div id="breadcrumbs">

<h2 class="s-title">
    Breadcrumbs
</h2>

Breadcrumbs are used as navigational hierarchies to indicate current location.

</div>

<div id="breadcrumb-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="breadcrumbs-props-table"></div>

</div>

<div id="breadcrumb-example">

<h3 class="s-title">
    Example
</h3>

<div id="breadcrumbs-demo"> </div>
*)

(*** include: breadcrumbs-demo ***)

(**

</div>

<div id="breadcrumb-items">

<h3 class="s-title">
    Breadcrumb Item Props
</h3>

<div class="props-table" id="breadcrumb-items-props-table"></div>

</div>

*)
