module GridPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props

(*** define: grid-sample ***)
let grid =
    Grid.ƒ Grid.defaults [
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 4
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "First Column"]
            ]
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 8
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "Second Column"]
            ]
        ]
    ]
(*** define: row-sample ***)
let gapless =
    Grid.ƒ Grid.defaults [
        Grid.Row.ƒ {
            Grid.Row.defaults with
                Gapless = true
        } [
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 4
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "First Column"]
            ]
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 8
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "Second Column"]
            ]
        ]
    ]

let oneline =
    Grid.ƒ Grid.defaults [
        Grid.Row.ƒ {
            Grid.Row.defaults with
                OneLine = true
        } [
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 4
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "First Column"]
            ]
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 12
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "Second Column"]
            ]
        ]
    ]
(*** define: column-sample ***)
let small =
    Grid.ƒ Grid.defaults [
        Grid.Row.ƒ Grid.Row.defaults [
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 4
                    SMSize = 12
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "First Column"]
            ]
            Grid.Column.ƒ {
                Grid.Column.defaults with
                    Size = 8
                    SMSize = 12
            } [
                R.div [Style [Background "#f8f9fa"]] [R.str "Second Column"]
            ]
        ]
    ]
(**

<div id="grid">

<h2 class="s-title">
    Grid
</h2>

A flexbox based responsive grid system with 12 columns.

</div>

<div id="grid-props">

<h3 class="s-title">
    Props
</h3>

<div id="grid-props-table"></div>

</div>

<div id="grid-sample">

<h3 class="s-title">
    Default
</h3>

The default setting for grid

<div class="demo" id="grid-demo"></div>

*)

(*** include: grid-sample ***)

(**

</div>

<div id="rows">

<h3 class="s-title">
    Rows
</h3>

Rows can be Gapless and OneLine

<div id="row-props-table"></div>

<div class="demo">
    <div id="row-gapless-demo"></div>
    <div id="row-oneline-demo"></div>
</div>

*)

(*** include: row-sample ***)

(**

</div>

<div id="columns">

<h3 class="s-title">
    Columns
</h3>

Columns can have different resposive sizes (Resize the page to view different sizes)

<div id="column-props-table"></div>

<div class="demo">
    <div id="column-demo"></div>
</div>

*)

(*** include: column-sample ***)

(**

</div>

*)

(*** hide ***)
let render () =
    Renderer.tryMount "grid-demo" grid
    Renderer.tryMount "row-gapless-demo" gapless
    Renderer.tryMount "row-oneline-demo" oneline
    Renderer.tryMount "column-demo" small
    Renderer.tryMount "grid-props-table" (PropTable.propTable typeof<Grid.Props> Grid.defaults)
    Renderer.tryMount "row-props-table" (PropTable.propTable typeof<Grid.Row.Props> Grid.Row.defaults)
    Renderer.tryMount "column-props-table" (PropTable.propTable typeof<Grid.Column.Props> Grid.Column.defaults)