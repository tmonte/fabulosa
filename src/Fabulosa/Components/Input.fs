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

    type Prop = {
        Size: Size
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Size = Size.Unset
        HTMLProps = []
    }

    let size =
        function
        | Size.Small -> "input-sm"
        | Size.Large -> "input-lg"
        | Size.Unset -> ""

    let ƒ props =
        props.HTMLProps
        |> combineProps ["form-input";
            size props.Size]
        |> R.input

    let input = ƒ

[<RequireQualifiedAccess>]
module IconInput =

    open ClassNames
    open ReactAPIExtensions
    open Fable.Import.React
    module R = Fable.Helpers.React

    [<RequireQualifiedAccess>]
    type Position =
    | Left
    | Right

    type Props = {
        Position: Position
    }

    let defaults = {
        Position = Position.Left
    }

    let position =
        function
        | Position.Left -> "has-icon-left"
        | Position.Right -> "has-icon-right"

    let icon =
        function
        | _ -> "form-icon"

    //let makeIcon =
        //transform (fun _ -> "form-icon") [""]

    let iconInput props htmlProps (children: ReactElement list) =
        let t = extractProps <| R.div [] [R.p [] []]
        Fable.Import.Browser.console.log t
        R.div [] [
            children.[0]
            children.[1]
        ]
