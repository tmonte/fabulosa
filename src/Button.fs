module Button

open Utils
module R = Fable.Helpers.React

type BtnKind =
| Default
| Primary
| Link

type BtnColor =
| Success
| Error

type BtnSize =
| Small
| Large

type BtnState =
| Disabled
| Active
| Loading

type BtnFormat =
| SquaredAction
| RoundAction

type ButtonProp =
| Kind of BtnKind
| Color of BtnColor
| Size of BtnSize
| State of BtnState
| Format of BtnFormat

let spectreClassNames =
    function
    | Kind (Default) -> "btn-default"
    | Kind (Primary) -> "btn-primary"
    | Kind (Link) -> "btn-link"
    | Color (Success) -> "btn-success"
    | Color (Error) -> "btn-error"
    | Size (Small) -> "btn-sm"
    | Size (Large) -> "btn-lg"
    | State (Disabled) -> "disabled"
    | State (Loading) -> "loading"
    | Format (SquaredAction) -> "btn-action"
    | Format (RoundAction) -> "btn-action circle"
    | _ -> ""

let button spectreProps htmlProps children =
    let props =
        mergeComponentClasses
        <| HTMLProps htmlProps
        <| ["btn"] @ List.map spectreClassNames spectreProps
    R.button props children