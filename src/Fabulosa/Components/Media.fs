namespace Fabulosa

module Media =
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    module Caption =
        type Direction =
            | Left
            | Center
            | Right

        type CaptionOptional =
            | Direction of Direction
            interface IHTMLProp
        
        type Children =
            | Text of string
            | Elements of ReactElement list            
        
        type Caption = HTMLProps * Children
        
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
        
        let caption (caption: Caption) =
            let props, children = caption
            
            props
            |> Unmerged
            |> addProps [ ClassName "figure-caption"]
            |> addOptionOrElse direction (ClassName "text-center")
            |> merge
            |> R.figcaption
            <| renderChildren children
 
    module Image =
        type Kind =
        | Responsive
        | Contain
        | Cover

        type ImageOptional =
            | Kind of Kind
            interface IHTMLProp
            
        type Image = HTMLProps
            
        let private kind (prop: IHTMLProp) =
            match prop with
            | :? ImageOptional as opt ->
                match opt with
                | Kind Responsive -> className "img-responsive" |> Some
                | Kind Contain -> className "img-fit-contain" |> Some
                | Kind Cover -> className "img-fit-cover" |> Some
            | _ -> None
        
        let image (image: Image) = 
            image
            |> Unmerged
            |> addOptionOrElse kind (ClassName "img-responsive")
            |> merge
            |> R.img
                
    module Figure =
        type Kind =
        | Responsive
        | Contain
        | Cover
        
        type FigureOptional = 
            | Caption of Caption.Caption
            interface IHTMLProp
            
        type FigureChildren =
            | Image of Image.Image
            
        type Figure = HTMLProps * FigureChildren        

        let private caption (prop: IHTMLProp) =
            match prop with
            | :? FigureOptional as opt ->
                match opt with
                | Caption caption -> Caption.caption caption |> Some
            | _ -> None
        
        let figure (figure: Figure) =
            let props, (Image children) = figure
            props
            |> Unmerged
            |> addProp (ClassName "figure")
            |> merge
            |> R.figure
            <| [ Image.image children
                 List.tryPick caption props |> R.ofOption ]   

    module Video =
        type Ratio =
        | Ratio16x9
        | Ratio4x3
        | Ratio1x1

        type Kind =
        | Embedded of ReactElement
        | Source of string
                
        type VideoOptional =
            | Ratio of Ratio
            interface IHTMLProp

        type VideoRequired = | Kind of Kind

        type Video = HTMLProps * VideoRequired
        
        let private ratio (prop: IHTMLProp) =
            match prop with
            | :? VideoOptional as opt ->
                match opt with
                | Ratio Ratio16x9 -> className "video-responsive-16-9" |> Some
                | Ratio Ratio4x3 -> className "video-responsive-4-3" |> Some
                | Ratio Ratio1x1 -> className "video-responsive-1-1" |> Some
            | _ -> None

        let private container =
            function
            | Source source ->
                R.video, [Src source :> IHTMLProp], []
            | Kind.Embedded element ->
                R.iframe, [], [element]
  
        let video (video: Video) = 
            let (props, (Kind kind)) = video
            let container, containerProps, children = (container kind)
            
            props
            |> Unmerged
            |> addProps containerProps
            |> addProp (ClassName "video-responsive")
            |> addOptionOrElse ratio (ClassName "video-responsive-16-9")
            |> merge
            |> container
            <| children