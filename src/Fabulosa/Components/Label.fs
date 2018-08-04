namespace Fabulosa

[<RequireQualifiedAccess>]
module Label =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    type Prop = {
        Size: Size
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Size = Size.Unset
        HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "input-sm"
        | Size.Large -> "input-lg"
        | Size.Unset -> ""

    let ƒ props label =
        props.HTMLProps
        |> combineProps["form-label";
            size props.Size]
        |> R.label
        <| [R.str label]

    let label = ƒ