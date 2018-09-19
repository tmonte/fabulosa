namespace Fabulosa

module Nav =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    module Item =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Href: string
              Text: string }

        let defaults =
            { Props.HTMLProps = []
              Props.Href = "#"
              Props.Text = "" }

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Child =
    | Item of Item.Props
    | Nav of Props * Child seq
              
    [<RequireQualifiedAccess>]
    type Children = Child seq

    let defaults =
        { Props.HTMLProps = [] }

    let rec ƒ (props: Props) (children: Children) =
        let renderChildren =
            function
            | Child.Item props ->
                R.li
                    [ ClassName "nav-item" ]
                    [ R.a
                        [ Href props.Href ]
                        [ R.str props.Text ] ]
            | Child.Nav (props, children) ->
                ƒ props children
        props.HTMLProps
        |> addProp (ClassName "nav")
        |> R.ul <| Seq.map renderChildren children