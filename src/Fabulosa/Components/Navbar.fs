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

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let ƒ (section: T) =
            let props, children = section
            props.HTMLProps
            |> addProp (ClassName "navbar-section")
            |> R.section <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Center =

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let ƒ (center: T) =
            let props, children = center
            props.HTMLProps
            |> addProp (ClassName "navbar-center")
            |> R.section <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    module Brand =

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let ƒ (brand: T) =
            let props, children = brand
            props.HTMLProps
            |> addProp (ClassName "navbar-brand")
            |> R.a <| children

        let render = ƒ

    [<RequireQualifiedAccess>]
    type Child =
    | Brand of Brand.T
    | Section of Section.T
    | Center of Center.T

    [<RequireQualifiedAccess>]
    type private Children = Child list

    let defaults =
        { Props.HTMLProps = [] }

    let private renderChild =
        function
        | Child.Brand (props, children) ->
            Brand.ƒ (props, children)
        | Child.Section (props, children) ->
            Section.ƒ (props, children)
        | Child.Center (props, children) ->
            Center.ƒ (props, children)

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let ƒ (navbar: T) =
        let props, children = navbar
        props.HTMLProps
        |> addProp (ClassName "navbar")
        |> R.header <| Seq.map renderChild children

    let render = ƒ
