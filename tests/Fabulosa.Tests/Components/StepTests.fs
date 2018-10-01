module StepTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect


[<Tests>]
let tests =
    testList "Step tests" [

        test "Step default" {
           Step.ƒ
               (Step.props, [])
            |> ReactNode.unit
            |> hasUniqueClass "step"
        }

        test "Step html props" {
            Step.ƒ
                ({ Step.props with
                     HTMLProps =
                       [ ClassName "custom" ] },
                 [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Step children" {
            let step1 =
                (Step.Item.props,
                 [ R.str "Step 1" ])
            let step2 =
                ({ Step.Item.props with
                     Active = true },
                 [ R.str "Step 2" ])
            let step3 =
                (Step.Item.props,
                 [ R.str "Step 3" ])
            Step.ƒ
                (Step.props,
                 [ step1; step2; step3 ])
            |> ReactNode.unit
            |>! hasChild 1 (Step.Item.ƒ step1 |> ReactNode.unit)
            |>! hasChild 1 (Step.Item.ƒ step2 |> ReactNode.unit)
            |> hasChild 1 (Step.Item.ƒ step3 |> ReactNode.unit)
        }

        test "Step item defaults" {
            Step.Item.ƒ
                (Step.Item.props,
                 [ R.str "Step" ])
            |> ReactNode.unit
            |> hasUniqueClass "step-item"
        }

        test "Step item active" {
            Step.Item.ƒ
                ({ Step.Item.props with
                     Active = true },
                 [ R.str "Step" ])
            |> ReactNode.unit
            |> hasClass "active"
        }
        
    ]