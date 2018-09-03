namespace Fabulosa

[<RequireQualifiedAccess>]
module Navbar =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.HTMLProps = []
    }

    [<RequireQualifiedAccess>]
    module Header =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addClasses ["navbar"]
            |> R.header

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Section =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addClasses ["navbar-section"]
            |> R.section

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Center =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addClasses ["navbar-center"]
            |> R.section

    let center = Center.ƒ

    [<RequireQualifiedAccess>]
    module Brand =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addClasses ["navbar-brand"]
            |> R.a

        let render = ƒ
