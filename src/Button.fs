module Button

open Fable.Helpers.React.Props
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

type HTMLProps = | HTMLProps of IHTMLProp list

type Children = Children of ReactElement list

let htmlAttr (prop: IHTMLProp) =
    match prop with
    | :? HTMLAttr as attr -> Some attr
    | _ -> None

let htmlClassName = function
    | ClassName name -> Some name
    | _ -> None

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

let htmlClasses (HTMLProps props) =
    List.tryPick htmlClassName <| List.choose htmlAttr props |> Option.defaultValue "" 

let button (SpectreProps spectreProps) (HTMLProps htmlProps) (Children children) =
    let htmlClass = htmlClasses <| HTMLProps htmlProps
    let spectreClass = spectreClasses <| SpectreProps spectreProps
    let styledProps = htmlProps @ [ClassName <| spectreClass + " " + htmlClass]
    R.button styledProps children