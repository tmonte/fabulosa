namespace Fabulosa

[<RequireQualifiedAccess>]
module Form =

    [<RequireQualifiedAccess>]
    module Group =

        open ClassNames
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
            |> addClasses ["form-group"]
            |> R.div

        let render = ƒ