module TablePage

open Fabulosa
open Fabulosa.Table
open Fabulosa.Docs
module R = Fable.Helpers.React
open Fable.Import.React
open Renderer

let bolso =
    [ Column ([], [ R.str "Jair" ])
      Column ([], [ R.str "Bolsonaro" ])
      Column ([], [ R.str "melhorjair@procanada.com" ]) ]
let michel =
    [ Column ([], [ R.str "Michel" ])
      Column ([], [ R.str "Temer" ])
      Column ([], [ R.str "temquemanterissoai@vampiro.com" ]) ]
(*** define: table-columns-sample ***)
let donald =
    [ Column ([], [ R.str "Donald" ])
      Column ([], [ R.str "Trump" ])
      Column ([], [ R.str "wall@mexico.com" ]) ]

let titles =
    [ TitleColumn ([], [ R.str "First Name" ])
      TitleColumn ([], [ R.str "Last Name" ])
      TitleColumn ([], [ R.str "Email" ]) ]
(*** define: table-row-active-sample ***)
let active = Row ([ Active ], bolso)
(*** define: table-head-sample ***)
let head = Head ([], [ Row ([], titles) ])
(*** define: table-body-sample ***)
let body =
    Body ([],
       [ active
         Row ([], michel)
         Row ([], donald) ])
(*** define: table-default-sample ***)
let def = table ([], [head; body])
(*** define: table-striped-sample ***)
let striped = table ([ Kind Striped ], [ head; body ])
(*** define: table-hover-sample ***)
let hover = table ([ Kind Hover ], [ head; body ])
(*** hide ***)
let render () =
    tryMount "table-default-demo" def
    tryMount "table-striped-demo" striped
    tryMount "table-hover-demo" hover
    tryMount "table-params-table"
        (PropTable.paramTable
            (Some typeof<TableOptional>)
            None
            (Some typeof<TableChild>))
    tryMount "table-row-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<TableRowChild>))
(**

<div id="table">

<h2 class="s-title">Table</h2>

Tables include default styles
for tables and data sets.

#### Parameters

<div class="props-table" id="table-params-table"></div>

#### Row Parameters

<div class="props-table" id="table-row-params-table"></div>

#### Example

The default table.

<div class="demo" id="table-default-demo"></div>

*)
(*** include: table-default-sample ***)
(**

#### Striped

The striped table.

<div class="demo" id="table-striped-demo"></div>

*)
(*** include: table-striped-sample ***)
(**

#### Hover

The hover table.

<div class="demo" id="table-hover-demo"></div>

*)
(*** include: table-hover-sample ***)
(**

#### Head

The table head.

*)
(*** include: table-head-sample ***)
(**

#### Body

The table body.

*)
(*** include: table-body-sample ***)
(**

#### Row Active

Rows can have an active status.

*)
(*** include: table-row-active-sample ***)
(**

#### Columns

Columns can be title columns or default.

*)
(*** include: table-columns-sample ***)
(**

</div>

*)