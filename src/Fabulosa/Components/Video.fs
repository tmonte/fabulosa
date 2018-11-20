namespace Fabulosa

module Video =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type VideoRatio =
        | Ratio16x9
        | Ratio4x3
        | Ratio1x1

    type VideoKind =
        | Frame
        | Source of string
            
    type VideoOptional =
        | Ratio of VideoRatio
        interface IHTMLProp

    type VideoRequired = | Kind of VideoKind

    type Video = HTMLProps * VideoRequired
    
    let private ratio (prop: IHTMLProp) =
        match prop with
        | :? VideoOptional as opt ->
            match opt with
            | Ratio Ratio16x9 -> className "video-responsive-16-9" |> Some
            | Ratio Ratio4x3 -> className "video-responsive-4-3" |> Some
            | Ratio Ratio1x1 -> className "video-responsive-1-1" |> Some
        | _ -> None

    let private videoTag props source =
        props
        |> Unmerged
        |> addProp (Src source)
        |> addProp (ClassName "video-responsive")
        |> addOptionOrElse ratio (ClassName "video-responsive-16-9")
        |> merge
        |> R.video
        <| []
        
    let private frameTag (props: HTMLProps ) =
        [ ClassName "video-responsive" :> IHTMLProp]
        |> Unmerged
        |> addOptionOrElse ratio (ClassName "video-responsive-16-9")
        |> merge 
        |> R.div
        <| [ R.iframe props [] ]                   

    let video (video: Video) = 
        let (props, (Kind kind)) = video
        
        match kind with 
        | Source source -> videoTag props source
        | Frame -> frameTag props
        