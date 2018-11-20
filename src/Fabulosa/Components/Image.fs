namespace Fabulosa

module Image =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React
 
    type ImageKind =
    | Responsive
    | Contain
    | Cover

    type ImageOptional =
        | Kind of ImageKind
        interface IHTMLProp
        
    type Image = HTMLProps
        
    let private imageKind (prop: IHTMLProp) =
        match prop with
        | :? ImageOptional as opt ->
            match opt with
            | Kind Responsive -> className "img-responsive" |> Some
            | Kind Contain -> className "img-fit-contain" |> Some
            | Kind Cover -> className "img-fit-cover" |> Some
        | _ -> None
    
    let image (opt: Image) = 
        opt
        |> Unmerged
        |> addOptionOrElse imageKind (ClassName "img-responsive")
        |> merge
        |> R.img