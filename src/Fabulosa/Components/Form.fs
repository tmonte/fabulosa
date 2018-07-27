[<RequireQualifiedAccess>]
module Form

open ClassNames

module R = Fable.Helpers.React
open R.Props

let group =
    ["form-group"]
    |> addClassesToProps
    >> R.div

module Input =

    type Icon =
    | Left
    | Right

    type Size =
    | Small
    | Large

    type Props =
    | Size of Size
    | LeftIcon of Icon.Type
    | RightIcon of Icon.Type

    let containerClasses =
        function
        | LeftIcon _ -> "has-icon-left"
        | RightIcon _ -> "has-icon-right"
        | _ -> ""

    let getIconProps =
        function
        | LeftIcon icon -> Some <| Icon.Type icon
        | RightIcon icon -> Some <| Icon.Type icon
        | _ -> None

    let classes =
        function
        | Size Small -> "input-sm"
        | Size Large -> "input-lg"
        | _ -> ""

let input inputProps htmlProps =
    let combineProps = ["form-input"] @ List.map Input.classes inputProps |> addClassesToProps
    let props = combineProps htmlProps
    let containerClasses = List.map Input.containerClasses inputProps
    if containerClasses.Length > 0 then
        let iconProps = List.choose Input.getIconProps inputProps
        let containerClass = String.concat " " containerClasses
        R.div [ClassName containerClass] [
            R.input props
            Icon.i iconProps [ClassName "form-icon"] []
        ]
    else
        R.input props

let label =
    ["form-label"]
    |> addClassesToProps
    >> R.label

let textarea =
    ["form-input"]
    |> addClassesToProps
    >> R.textarea

let select =
    ["form-select"]
    |> addClassesToProps
    >> R.select

let option = R.option

let optGroup = R.optgroup

let switch htmlProps label =
    let inputProps: IHTMLProp list = [Type "checkbox"]
    let props = htmlProps @ inputProps
    R.label [ClassName "form-switch"] [
        R.input props
        R.i [ClassName "form-icon"] []
        R.str label
    ]

let checkbox htmlProps label =
    let inputProps: IHTMLProp list = [Type "checkbox"]
    let props = htmlProps @ inputProps
    R.label [ClassName "form-checkbox"] [
        R.input props
        R.i [ClassName "form-icon"] []
        R.str label
    ]
