module TagTests

open Expecto
open Expect
open Fabulosa
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Tag tests" [
        test "Tag should be a react html node when defaults are provided" {
            Tag.ƒ
                (Tag.props, "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label" 
            |> hasText "Ronaldo 9"
        }
        
        test "Tag should be rounded" {
            Tag.ƒ
                ({ Tag.props with Rounded = true },
                 "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-rounded" 
            |> hasText "Ronaldo 9"
        }
       
        test "Tag should not have any label-specfic color class when tag color is default" {
            Tag.ƒ
                ({ Tag.props with
                     Color = Tag.Color.Default },
                 "Ronaldo 9")
            |> ReactNode.unit
            |>! hasUniqueClass "label" 
            |> hasText "Ronaldo 9"
        }
        
        test "Tag should have color labels" {
            Tag.ƒ
                ({ Tag.props with
                     Color = Tag.Color.Primary },
                 "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-primary" 
            |> hasText "Ronaldo 9"

            Tag.ƒ
                ({ Tag.props with
                     Color = Tag.Color.Secondary },
                 "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-secondary" 
            |> hasText "Ronaldo 9"

            Tag.ƒ
                ({ Tag.props with
                     Color = Tag.Color.Success },
                 "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-success" 
            |> hasText "Ronaldo 9"

            Tag.ƒ
                ({ Tag.props with
                     Color = Tag.Color.Warning },
                 "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-warning" 
            |> hasText "Ronaldo 9"

            Tag.ƒ
                ({ Tag.props with
                     Color = Tag.Color.Error },
                 "Ronaldo 9")
            |> ReactNode.unit
            |>! hasClass "label label-error" 
            |> hasText "Ronaldo 9"
        }
    ]
    