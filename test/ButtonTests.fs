module ButtonTests

open Button
open Expecto
open Fable.Helpers.React.Props

let extract = function
  | Fable.Helpers.React.HTMLNode.Node (a, b, c) -> (a, b, c)
  | _ -> ("", seq [], seq [])

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
        let node = Fable.Helpers.React.HTMLNode.Node ("button", [ClassName "btn"], [])
        let subject = button [] [] []
        let nodeName, nodeProps, nodeChildren = extract node
        let subName, subProps, subChildren = extract (subject :?> Fable.Helpers.React.HTMLNode)
        Expect.equal (subject.GetType()) (node.GetType()) "Should have a type of react html node"
        Expect.equal nodeName subName "Should have equal names"
        Expect.sequenceEqual nodeProps subProps "Should have equal props"
        Expect.sequenceEqual nodeChildren subChildren "Should have equal children"
      }

    ]