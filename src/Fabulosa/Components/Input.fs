namespace Fabulosa

[<RequireQualifiedAccess>]
module Input =

    open ClassNames
    module R = Fable.Helpers.React

    type Size =
    | Small
    | Large

    type Prop =
    | Size of Size

    let propToClass =
        function
        | Size Small -> "input-sm"
        | Size Large -> "input-lg"

    let mapsAny mapping =
        List.choose mapping
        >> List.length
        >> (<) 0

    let input inputProps =
        ["form-input"]
        @ List.map propToClass inputProps
        |> addClassesToProps
        >> R.input

module IconInput =
    
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    type Prop =
    | LeftIcon of ReactElement
    | RightIcon of ReactElement
    | InputProps of Input.Prop list
    | InputHtmlProps of IHTMLProp list

    let propToClass =
        function
        | LeftIcon _ -> "has-icon-left"
        | RightIcon _ -> "has-icon-right"
        | _ -> ""

    let propToinputProps =
        function
        | InputProps props -> Some props
        | _ -> None

    let propToInputHtmlProps =
        function
        | InputHtmlProps props -> Some props
        | _ -> None

    let icon =
        function
        | LeftIcon icon -> Some icon
        | RightIcon icon -> Some icon
        | _ -> None

    let iconInput props =
        let containerClass = List.map propToClass props |> String.concat " "
        let icon = List.choose icon props |> List.head
        let inputProps = List.choose propToinputProps props |> List.head
        let inputHtmlProps = List.choose propToInputHtmlProps props |> List.head
        R.div [ClassName containerClass] [
            Input.input inputProps inputHtmlProps
            icon
        ]

