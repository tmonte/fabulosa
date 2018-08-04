namespace Fabulosa

[<RequireQualifiedAccess>]
module Navbar =

    module R = Fable.Helpers.React
    open R.Props
    open ClassNames

    type Props = {
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        HTMLProps = []
    }

    [<RequireQualifiedAccess>]
    module Header =

        let ƒ props =
            props.HTMLProps
            |> combineProps ["navbar"]
            |> R.header

    let header = Header.ƒ

    [<RequireQualifiedAccess>]
    module Section =

        let ƒ props =
            props.HTMLProps
            |> combineProps ["navbar-section"]
            |> R.section

    let section = Section.ƒ

    [<RequireQualifiedAccess>]
    module Center =

        let ƒ props =
            props.HTMLProps
            |> combineProps ["navbar-center"]
            |> R.section

    let center = Center.ƒ

    [<RequireQualifiedAccess>]
    module Brand =

        let ƒ props =
            props.HTMLProps
            |> combineProps ["navbar-brand"]
            |> R.a

    let brand = Brand.ƒ
