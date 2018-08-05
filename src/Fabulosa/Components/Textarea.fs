namespace Fabulosa

[<RequireQualifiedAccess>]
module Textarea =

    open ClassNames

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
        |> combineProps ["form-input"]
        |> R.textarea