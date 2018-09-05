module TablePage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open Fable.Import.React
open Renderer

let bolso = [
    Table.Column.ƒ Table.Column.defaults [R.str "Jair"]
    Table.Column.ƒ Table.Column.defaults [R.str "Bolsonaro"]
    Table.Column.ƒ Table.Column.defaults [R.str "melhorjair@procanada.com"]
]
let michel = [
    Table.Column.ƒ Table.Column.defaults [R.str "Michel"]
    Table.Column.ƒ Table.Column.defaults [R.str "Temer"]
    Table.Column.ƒ Table.Column.defaults [R.str "temquemanterissoai@vampiro.com"]
]
(*** define: table-columns-sample ***)
let donald = [
    Table.Column.ƒ Table.Column.defaults [R.str "Donald"]
    Table.Column.ƒ Table.Column.defaults [R.str "Trump"]
    Table.Column.ƒ Table.Column.defaults [R.str "wall@mexico.com"]
]

let titleColumns = [
    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "First Name"]
    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Last Name"]
    Table.TitleColumn.ƒ Table.TitleColumn.defaults [R.str "Email"]
]
(*** define: table-row-sample ***)
let row = Table.Row.ƒ Table.Row.defaults []
(*** hide ***)
let createRow columns =
    Table.Row.ƒ Table.Row.defaults columns
let titleRow =
    Table.Row.ƒ Table.Row.defaults titleColumns
(*** define: table-row-active-sample ***)
let active =
    Table.Row.ƒ {
        Table.Row.defaults with
            Active = true
    } []
(*** define: table-head-sample ***)
let head = Table.Head.ƒ Table.Head.defaults [titleRow]
(*** define: table-body-sample ***)
let body = Table.Body.ƒ Table.Body.defaults [
    createRow bolso
    createRow michel
    createRow donald
]
(*** define: table-default-sample ***)
let table = Table.ƒ Table.defaults [head; body]
(*** define: table-striped-sample ***)
let striped =
    Table.ƒ {
        Table.defaults with
            Kind = Table.Kind.Striped
    } [ head; body]
(*** define: table-hover-sample ***)
let hover =
    Table.ƒ {
        Table.defaults with
            Kind = Table.Kind.Hover
    } [head; body]
(*** hide ***)
let render () =
    tryMount "table-default-demo" table
    tryMount "table-striped-demo" striped
    tryMount "table-hover-demo" hover
    tryMount "table-props-table" (PropTable.propTable typeof<Table.Props> Table.defaults)
    tryMount "table-row-props-table" (PropTable.propTable typeof<Table.Row.Props> Table.Row.defaults)
(**

<div id="table">

<h2 class="s-title">
    Table
</h2>

Tables include default styles
for tables and data sets.

</div>

<div id="table-props">

<h3 class="s-title">
    Props
</h3>

<div class="props-table" id="table-props-table"></div>

</div>

<div id="table-default">

<h3 class="s-title">
    Default
</h3>

The default table

<div class="demo" id="table-default-demo"></div>

*)

(*** include: table-default-sample ***)

(**

</div>

<div id="table-striped">

<h3 class="s-title">
    Striped
</h3>

The striped table

<div class="demo" id="table-striped-demo"></div>

*)

(*** include: table-striped-sample ***)

(**

</div>

<div id="table-hover">

<h3 class="s-title">
    Hover
</h3>

The hover table

<div class="demo" id="table-hover-demo"></div>

*)

(*** include: table-hover-sample ***)

(**

</div>

<div id="table-head">

<h3 class="s-title">
    Head
</h3>

The table head

*)

(*** include: table-head-sample ***)

(**

</div>

<div id="table-head">

<h3 class="s-title">
    Body
</h3>

The table body

*)

(*** include: table-body-sample ***)

(**

</div>

<div id="table-row">

<h3 class="s-title">
    Row
</h3>

The table row

</div>

<div id="table-row-props">

<h3 class="s-title">
    Row Props
</h3>

<div class="props-table" id="table-row-props-table"></div>

</div>

<div id="table-row-default">

<h3 class="s-title">
    Row default
</h3>

The default setting for rows

*)

(*** include: table-row-sample ***)

(**

</div>

<div id="table-row-active">

<h3 class="s-title">
    Row Active
</h3>

Rows can be acivated

*)

(*** include: table-row-active-sample ***)

(**

</div>

<div id="table-column">

<h3 class="s-title">
    Columns
</h3>

Columns can be title columns or default

*)

(*** include: table-columns-sample ***)

(**

</div>

*)