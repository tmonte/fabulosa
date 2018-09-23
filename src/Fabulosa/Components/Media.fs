namespace Fabulosa

module Media =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module Caption =

        [<RequireQualifiedAccess>]
        type Direction =
        | Left
        | Center
        | Right

        [<RequireQualifiedAccess>]
        type Children =
        | Text of string
        | Elements of ReactElement list

        [<RequireQualifiedAccess>]
        type Props =
            { Direction: Direction
              HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.Direction =
                Direction.Center
              Props.HTMLProps = [] }
              
        let children =
            Children.Text "Caption"

        let private direction =
            function 
            | Direction.Left -> "text-left"
            | Direction.Center -> "text-center"
            | Direction.Right -> "text-right"
            >> ClassName

        let private renderChildren =
            function
            | Children.Text text ->
                [ R.str text ]
            | Children.Elements elements ->
                elements

        let ƒ (caption: T) =
            let props, children = caption
            props.HTMLProps
            |> addProps
                [ ClassName "figure-caption"
                  direction props.Direction ]
            |> R.figcaption
            <| renderChildren children
    
        let render = ƒ

    module Image =

        [<RequireQualifiedAccess>]
        type Kind =
        | Responsive
        | Contain
        | Cover

        [<RequireQualifiedAccess>]
        type Props =
            { Kind: Kind
              HTMLProps: IHTMLProp list }

        [<RequireQualifiedAccess>]
        type T = Props

        let props =
            { Props.Kind = Kind.Responsive
              Props.HTMLProps = [] }

        let private kind =
            function 
            | Kind.Responsive -> "img-responsive"
            | Kind.Contain -> "img-fit-contain"
            | Kind.Cover -> "img-fit-cover"
            >> ClassName

        let ƒ (image: T) =
            image.HTMLProps 
            |> addProp (kind props.Kind)
            |> R.img
    
        let render = ƒ
    
    module Figure =

        [<RequireQualifiedAccess>]
        type Kind =
        | Responsive
        | Contain
        | Cover
        
        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }

        [<RequireQualifiedAccess>]
        type Children =
            { Image: Image.T
              Caption: Caption.T option }

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = [] }

        let children =
            { Children.Image = Image.props
              Children.Caption = None }

        let private caption =
            function
            | Some caption -> Caption.ƒ caption
            | None -> R.ofOption None

        let ƒ (figure: T) =
            let props, children = figure
            props.HTMLProps
            |> addProp (ClassName "figure")
            |> R.figure
            <| [ Image.ƒ children.Image
                 caption children.Caption ]    
            
        let render = ƒ

    module Video =

        [<RequireQualifiedAccess>]
        type Ratio =
        | Ratio16x9
        | Ratio4x3
        | Ratio1x1

        [<RequireQualifiedAccess>]
        type Kind =
        | Embedded of ReactElement
        | Source of string
        
        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Ratio: Ratio
              Kind: Kind }

        [<RequireQualifiedAccess>]
        type T = Props

        let props =
            { Props.HTMLProps = []
              Props.Ratio = Ratio.Ratio16x9
              Props.Kind = Kind.Source "" }

        let private ratio =
            function 
            | Ratio.Ratio16x9 -> "video-responsive-16-9"
            | Ratio.Ratio4x3 -> "video-responsive-4-3"
            | Ratio.Ratio1x1 -> "video-responsive-1-1"
            >> ClassName

        let private container =
            function
            | Kind.Source source ->
                R.video, [Src source], []
            | Kind.Embedded element ->
                R.iframe, [], [element]

        let ƒ (video: T) =
            let (parent, props, children) =
                container video.Kind

            video.HTMLProps
            |> List.append (props |> List.cast)
            |> addProps
                [ ClassName "video-responsive"
                  ratio video.Ratio ]
            |> parent <| children
            
        let render = ƒ
