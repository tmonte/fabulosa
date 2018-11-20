namespace Fabulosa

module Figure =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React
    open Fabulosa.Caption
    open Fabulosa.Image
                        
    type FigureKind =
        | Responsive
        | Contain
        | Cover
    
    type FigureOptional = 
        | Caption of Caption
        interface IHTMLProp
        
    type FigureChildren =
        | Image of Image
        
    type Figure = HTMLProps * FigureChildren        

    let private figureCaption (prop: IHTMLProp) =
        match prop with
        | :? FigureOptional as opt ->
            match opt with
            | Caption cap -> caption cap |> Some
        | _ -> None
    
    let figure ((opt, (Image chi)): Figure) =
        opt
        |> Unmerged
        |> addProp (ClassName "figure")
        |> merge
        |> R.figure
        <| [ image chi
             List.tryPick figureCaption opt |> R.ofOption ]   
           