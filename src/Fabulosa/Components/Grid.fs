namespace Fabulosa

open Fable.Import.React
[<RequireQualifiedAccess>]
module Grid =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        HTMLProps = []
    }

    let ƒ props =
        props.HTMLProps
        |> combineProps ["container"]
        |> R.div

    let grid = ƒ

    [<RequireQualifiedAccess>]
    module Row =

        type Gapless = bool

        type OneLine = bool

        type Props = {
            Gapless: Gapless
            OneLine: OneLine
            HTMLProps: IHTMLProp list
        }

        let defaults = {
            Gapless = false
            OneLine = false
            HTMLProps = []
        }

        let gapless =
            function
            | true -> "col-gapless"
            | false -> ""

        let oneLine =
            function
            | true -> "col-oneline"
            | false -> ""

        let ƒ props =
            props.HTMLProps
            |> combineProps ["columns";
                gapless props.Gapless;
                oneLine props.OneLine]
            |> R.div

    let row = Row.ƒ

    [<RequireQualifiedAccess>]
    module Column =

        type Kind =
        | MLAuto
        | MRAuto
        | MXAuto
        | Unset

        type ColSize = int

        type SmallSize = ColSize

        type MediumSize = ColSize

        type LargeSize = ColSize

        type Props = {
            Kind: Kind
            Size: ColSize
            SmallSize: ColSize
            MediumSize: ColSize
            LargeSize: ColSize
            HTMLProps: IHTMLProp list
        }

        let kind =
            function
            | MLAuto -> "col-ml-auto"
            | MRAuto -> "col-mr-auto"
            | MXAuto -> "col-mx-auto"
            | Unset -> ""

        let size (size: ColSize) =
            match size with
            | n -> "col-" + string n

        let smallSize (size: SmallSize) =
            match size with
            | n -> "col-sm-" + string n

        let mediumSize (size: MediumSize) =
            match size with
            | n -> "col-md-" + string n

        let largeSize (size: LargeSize) =
            match size with
            | n -> "col-lg-" + string n

        let defaults = {
            Kind = Kind.Unset
            Size = 12
            SmallSize = 0
            MediumSize = 0
            LargeSize = 0
            HTMLProps = []
        }

        let ƒ props =
            props.HTMLProps
            |> combineProps ["column";
                kind props.Kind;
                size props.Size;
                smallSize props.SmallSize;
                mediumSize props.MediumSize;
                largeSize props.LargeSize]
            |> R.div
    let column = ƒ