namespace Fabulosa

[<RequireQualifiedAccess>]
module Grid =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module Column =

        [<RequireQualifiedAccess>]
        type Kind =
        | MLAuto
        | MRAuto
        | MXAuto
        | Unset

        [<RequireQualifiedAccess>]
        type ColSize = int

        [<RequireQualifiedAccess>]
        type XSSize = int

        [<RequireQualifiedAccess>]
        type SMSize = ColSize

        [<RequireQualifiedAccess>]
        type MDSize = ColSize

        [<RequireQualifiedAccess>]
        type LGSize = ColSize

        [<RequireQualifiedAccess>]
        type XLSize = ColSize

        [<RequireQualifiedAccess>]
        type Props =
            { Kind: Kind
              Size: ColSize
              XSSize: ColSize
              SMSize: ColSize
              MDSize: ColSize
              LGSize: ColSize
              XLSize: ColSize
              HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type Column = Props * ReactElement list

        [<RequireQualifiedAccess>]
        type Columns = Column list

        let private kind =
            function
            | Kind.MLAuto -> "col-ml-auto"
            | Kind.MRAuto -> "col-mr-auto"
            | Kind.MXAuto -> "col-mx-auto"
            | Kind.Unset -> ""
            >> ClassName

        let private size =
            function
            | n -> "col-" + string n
            >> ClassName

        let private xsSize =
            function
            | n -> "col-xs-" + string n
            >> ClassName

        let private smSize =
            function
            | n -> "col-sm-" + string n
            >> ClassName

        let private mdSize =
            function
            | n -> "col-md-" + string n
            >> ClassName

        let private lgSize =
            function
            | n -> "col-lg-" + string n
            >> ClassName

        let private xlSize =
             function
             | n -> "col-xl-" + string n
             >> ClassName

        let defaults =
            { Props.Kind = Kind.Unset
              Props.Size = 12
              Props.XSSize = 0
              Props.SMSize = 0
              Props.MDSize = 0
              Props.LGSize = 0
              Props.XLSize = 0
              Props.HTMLProps = [] }

        let ƒ (props: Props) (children: ReactElement list) =
            props.HTMLProps
            |> addProps
                [ ClassName "column"
                  kind props.Kind
                  size props.Size
                  xsSize props.XSSize
                  smSize props.SMSize
                  mdSize props.MDSize
                  lgSize props.LGSize
                  xlSize props.XLSize ]
            |> R.div <| children

    [<RequireQualifiedAccess>]
    module Row =

        [<RequireQualifiedAccess>]
        type Gapless = bool

        [<RequireQualifiedAccess>]
        type OneLine = bool

        [<RequireQualifiedAccess>]
        type Props =
            { Gapless: Gapless
              OneLine: OneLine
              HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type Row = Props * Column.Columns

        [<RequireQualifiedAccess>]
        type Rows = Row list

        let defaults = {
            Props.Gapless = false
            Props.OneLine = false
            Props.HTMLProps = []
        }

        let private gapless =
            function
            | true -> "col-gapless"
            | false -> ""
            >> ClassName

        let private oneLine =
            function
            | true -> "col-oneline"
            | false -> ""
            >> ClassName

        let ƒ (props: Props) (children: Column.Columns) =
            props.HTMLProps
            |> addProps
                [ ClassName "columns"
                  gapless props.Gapless
                  oneLine props.OneLine ]
            |> R.div
            <| Seq.map
                (fun (columnProps, columnChildren) ->
                    Column.ƒ columnProps columnChildren) children

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: HTMLProps
    }

    let defaults = {
        Props.HTMLProps = []
    }

    let ƒ (props: Props) (children: Row.Rows) =
        props.HTMLProps
        |> addProp (ClassName "container")
        |> R.div
        <| Seq.map
            (fun (rowProps, rowChildren) ->
                Row.ƒ rowProps rowChildren) children

    let render = ƒ