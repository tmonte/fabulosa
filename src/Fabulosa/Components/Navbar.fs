namespace Fabulosa

[<RequireQualifiedAccess>]
module Navbar =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: IHTMLProp list }

    [<RequireQualifiedAccess>]
    module Section =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addProp (ClassName "navbar-section")
            |> R.section

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Center =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addProp (ClassName "navbar-center")
            |> R.section

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Brand =

        let ƒ (props: Props) =
            props.HTMLProps
            |> addProp (ClassName "navbar-brand")
            |> R.a

        let render = ƒ

    [<RequireQualifiedAccess>]
    type Child =
    | Brand of Props * ReactElement list
    | Section of Props * ReactElement list
    | Center of Props * ReactElement list

    [<RequireQualifiedAccess>]
    type Children = Child list

    let defaults =
        { Props.HTMLProps = [] }

    let renderChild =
        function
        | Child.Brand (props, children) -> Brand.ƒ props children
        | Child.Section (props, children) -> Section.ƒ props children
        | Child.Center (props, children) -> Center.ƒ props children

    let ƒ (props: Props) (children: Children) =
        props.HTMLProps
        |> addProp (ClassName "navbar")
        |> R.header <| Seq.map renderChild children

    let render = ƒ
