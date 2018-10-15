module BarTests

open Expecto
open Fabulosa
open Fabulosa.Button
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Bar tests" [

        test "Bar default" {
            let item = (Bar.Item.props, [])
            Bar.ƒ
                (Bar.props,
                 [ item ])
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1
                (Bar.Item.ƒ item |> ReactNode.unit)
            |> hasDescendentClass "bar-item"
        }

        test "Bar multiple" {
            let item1 = ({ Bar.Item.props with Value = 25 }, [])
            let item2 = ({ Bar.Item.props with Value = 20 }, [])
            Bar.ƒ (Bar.props, [ item1; item2 ])
            |> ReactNode.unit
            |>! hasUniqueClass "bar"
            |>! hasChild 1
                (Bar.Item.ƒ item1 |> ReactNode.unit)
            |>! hasChild 1
                (Bar.Item.ƒ item2 |> ReactNode.unit)
            |> hasOrderedDescendentClass 2 "bar-item"
        }

        test "Bar small" {
            Bar.ƒ 
                ({ Bar.props with
                     Small = true }, [])
            |> ReactNode.unit
            |> hasClass "bar bar-sm"
        }

        test "Bar html props" {
            Bar.ƒ
                ({ Bar.props with 
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "bar custom"
        }

        test "Bar item default" {
            Bar.Item.ƒ
                (Bar.Item.props, [])
            |> ReactNode.unit
            |> hasUniqueClass "bar-item"
        }

        test "Bar item html props" {
            Bar.Item.ƒ
                ({ Bar.Item.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "bar-item custom"
        }

        test "Bar item percentage" {
            Bar.Item.ƒ
                ({ Bar.Item.props with
                     Value = 25 }, [])
            |> ReactNode.unit
            |> hasProp (Style [Width "25%"])
        }

        test "Bar item tooltip" {
            Bar.Item.ƒ
                ({ Bar.Item.props with
                     Value = 25
                     Tooltip = true }, [])
            |> ReactNode.unit
            |>! hasClass "bar-item tooltip"
            |>! hasProp (Style [Width "25%"])
            |> hasProp (Data ("tooltip", "25%"))
        }

        test "Bar slider default" {
            let but =
                button
                    ([ ClassName "bar-slider-btn" ], [])
            Bar.Slider.ƒ (Bar.props, [ (Bar.Item.props, []) ])
            |> ReactNode.unit
            |>! hasClass "bar bar-slider"
            |>! hasChild 1 (Bar.Item.ƒ (Bar.Item.props, [ but ]) |> ReactNode.unit)
            |> hasDescendentClass "bar-item bar-slider-btn"
        }

        test "Bar slider multiple" {
            let but =
                button
                    ([ ClassName "bar-slider-btn" ], [] )
            let item1 = ({ Bar.Item.props with Value = 25}, [ but ])
            let item2 = ({ Bar.Item.props with Value = 20}, [ but])
            Bar.Slider.ƒ (Bar.Slider.props, [item1; item2])
            |> ReactNode.unit
            |>! hasClass "bar bar-slider"
            |>! hasChild 1
                (Bar.Item.ƒ item1 |> ReactNode.unit)
            |>! hasChild 1
                (Bar.Item.ƒ item2 |> ReactNode.unit)
            |> hasOrderedDescendentClass 2 "bar-item bar-slider-btn"
        }
    ]