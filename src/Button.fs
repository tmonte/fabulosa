module Button

open Fable.Helpers.React.Props
open Fable.Import.React
module R = Fable.Helpers.React

type Props = Props of IHTMLProp list

type Children = Children of ReactElement list

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

type LocalProps =
| Kind of BtnKind
| Color of BtnColor
| Size of BtnSize
| State of BtnState
| Format of BtnFormat

let htmlAttr (prop: IHTMLProp) =
    match prop with
    | :? HTMLAttr as attr -> Some attr
    | _ -> None

let className = function
    | ClassName name -> Some name
    | _ -> None

let classFromProps =
    function
    | Kind (Default) -> "btn-default"
    | Kind (Primary) -> "btn-primary"
    | Kind (Link) -> "btn-link"
    | Color (Success) -> "btn-success"
    | Color (Error) -> "btn-error"
    | Size (Small) -> "btn-sm"
    | Size (Large) -> "btn-lg"
    | _ -> ""

let button (Props props) (Children children) =
    let styleList = List.map classFromProps [Kind Default; Size Small]
    let styles = styleList |> List.fold (fun r s -> r + " " + s) ""
    let className = List.tryPick className <| List.choose htmlAttr props
    let styledProps = props @ [ClassName <| "btn" + styles + Option.defaultValue "" className ]
    R.button styledProps children