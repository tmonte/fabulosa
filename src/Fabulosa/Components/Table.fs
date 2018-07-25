[<RequireQualifiedAccess>]
module Table

open ClassNames
module R = Fable.Helpers.React

type Kind =
| Striped
| Hover

type Prop =
| Kind of Kind

let classes =
    function
    | Kind Striped -> "table-striped"
    | Kind Hover -> "table-hover"

let table tableProps htmlProps =
    let props = mergeClasses htmlProps <| ["table"] @ List.map classes tableProps
    R.table props

let thead = R.thead

let tbody = R.tbody

[<RequireQualifiedAccess>]
module Row =

    type Kind =
    | Active

    type Prop =
    | Kind of Kind

    let classes =
        function
        | Kind Active -> "active"

let tr rowProps htmlProps =
    let props = mergeClasses htmlProps <| List.map Row.classes rowProps
    R.tr props

let td = R.td

let th = R.th