module Button

open Utils
module R = Fable.Helpers.React

type ButtonKind =
| Default
| Primary
| Link

type ButtonColor =
| Success
| Error

type ButtonSize =
| Small
| Large

type ButtonState =
| Disabled
| Active
| Loading

type ButtonFormat =
| SquaredAction
| RoundAction

type ButtonProp =
| ButtonKind of ButtonKind
| ButtonColor of ButtonColor
| ButtonSize of ButtonSize
| ButtonState of ButtonState
| ButtonFormat of ButtonFormat

let buttonClasses =
    function
    | ButtonKind Default -> "btn-default"
    | ButtonKind Primary -> "btn-primary"
    | ButtonKind Link -> "btn-link"
    | ButtonColor Success -> "btn-success"
    | ButtonColor Error -> "btn-error"
    | ButtonSize Small -> "btn-sm"
    | ButtonSize Large -> "btn-lg"
    | ButtonState Disabled -> "disabled"
    | ButtonState Loading -> "loading"
    | ButtonFormat SquaredAction -> "btn-action"
    | ButtonFormat RoundAction -> "btn-action circle"
    | _ -> ""

let button buttonProps htmlProps children =
    let props = mergeClasses <| htmlProps <| ["btn"] @ List.map buttonClasses buttonProps
    R.button props children