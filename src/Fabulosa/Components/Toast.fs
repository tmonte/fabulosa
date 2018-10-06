namespace Fabulosa

[<RequireQualifiedAccess>]
module Toast =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children = string

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let ƒ (toast: T) =
        let props, children = toast
        props.HTMLProps
        |> addProp (ClassName "toast")
        |> R.div <| [ R.str children ]