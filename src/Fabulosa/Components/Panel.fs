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
                header

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
        { Header: (ReactElement list) option
          Nav: (ReactElement list) option
          Body: (ReactElement list) option
          Footer: (ReactElement list) option }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let children =
        { Children.Header = None
          Children.Nav = None
          Children.Body = None
          Children.Footer = None }

    let private child kind =
        function
        | Some elements -> R.div [ ClassName ("panel-" + kind) ] elements
        | None -> R.ofOption None

    let ƒ (panel: T) =
        let props, children = panel
        props.HTMLProps
        |> addProp (ClassName "panel")
        |> R.div
        <| [ child "header" children.Header
             child "nav" children.Nav
             child "body" children.Body
             child "footer" children.Footer ]
