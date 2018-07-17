module Button

open Utils
open Fable.Import.React
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

type SpectreProp =
| Kind of BtnKind
| Color of BtnColor
| Size of BtnSize
| State of BtnState
| Format of BtnFormat

type SpectreProps = SpectreProps of SpectreProp list

type Children = Children of ReactElement list

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

let spectreClasses (SpectreProps props) =
    "btn " + (List.map spectreClassNames props |> String.concat " ")

let button (SpectreProps spectreProps) (HTMLProps htmlProps) (Children children) =
    let htmlClass = htmlClasses <| HTMLProps htmlProps
    let spectreClass = spectreClasses <| SpectreProps spectreProps
    let styledProps = htmlProps @ [className <| spectreClass + " " + htmlClass]
    R.button styledProps children