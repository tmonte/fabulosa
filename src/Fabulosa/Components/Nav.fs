namespace Fabulosa

module rec Nav =

    open Fabulosa.Extensions
    open Fable.Helpers.React.Props
    module R =  Fable.Helpers.React

    module Item =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Href: string
              Text: string }

        [<RequireQualifiedAccess>]
        type T = Props

        let props =
            { Props.HTMLProps = []
              Props.Href = "#"
              Props.Text = "" }

        let ƒ (item: T) =
            R.li
                [ ClassName "nav-item" ]
                [ R.a
                    [ Href item.Href ]
                    [ R.str item.Text ] ]

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Child =
    | Item of Item.Props
    | Nav of Props * Child seq
              
    [<RequireQualifiedAccess>]
    type Children = Child seq

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let private renderChildren =
        function
        | Child.Item props ->
            Item.ƒ props
        | Child.Nav (props, children) ->
            ƒ (props, children)

    let ƒ (nav: T) =
        let props, children = nav
        props.HTMLProps
        |> addProp (ClassName "nav")
        |> R.ul <| Seq.map renderChildren children