namespace Fabulosa

[<RequireQualifiedAccess>]
module Radio =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Inline = bool

    type props = {
        Inline: Inline
        HTMLProps: IHTMLProp list
    }

    let inlineRadio =
        function
        | true -> "form-inline"
        | false -> ""

    let input props htmlProps label =
        let containerClass = ["form-radio";
            inlineRadio props.Inline] |> String.concat " "
        R.label [ClassName containerClass] [
            R.input <| [Type "radio"] @ htmlProps
            R.i [ClassName "form-icon"] []
            R.str label
        ]