module ModalTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Modal Header tests" [
        test "renders header with text" {
            let child = R.div [ClassName "modal-title h5"] [R.str "Ciro 12"] |> ReactNode.unit 
        
            "Ciro 12" 
            |> Modal.Header.Children.Text
            |> Modal.Header.ƒ Modal.Header.defaults 
            |> ReactNode.unit
            |>! hasUniqueClass "modal-header"
            |> hasChild 1 child
        }
        
        test "renders header with element" {
            let complexChildContent = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
        
            [complexChildContent]
            |> Modal.Header.Children.Element
            |> Modal.Header.ƒ Modal.Header.defaults 
            |> ReactNode.unit
            |> hasChild 1 child
        }
        
        test "renders props" {
            let complexChildContent = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let props = { Modal.Header.defaults with HTMLProps = [Id "hello-world"] } 
        
            [complexChildContent]
            |> Modal.Header.Children.Element
            |> Modal.Header.ƒ props
            |> ReactNode.unit
            |>! hasProp (Id "hello-world")
            |> hasChild 1 child
            
        }
    ]
    