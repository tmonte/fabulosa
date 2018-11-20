(*** hide ***)
module GridPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


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
(*** hide ***)
let render () =
    tryMount "grid-demo" def
    tryMount "row-gapless-demo" gapless
    tryMount "row-oneline-demo" oneline
    tryMount "column-demo" small
    tryMount "grid-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<GridChild>))
    tryMount "row-params-table"
        (PropTable.paramTable
            (Some typeof<GridRowOptional>)
            None
            (Some typeof<GridRowChild>))
    tryMount "column-params-table"
        (PropTable.paramTable
            (Some typeof<GridColumnOptional>)
            None
            None)
(**
<div id="grid">

<h2 class="s-title">Grid</h2>

A flexbox based responsive grid system with 12 columns.

#### Parameters

<div class="props-table" id="grid-params-table"></div>

#### Example

A simple grid with default settings.

<div class="demo" id="grid-demo"></div>

*)
(*** include: grid-sample ***)
(**

</div>

<div id="rows">

<h2 class="s-title">Rows</h2>

Rows are children of the grid.

#### Parameters

<div class="props-table" id="row-params-table"></div>

#### Example

Rows can be gapless or one-line. Scroll horizontally
on the second example to see how one-line works.

<div class="demo">
    <div id="row-gapless-demo"></div>
    <div id="row-oneline-demo"></div>
</div>

*)
(*** include: row-sample ***)
(**

</div>

<div id="columns">

<h2 class="s-title">Columns</h2>

Columns are children of the rows.

#### Parameters

<div class="props-table" id="column-params-table"></div>

#### Example

Columns can have different resposive sizes.
Resize horizontally to a very small size to
view the columns stack.

<div class="demo"><div id="column-demo"></div></div>

*)
(*** include: column-sample ***)
(**

</div>

*)