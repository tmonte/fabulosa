[<RequireQualifiedAccess>]
module Table

open ClassNames
module R = Fable.Helpers.React

type Kind =
| Striped
| Hover

type Prop =
| Kind of Kind

let propToClass =
    function
    | Kind Striped -> "table-striped"
    | Kind Hover -> "table-hover"

let table tableProps =
    ["table"] @ List.map propToClass tableProps |> addClassesToProps >> R.table

let thead = R.thead

let tbody = R.tbody

[<RequireQualifiedAccess>]
module Row =

    type Kind =
    | Active

    type Prop =
    | Kind of Kind

    let propToClass =
        function
        | Kind Active -> "active"

let tr rowProps =
    List.map Row.propToClass rowProps
    |> addClassesToProps >>
    R.tr
let td = R.td

let th = R.th