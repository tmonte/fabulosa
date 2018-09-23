namespace Fabulosa

[<RequireQualifiedAccess>]
module Table =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module Column =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let ƒ (column: T) =
            let props, children = column
            props.HTMLProps
            |> R.td <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module TitleColumn =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let ƒ (titleColumn: T) =
            let props, children = titleColumn
            props.HTMLProps
            |> R.th <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Row =

        [<RequireQualifiedAccess>]
        type Active = bool

        [<RequireQualifiedAccess>]
        type Props =
            { Active: Active
              HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Child =
        | Column of Column.T
        | TitleColumn of TitleColumn.T

        [<RequireQualifiedAccess>]
        type Children = Child list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.Active = false
              Props.HTMLProps = [] }

        let private active =
            function
            | true -> "active"
            | false -> ""
            >> ClassName

        let private columns =
            function
            | Child.Column column -> Column.ƒ column
            | Child.TitleColumn column -> TitleColumn.ƒ column

        let ƒ (row: T) =
            let props, children = row
            props.HTMLProps
            |> addProp (active props.Active)
            |> R.tr
            <| List.map columns children

    [<RequireQualifiedAccess>]
    module Head =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children = Row.T list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let ƒ (head: T) =
            let props, children = head
            props.HTMLProps
            |> R.thead
            <| List.map Row.ƒ children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Body =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children = Row.T list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let ƒ (body: T) =
            let props, children = body
            props.HTMLProps
            |> R.tbody
            <| List.map Row.ƒ children

        let render = ƒ

    [<RequireQualifiedAccess>]
    type Kind =
    | Striped
    | Hover
    | Unset

    [<RequireQualifiedAccess>]
    type Props =
        { Kind: Kind
          HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Child =
    | Head of Head.T
    | Body of Body.T

    [<RequireQualifiedAccess>]
    type Children = Child list

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.Kind = Kind.Unset
          Props.HTMLProps = [] }

    let private kind =
        function
        | Kind.Striped -> "table-striped"
        | Kind.Hover -> "table-hover"
        | Kind.Unset -> ""
        >> ClassName

    let private child =
        function
        | Child.Head head -> Head.ƒ head
        | Child.Body body -> Body.ƒ body

    let ƒ (table: T) =
        let props, children = table
        props.HTMLProps
        |> addProps
            [ ClassName "table"
              kind props.Kind ]
        |> R.table
        <| List.map child children

    let render = ƒ
