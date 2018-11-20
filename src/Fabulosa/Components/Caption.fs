namespace Fabulosa

module Caption =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type CaptionDirection =
        | Left
        | Center
        | Right

    type CaptionOptional =
        | Direction of CaptionDirection
        interface IHTMLProp
    
    type CaptionChildren =
        | Text of string
        | Elements of ReactElement list            
    
    type Caption = HTMLProps * CaptionChildren
    
    let private renderChildren =
        function
        | Text text -> [ R.str text ]
        | Elements elements -> elements

    let private direction (prop: IHTMLProp) =
        match prop with
        | :? CaptionOptional as opt ->
            match opt with
            | Direction Left -> className "text-left" |> Some
            | Direction Right -> className "text-right" |> Some
            | Direction Center -> className "text-center" |> Some
        | _ -> None
    
    let caption ((opt, chi): Caption) =
        Unmerged opt
        |> addProps [ ClassName "figure-caption"]
        |> addOptionOrElse direction (ClassName "text-center")
        |> merge
        |> R.figcaption
        <| renderChildren chi