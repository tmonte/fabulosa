namespace Fabulosa

[<RequireQualifiedAccess>]
module Switch =

    module R = Fable.Helpers.React
    open R.Props

    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        HTMLProps = []
    }

    let ƒ props text =
        R.label [ClassName "form-switch"] [
            R.input <| props.HTMLProps @ [Type "checkbox"]
            R.i [ClassName "form-icon"] []
            R.str text
        ]