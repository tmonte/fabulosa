﻿namespace Fabulosa

type GridRow<'Row> = GridRow of 'Row

type GridColumn<'Column> = GridColumn of 'Column

[<RequireQualifiedAccess>]
module GridColumn =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    [<RequireQualifiedAccess>]
    type Kind =
    | MLAuto
    | MRAuto
    | MXAuto
    | Unset

    [<RequireQualifiedAccess>]
    type private ColSize = int

    [<RequireQualifiedAccess>]
    type private XSSize = int

    [<RequireQualifiedAccess>]
    type private SMSize = ColSize

    [<RequireQualifiedAccess>]
    type private MDSize = ColSize

    [<RequireQualifiedAccess>]
    type private LGSize = ColSize

    [<RequireQualifiedAccess>]
    type private XLSize = ColSize

    [<RequireQualifiedAccess>]
    type Props =
        { Kind: Kind
          Size: ColSize
          XSSize: ColSize
          SMSize: ColSize
          MDSize: ColSize
          LGSize: ColSize
          XLSize: ColSize
          HTMLProps: P.HTMLProps }

    [<RequireQualifiedAccess>]
    type T = Props * ReactElement list
    
    let private kind =
        function
        | Kind.MLAuto -> "col-ml-auto"
        | Kind.MRAuto -> "col-mr-auto"
        | Kind.MXAuto -> "col-mx-auto"
        | Kind.Unset -> ""
        >> P.ClassName

    let private size =
        function
        | n -> "col-" + string n
        >> P.ClassName

    let private xsSize =
        function
        | n -> "col-xs-" + string n
        >> P.ClassName

    let private smSize =
        function
        | n -> "col-sm-" + string n
        >> P.ClassName

    let private mdSize =
        function
        | n -> "col-md-" + string n
        >> P.ClassName

    let private lgSize =
        function
        | n -> "col-lg-" + string n
        >> P.ClassName

    let private xlSize =
         function
         | n -> "col-xl-" + string n
         >> P.ClassName

    let props =
        { Props.Kind = Kind.Unset
          Props.Size = 12
          Props.XSSize = 0
          Props.SMSize = 0
          Props.MDSize = 0
          Props.LGSize = 0
          Props.XLSize = 0
          Props.HTMLProps = [] }

    let build (column: T) =
        let props, children = column
        props.HTMLProps
        |> P.addProps
            [ P.ClassName "column"
              kind props.Kind
              size props.Size
              xsSize props.XSSize
              smSize props.SMSize
              mdSize props.MDSize
              lgSize props.LGSize
              xlSize props.XLSize ]
        |> R.div <| children

    let ƒ = build

[<RequireQualifiedAccess>]
module GridRow =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props


    [<RequireQualifiedAccess>]
    type private Gapless = bool

    [<RequireQualifiedAccess>]
    type private OneLine = bool

    [<RequireQualifiedAccess>]
    type Props =
        { Gapless: Gapless
          OneLine: OneLine
          HTMLProps: P.HTMLProps }

    [<RequireQualifiedAccess>]
    type T<'Column> = Props * GridColumn<'Column> list

    let props =
        { Props.Gapless = false
          Props.OneLine = false
          Props.HTMLProps = [] }

    let private gapless =
        function
        | true -> "col-gapless"
        | false -> ""
        >> P.ClassName

    let private oneLine =
        function
        | true -> "col-oneline"
        | false -> ""
        >> P.ClassName

    let build columnƒ (row: T<'Column>) =
        let props, children = row
        props.HTMLProps
        |> P.addProps
            [ P.ClassName "columns"
              gapless props.Gapless
              oneLine props.OneLine ]
        |> R.div
        <| Seq.map
            (fun (GridColumn column) -> columnƒ column)
            children

    let ƒ = build GridColumn.ƒ



[<RequireQualifiedAccess>]
module Grid =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: P.HTMLProps }

    [<RequireQualifiedAccess>]
    type T<'Row> = Props * GridRow<'Row> list
    let props =
        { Props.HTMLProps = [] }

    let build rowƒ (grid: T<'Row>) =
        let props, children = grid
        props.HTMLProps
        |> P.addProp (P.ClassName "container")
        |> R.div
        <| Seq.map
            (fun (GridRow row) -> rowƒ row)
            children

    let ƒ = build GridRow.ƒ
    