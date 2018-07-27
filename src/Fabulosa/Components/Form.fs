[<RequireQualifiedAccess>]
module Form

open ClassNames

module R = Fable.Helpers.React
open R.Props

let group =
    ["form-group"]
    |> addClassesToProps
    >> R.div

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

let input = Input.input