namespace Fabulosa

[<RequireQualifiedAccess>]
module Responsive =

    open ReactAPIExtensions
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    type Size =
    | XS
    | SM
    | MD
    | LG
    | XL
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Hide: Size
        Show: Size
    }

    let defaults = {
        Props.Hide = Size.Unset
        Props.Show = Size.Unset
    }

    let hide =
        function
        | Size.XS -> "hide-xs"
        | Size.SM -> "hide-sm"
        | Size.MD -> "hide-md"
        | Size.LG -> "hide-lg"
        | Size.XL -> "hide-xl"
        | Size.Unset -> ""

    let show =
        function
        | Size.XS -> "show-xs"
        | Size.SM -> "show-sm"
        | Size.MD -> "show-md"
        | Size.LG -> "show-lg"
        | Size.XL -> "show-xl"
        | Size.Unset -> ""

    let ƒ (props: Props) (element: ReactElement) =
        let responsiveProps = ["responsive"; hide props.Hide; show props.Show]
        let el = element |> appendClass responsiveProps
        Fable.Import.Browser.console.log el
        el


