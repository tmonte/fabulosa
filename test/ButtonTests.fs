module ButtonTests

open Button
open Expecto

[<Tests>]
let tests =
    testList "Button tests" [

      test "Props should map to classes" {
        let buttonProps = [ButtonKind ButtonDefault; ButtonFormat ButtonSquaredAction]
        let subject = List.map buttonClasses buttonProps
        Expect.contains subject "btn-default" "Should contain default button class"
        Expect.contains subject "btn-action" "Should contain button action class"
      }

      test "Button should be a react html node" {
        let node = Fable.Helpers.React.HTMLNode.Node ("", [], [])
        let subject = button [] [] []
        Expect.equal (subject.GetType()) (node.GetType()) "Should have a type of react html node"
      }

    ]