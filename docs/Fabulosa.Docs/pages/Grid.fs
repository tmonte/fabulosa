module GridPage

open Fabulosa.Grid
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Renderer

let style = P.Style [P.Background "#f8f9fa"]
(*** define: grid-sample ***)
let def =
    grid ([],
      [ Row ([],
          [ Column ([ Size 4 ], [ R.div [ style ] [ R.str "First Column" ] ])
            Column ([ Size 8 ], [ R.div [ style ] [ R.str "Second Column" ] ]) ]) ])
(*** define: row-sample ***)
let gapless =
    grid ([],
      [ Row ([ Gapless ],
          [ Column ([ Size 4 ], [ R.div [ style ] [ R.str "First Column" ] ])
            Column ([ Size 8 ], [ R.div [ style ] [ R.str "Second Column" ] ]) ]) ])

let oneline =
    grid ([],
      [ Row ([ OneLine ],
          [ Column ([ Size 4 ],[ R.div [ style ] [ R.str "First Column" ] ])
            Column ([ Size 12 ], [ R.div [ style ] [ R.str "Second Column" ] ]) ]) ])
(*** define: column-sample ***)
let small =
    grid ([],
      [ Row ([],
          [ Column ([ Size 4; SMSize 12 ], [ R.div [ style ] [ R.str "First Column" ] ])
            Column ([ Size 8; SMSize 12 ], [ R.div [ style ] [ R.str "Second Column" ] ]) ]) ])
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

<div class="props-table" id="grid-props-table"></div>

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

<div class="props-table" id="row-props-table"></div>

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

<div class="props-table" id="column-props-table"></div>

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
    tryMount "grid-demo" def
    tryMount "row-gapless-demo" gapless
    tryMount "row-oneline-demo" oneline
    tryMount "column-demo" small
    //tryMount "grid-props-table" (PropTable.propTable typeof<Grid.Props> [])
    //tryMount "row-props-table" (PropTable.propTable typeof<Row.Props> Row.props)
    //tryMount "column-props-table" (PropTable.propTable typeof<Column.Props> Column.props)