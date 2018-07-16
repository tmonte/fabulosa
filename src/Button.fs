module Button

open Fable.Helpers.React.Props
open Fable.Import.React
module R = Fable.Helpers.React

type Props = Props of IHTMLProp list

type Children = Children of ReactElement list

let htmlAttr (prop: IHTMLProp) =
    match prop with
    | :? HTMLAttr as attr -> Some attr
    | _ -> None

let className = function
    | ClassName name -> Some name
    | _ -> None

let button (Props props) (Children children) =
    let className = List.tryPick className <| List.choose htmlAttr props
    let styledProps = props @ [ClassName <| "btn btn-primary " + Option.defaultValue "" className ]
    R.button styledProps children