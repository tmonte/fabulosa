module MediaTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React
open Fable.Import.React
open R.Props

[<Tests>]
let captionTest =
    testList "Caption tests" [

        test "Caption should be a react html node when defaults are provided" {
            Media.Caption.ƒ
                (Media.Caption.props, Media.Caption.children)
            |> ReactNode.unit
            |>! hasClass "figure-caption text-center"
            |> hasText "Caption" 
        }

        test "Caption should have html props" {
            Media.Caption.ƒ
                ({ Media.Caption.props with
                     HTMLProps = [ Id "offside-is-a-crime" ] },
                 Media.Caption.children)
            |> ReactNode.unit
            |>! hasClass "figure-caption text-center"
            |>! hasProp (Id "offside-is-a-crime")
            |> hasText "Caption"
        }

        test "Caption should have text alignment set to input" {
            Media.Caption.ƒ
                ({ Media.Caption.props with
                     Direction = Media.Caption.Direction.Center },
                 Media.Caption.children)
            |> ReactNode.unit
            |> hasClass "figure-caption text-center"

            Media.Caption.ƒ
                ({ Media.Caption.props with
                     Direction = Media.Caption.Direction.Left },
                 Media.Caption.children)
            |> ReactNode.unit
            |> hasClass "figure-caption text-left"

            Media.Caption.ƒ
                ({ Media.Caption.props with
                     Direction = Media.Caption.Direction.Right },
                 Media.Caption.children)
            |> ReactNode.unit
            |> hasClass "figure-caption text-right"
        }

        test "Caption should display custom text" {
            let text = "Pele is the King!"

            Media.Caption.ƒ
                (Media.Caption.props,
                 Media.Caption.Children.Text text)
            |> ReactNode.unit
            |> hasText text
        }
    ] 

[<Tests>]
let imageTest =
    testList "Image tests" [

        test "Image should be a react html node when defaults are provided" {
            Media.Image.ƒ
                Media.Image.props
            |> ReactNode.unit
            |> hasUniqueClass "img-responsive"
        }

        test "Image should be respond to different kinds" {
            Media.Image.ƒ
                { Media.Image.props with
                    Kind = Media.Image.Kind.Responsive }
            |> ReactNode.unit
            |> hasUniqueClass "img-responsive"

            Media.Image.ƒ
                { Media.Image.props with
                    Kind = Media.Image.Kind.Contain }
            |> ReactNode.unit
            |> hasUniqueClass "img-fit-contain"

            Media.Image.ƒ
                { Media.Image.props with
                    Kind = Media.Image.Kind.Cover } 
            |> ReactNode.unit
            |> hasUniqueClass "img-fit-cover"
        }
    ]

[<Tests>]
let figureTests =
    testList "Figure tests" [

        test "Figure should display defaults" {               
            let image =
                Media.Image.ƒ
                    Media.Image.props
                |> ReactNode.unit

            Media.Figure.ƒ
                (Media.Figure.props,
                 Media.Figure.children)
            |> ReactNode.unit
            |>! hasUniqueClass "figure"
            |> hasChild 1 image 
        }

        test "Figure should have html props" {
            Media.Figure.ƒ
                ({ Media.Figure.props with
                    HTMLProps = [ Id "messi-argentina.jpg" ] },
                 Media.Figure.children)
            |> ReactNode.unit 
            |> hasProp (Id "messi-argentina.jpg") 
        }
       
        test "Figure does contain props" {
            let expectedCaption =
                Media.Caption.props,
                Media.Caption.Children.Text "Ronaldo 9"

            let expectedImageProps =
                { Media.Image.props with
                    Kind = Media.Image.Kind.Cover }

            let caption =
                Media.Caption.ƒ
                    expectedCaption
                |> ReactNode.unit

            let image =
                Media.Image.ƒ
                    expectedImageProps
                |> ReactNode.unit

            Media.Figure.ƒ
                (Media.Figure.props,
                 { Caption = Some expectedCaption
                   Image = expectedImageProps })
            |> ReactNode.unit
            |>! hasUniqueClass "figure"
            |>! hasChild 1 caption
            |> hasChild 1 image
        }
    ]

[<Tests>]
let videoTests =
    testList "Video tests" [
        test "should display defaults" {
            Media.Video.ƒ
                Media.Video.props
            |> ReactNode.unit
            |>! hasClass "video-responsive video-responsive-16-9"
            |> hasProp (Src "")
        }
        test "should display different ratios" {
            Media.Video.ƒ
                { Media.Video.props with
                    Ratio = Media.Video.Ratio.Ratio16x9 }
            |> ReactNode.unit
            |> hasClass "video-responsive video-responsive-16-9"

            Media.Video.ƒ
                { Media.Video.props with
                    Ratio = Media.Video.Ratio.Ratio4x3 }
            |> ReactNode.unit
            |> hasClass "video-responsive video-responsive-4-3"

            Media.Video.ƒ
                { Media.Video.props with
                    Ratio = Media.Video.Ratio.Ratio1x1 }
            |> ReactNode.unit
            |> hasClass "video-responsive video-responsive-1-1"
        }
        
        test "should render source video " {
            Media.Video.ƒ
                { Media.Video.props with
                    Kind = Media.Video.Kind.Source
                        "https://video.webm"}
            |> ReactNode.unit
            |>! hasClass "video-responsive video-responsive-16-9"
            |> hasProp (Src "https://video.webm")
        }
        
        test "should render embedded video " {
            let youtubeVideo =
                R.iframe
                    [ Src "https://www.youtube.com/embed/7DbslbKsQSk"
                      AllowFullScreen true
                      HTMLAttr.Width 560
                      HTMLAttr.Height 315 ]
                    []
            Media.Video.ƒ
                { Media.Video.props with
                    Kind = Media.Video.Kind.Embedded youtubeVideo }
            |> ReactNode.unit
            |>! hasClass "video-responsive video-responsive-16-9"
            |> hasChild 1 (youtubeVideo |> ReactNode.unit)
        }
     ]