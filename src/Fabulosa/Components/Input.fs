namespace Fabulosa

[<RequireQualifiedAccess>]
module Input =

    open ClassNames
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Size =
    | Small
    | Large
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        Size: Size
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.Size = Size.Unset
        Props.HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "input-sm"
        | Size.Large -> "input-lg"
        | Size.Unset -> ""

    let ƒ (props: Props) =
        props.HTMLProps
        |> combineProps ["form-input";
            size props.Size]
        |> R.input

    let input = ƒ

[<RequireQualifiedAccess>]
module IconInput =

    open ReactAPIExtensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Position =
    | Left
    | Right

    [<RequireQualifiedAccess>]
    type Props = {
        Position: Position
    }

    let defaults = {
        Props.Position = Position.Left
    }

    let position =
        function
        | Position.Left -> "has-icon-left"
        | Position.Right -> "has-icon-right"

    let ƒ (props: Props) (children: ReactElement list) =
        let containerClasses =
            [ position props.Position ]
            |> String.concat " "
        R.div [ClassName containerClasses] [
            children.[0]
            children.[1] |> appendClass ["form-icon"]
        ]
