namespace Fabulosa

module ButtonGroup =

    open Fabulosa.Extensions
    open Button
    module R = Fable.Helpers.React
    open R.Props
    
    type ButtonGroupOptional =
        | Block
        interface IHTMLProp

    type ButtonGroupChild =
        Button of Button

    type ButtonGroupChildren = ButtonGroupChild list

    type ButtonGroup = HTMLProps * ButtonGroupChildren

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? ButtonGroupOptional as opt ->
            match opt with
            | Block -> "btn-group-block"
            |> ClassName
            :> IHTMLProp
        | _ -> prop

    let buttonGroup ((opt, chi): ButtonGroup) =
        Unmerged opt
        |> addProp (ClassName "btn-group")
        |> map propToClassName
        |> merge
        |> R.div
        <| Seq.map (fun (Button btn) -> button btn) chi
