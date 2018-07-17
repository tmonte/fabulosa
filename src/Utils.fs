module Utils

open Fable.Helpers.React.Props
open Fable.Import.React

type HTMLProps = | HTMLProps of IHTMLProp list

let className = ClassName

let htmlAttr (prop: IHTMLProp) =
    match prop with
    | :? HTMLAttr as attr -> Some attr
    | _ -> None

let htmlClassName =
    function
    | ClassName name -> Some name
    | _ -> None

let htmlClasses (HTMLProps props) =
    List.choose htmlAttr props
    |> List.choose htmlClassName

let mergeComponentClasses (HTMLProps htmlProps) (componentClasses: string list) =
    let userClasses = htmlClasses <| HTMLProps htmlProps
    let merged = userClasses @ componentClasses |> String.concat " "
    htmlProps @ [ClassName merged]

type Children = Children of ReactElement list
