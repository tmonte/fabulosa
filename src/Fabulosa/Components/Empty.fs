namespace Fabulosa

[<RequireQualifiedAccess>]
module Empty =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    module Icon =

        [<RequireQualifiedAccess>]
        type T = Icon.T

        let props = Icon.props

        let ƒ (icon: T) =
            R.div
                [ ClassName "empty-icon" ]
                [ Icon.ƒ { icon with Size = Icon.Size.X3 } ]

    [<RequireQualifiedAccess>]
    module Title =

        [<RequireQualifiedAccess>]
        type T = string

        let children: T = ""

        let ƒ (title: T) =
            R.p
                [ ClassName "empty-title h5" ]
                [ R.str title ]

    [<RequireQualifiedAccess>]
    module SubTitle =

        [<RequireQualifiedAccess>]
        type T = string

        let children: T = ""

        let ƒ (subTitle: T) =
            R.p
                [ ClassName "empty-subtitle" ]
                [ R.str subTitle ]

    [<RequireQualifiedAccess>]
    module Action =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let children: T = []

        let ƒ (action: T) =
            R.div
                [ ClassName "empty-action" ]
                action

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children =
        { Icon: Icon.T
          Title: Title.T
          SubTitle: SubTitle.T
          Action: Action.T }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let children =
        { Children.Icon = Icon.props
          Children.Title = Title.children
          Children.SubTitle = SubTitle.children
          Children.Action = Action.children }
          
    let ƒ (empty: T) =
        let props, children = empty
        props.HTMLProps
        |> addProp (ClassName "empty")
        |> R.div <|
        [ Icon.ƒ children.Icon
          Title.ƒ children.Title
          SubTitle.ƒ children.SubTitle
          Action.ƒ children.Action ]