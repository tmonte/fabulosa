module Utils

open Fable.Helpers.React.Props

type HTMLProps = | HTMLProps of IHTMLProp list

let htmlAttr (prop: IHTMLProp) =
    match prop with
    | :? HTMLAttr as attr -> Some attr
    | _ -> None

let htmlClassName = function
    | ClassName name -> Some name
    | _ -> None

let htmlClasses (HTMLProps props) =
    List.tryPick htmlClassName <| List.choose htmlAttr props |> Option.defaultValue "" 

let className = ClassName