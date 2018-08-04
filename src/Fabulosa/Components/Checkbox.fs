namespace Fabulosa

[<RequireQualifiedAccess>]
module Checkbox =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Alignment =
    | Inline
    | Unset

    type Props = {
        Alignment: Alignment
        HTMLProps: IHTMLProp list
    }
   
    let alignment =
        function
        | Alignment.Inline -> "form-inline"
        | Alignment.Unset -> ""

    let defaults = {
        Alignment = Alignment.Unset
        HTMLProps = []
    }

    let ƒ props label =
        let containerClasses = ["form-checkbox";
            alignment props.Alignment ] |> String.concat " "
        R.label [ClassName containerClasses] [
            R.input props.HTMLProps
            R.i [ClassName "form-icon"] []
            R.str label
        ]

    let checkbox = ƒ