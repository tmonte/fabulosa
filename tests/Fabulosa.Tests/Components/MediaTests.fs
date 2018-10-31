module MediaTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React
open Fable.Import.React
open R.Props
open Fabulosa.Media.Caption
open Fabulosa.Media.Image

[<Tests>]
let captionTest =
    testList "Caption" [
        test "should display text" {            
           let text = "Pele is the King!"
           caption ([], Text text)
           |> ReactNode.unit
           |> hasText text
        }

        test "should have html props" {
            caption ([ Id "offside-is-a-crime" ], Text "Pele")
            |> ReactNode.unit
            |> hasProp (Id "offside-is-a-crime")
        }
        
        test "should have default alignment to be center" {
            caption ([], Text "Text")
            |> ReactNode.unit
            |> hasClass "figure-caption text-center"
        }

        test "should have text alignment set to input" {
            caption ([Direction Center], Text "Text")
            |> ReactNode.unit
            |> hasClass "figure-caption text-center"

            caption ([Direction Left], Text "Text")
            |> ReactNode.unit
            |> hasClass "figure-caption text-left"

            caption ([Direction Right], Text "Text")
            |> ReactNode.unit
            |> hasClass "figure-caption text-right"
        }

        test "Caption should display react elements" {
            let child = R.div [] [ R.str "Super custom stuff" ]

            caption ([], Elements [ child ])
            |> ReactNode.unit
            |> hasChild 1 (child |> ReactNode.unit)
        }
    ] 

[<Tests>]
let imageTest =
    testList "Image tests" [
        test "Image should be a react html node when defaults are provided" {
            image []
            |> ReactNode.unit
            |> hasUniqueClass "img-responsive"
        }

        test "Image should be respond to different kinds" {
            image [Kind Responsive]
            |> ReactNode.unit
            |> hasUniqueClass "img-responsive"

            image [Kind Contain]
            |> ReactNode.unit
            |> hasUniqueClass "img-fit-contain"

            image [Kind Cover] 
            |> ReactNode.unit
            |> hasUniqueClass "img-fit-cover"
        }
    ]
    
open Fabulosa.Media.Figure
[<Tests>]
let figureTests =
    testList "Figure tests" [
        test "Figure should display defaults" {               
            let imageData = []
            let imageElement = image imageData |> ReactNode.unit
            let aFigure = figure ([], Image imageData )
             
            aFigure 
            |> ReactNode.unit
            |>! hasUniqueClass "figure"
            |> hasChild 1 imageElement
        }


        test "Figure should have html props" {
            figure ([Id "messi.jpg"], Image [])            
            |> ReactNode.unit 
            |> hasProp (Id "messi.jpg") 
        }
       
        test "Figure does contain props" {
            let captionData = ([], Text "My Caption")
            let imageData = [Src "some-source" :> IHTMLProp] 
            
            figure ([ Caption captionData ], Image (imageData))
                
            |> ReactNode.unit
            |>! hasUniqueClass "figure"
            |>! hasChild 1 (caption captionData |> ReactNode.unit)
            |> hasChild 1 (image imageData |> ReactNode.unit)
        }
    ]

open Fabulosa.Media.Video
[<Tests>]
let videoTests =
    testList "Video tests" [
        test "should display defaults" {
            video ([], Kind (Source "learn-javascrip"))
            |> ReactNode.unit
            |>! hasClass "video-responsive video-responsive-16-9"
            |> hasProp (Src "learn-javascrip")
        }
        
        test "should display different ratios" {
            video ([Ratio Ratio16x9], Kind (Source ""))
            |> ReactNode.unit
            |> hasClass "video-responsive video-responsive-16-9"

            video ([Ratio Ratio4x3], Kind (Source ""))
            |> ReactNode.unit
            |> hasClass "video-responsive video-responsive-4-3"

            video ([Ratio Ratio1x1], Kind (Source ""))
            |> ReactNode.unit
            |> hasClass "video-responsive video-responsive-1-1"
        }
        
        test "should render source video " {
            video ([], Kind (Source "https://video.webm"))
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
            video ([ Src "https://www.youtube.com/embed/7DbslbKsQSk"
                     AllowFullScreen true
                     HTMLAttr.Width 560
                     HTMLAttr.Height 315],
                     Kind (Frame))
            |> ReactNode.unit
            |>! hasClass "video-responsive video-responsive-16-9"
            |> hasChild 1 (youtubeVideo |> ReactNode.unit)
        }
     ]