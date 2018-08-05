namespace Fabulosa

[<RequireQualifiedAccess>]
module Select =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Size: Size
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Size = Size.Unset
        Props.HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "select-sm"
        | Size.Large -> "select-lg"
        | Size.Unset -> ""

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps ["form-select";
            size props.Size]
        |> R.input

module Option =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.HTMLProps = []
    }

    let ƒ (props: Props) =
        props.HTMLProps
        |> R.option

module OptionGroup =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.HTMLProps = []
    }

    let ƒ (props: Props) =
        props.HTMLProps
        |> R.optgroup