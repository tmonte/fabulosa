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

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Position =
    | Left
    | Right

    [<RequireQualifiedAccess>]
    type Props = {
        Position: Position
        InputProps: Input.Props
        IconProps: Icon.Props
    }

    let defaults = {
        Props.Position = Position.Left
        Props.InputProps = Input.defaults
        Props.IconProps = Icon.defaults
    }

    let position =
        function
        | Position.Left -> "has-icon-left"
        | Position.Right -> "has-icon-right"

    let ƒ (props: Props) =
        let containerClasses =
            [ position props.Position ]
            |> String.concat " "
        let iconProps =
            { props.IconProps with
                HTMLProps = props.IconProps.HTMLProps
                @ [ClassName "form-icon"] }
        R.div [ClassName containerClasses] [
            Input.ƒ props.InputProps
            Icon.ƒ iconProps []
        ]

[<RequireQualifiedAccess>]
module InputGroup =

    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    type AddOn =
    | Radio of Radio.Props
    | Checkbox of Checkbox.Props
    | Switch of Switch.Props
    | Unset

    [<RequireQualifiedAccess>]
    type WithButton =
    | Button of Button.Props
    | Unset

    type WithText =
    | Text of string
    | Unset

    [<RequireQualifiedAccess>]
    type Props = {
        AddonProps: AddOn
        WithButton: WithButton
        WithText: WithText
        HTMLProps: IHTMLProp list
    }

    let defaults = {
        Props.AddonProps = AddOn.Unset
        Props.WithButton = WithButton.Unset
        Props.WithText = WithText.Unset
        Props.HTMLProps = []
    }

    let button =
        function
        | WithButton.Button props ->
            Some <| Button.ƒ
                { props with
                    HTMLProps = props.HTMLProps
                    @ [ClassName "input-group-btn"] } []
        | WithButton.Unset -> None

    let text =
        function
        | WithText.Text text ->
            Some <| R.span [ClassName "input-group-addon"] [R.str text]
        | WithText.Unset -> None

    let empty = R.str ""

    let ƒ (props: Props) (children: ReactElement list) =
        let button = button props.WithButton
        let text = text props.WithText
        R.div [ClassName "input-group"] [
            (if text.IsSome then text.Value else empty)
            R.fragment [] children
            (if button.IsSome then button.Value else empty)
        ]