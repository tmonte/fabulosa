module ButtonTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Button tests" [

        test "Button props should map to classes" {
            let buttonProps = [Button.Kind Button.Default; Button.Format Button.SquaredAction]
            let subject = List.map Button.propToClass buttonProps
            Expect.containsAll subject ["btn-default"; "btn-action"] "Should contain default button class"
        }

        test "Button should be a react html node" {
            let node = R.Node ("button", [ClassName "btn"], [])
            let subject = Button.button [] [] []
            compareNode subject node
        }

    ]