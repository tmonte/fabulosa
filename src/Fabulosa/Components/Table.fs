namespace Fabulosa

[<RequireQualifiedAccess>]
module Table =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | Striped
    | Hover
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Kind: Kind
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Kind = Kind.Unset
        Props.HTMLProps = []
    }

    let kind =
        function
        | Kind.Striped -> "table-striped"
        | Kind.Hover -> "table-hover"
        | Kind.Unset -> ""

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps ["table";
            kind props.Kind]
        |> R.table

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

    let tr props =
        List.map Row.propToClass props
        |> combineProps
        >> R.tr
    let td = R.td

    let th = R.th