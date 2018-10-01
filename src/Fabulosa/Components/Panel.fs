namespace Fabulosa

[<RequireQualifiedAccess>]
module Panel =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module Header =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (header: T) =
            R.div
                [ ClassName "panel-header" ]
                [ R.div [ ClassName "panel-title h6"] header ]

    [<RequireQualifiedAccess>]
    module Nav =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (nav: T) =
            R.div
                [ ClassName "panel-nav" ]
                nav

    [<RequireQualifiedAccess>]
    module Body =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (body: T) =
            R.div
                [ ClassName "panel-body" ]
                body

    [<RequireQualifiedAccess>]
    module Footer =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (footer: T) =
            R.div
                [ ClassName "panel-footer" ]
                footer

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children =
        { Header: Header.T option
          Nav: Nav.T option
          Body: Body.T option
          Footer: Footer.T option }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let children =
        { Children.Header = None
          Children.Nav = None
          Children.Body = None
          Children.Footer = None }

    let private child render =
        function
        | Some elements ->
            render elements
        | None -> R.ofOption None

    let ƒ (panel: T) =
        let props, children = panel
        props.HTMLProps
        |> addProp (ClassName "panel")
        |> R.div
        <| [ child Header.ƒ children.Header
             child Nav.ƒ children.Nav
             child Body.ƒ children.Body
             child Footer.ƒ children.Footer ]
