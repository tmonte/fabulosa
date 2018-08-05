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

    type Props = {
        Size: Size
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Size = Size.Unset
        HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "select-sm"
        | Size.Large -> "select-lg"
        | Size.Unset -> ""

    let ƒ props =
        props.HTMLProps
        |> combineProps ["form-select";
            size props.Size]
        |> R.input

module Option =

    module R = Fable.Helpers.React
    open R.Props

    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        HTMLProps = []
    }

    let ƒ props =
        props.HTMLProps
        |> R.option

module OptionGroup =

    module R = Fable.Helpers.React
    open R.Props

    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        HTMLProps = []
    }

    let ƒ props =
        props.HTMLProps
        |> R.optgroup