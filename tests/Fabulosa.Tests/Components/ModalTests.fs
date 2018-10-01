module ModalTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let headerTests =
    testList "Modal Header tests" [
        test "renders with text" {
            let child = R.div [ClassName "modal-title h5"] [R.str "Ciro 12"] |> ReactNode.unit 
            let header = Modal.Header.defaults, Modal.Header.Children.Text "Ciro 12"
            
            header
            |> Modal.Header.ƒ 
            |> ReactNode.unit
            |>! hasUniqueClass "modal-header"
            |> hasChild 1 child
        }
        
        test "renders with element" {
            let complexChildContent = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let header = Modal.Header.defaults, Modal.Header.Children.Elements [complexChildContent]
        
            header
            |> Modal.Header.ƒ
            |> ReactNode.unit
            |> hasChild 1 child
        }
        
        test "renders props" {
            let complexChildContent = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let props = { Modal.Header.defaults with HTMLProps = [Id "hello-world"] } 
            let header = props, Modal.Header.Children.Elements [complexChildContent]
        
            header
            |> Modal.Header.ƒ 
            |> ReactNode.unit
            |>! hasProp (Id "hello-world")
            |> hasChild 1 child
        }
    ]

[<Tests>]
let footerTests =    
    testList "Modal Footer tests" [
        test "renders with element" {
            let content = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = content |> ReactNode.unit 
            let footer = Modal.Footer.defaults, Modal.Footer.Children.Elements [content] 
        
            footer
            |> Modal.Footer.ƒ 
            |> ReactNode.unit
            |>! hasUniqueClass "modal-footer"
            |> hasChild 1 child
        }
        
        test "renders with buttons" {
            let buttons = [
                { Button.props with Kind = Button.Kind.Primary }, [R.str "Submit"]
                { Button.props with Kind = Button.Kind.Link }, [R.str "Close"]
            ]
            let primaryButton = buttons.[0] |> Button.ƒ |> ReactNode.unit 
            let linkButton = buttons.[1] |> Button.ƒ |> ReactNode.unit 
            let footer = Modal.Footer.defaults, Modal.Footer.Children.Buttons buttons
        
            footer
            |> Modal.Footer.ƒ 
            |> ReactNode.unit
            |>! hasUniqueClass "modal-footer"
            |>! hasChild 1 primaryButton
            |> hasChild 1 linkButton
        }
        
        test "renders props" {
            let complexChildContent = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let props = { Modal.Footer.defaults with HTMLProps = [Id "hello-world"] } 
            let footer = props, Modal.Footer.Children.Elements [complexChildContent]
        
            footer
            |> Modal.Footer.ƒ 
            |> ReactNode.unit
            |>! hasProp (Id "hello-world")
            |> hasChild 1 child
        }
    ]
    
[<Tests>]
let modalTests =    
    testList "Modal tests" [
        test "renders default props" {
              (Modal.defaults, Modal.children)
              |> Modal.ƒ
              |> ReactNode.unit
              |>! hasClass "modal active"
              |>! hasDescendentClass "modal-overlay modal-container modal-body"
              |>! hasNoDescendentClass "modal-header modal-footer"
              |> hasText ""
        }
        
        test "renders props" {
            let props =  { Modal.defaults with HTMLProps = [Id "pele"] }
            (props, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit
            |>! hasProp (Id "pele")
            |>! hasClass "modal active"
            |>! hasDescendentClass "modal-container"
            |>! hasDescendentClass "modal-body"
            |> hasText ""
        }
        
        test "configures OnClose overlay" {
            let happyFunction parms = ()
            let overlay = R.a [ClassName "modal-overlay"; OnClick happyFunction] []
            let buttonClose = R.a [ClassName "btn btn-clear float-right"; OnClick happyFunction] []
            
            let props =  { Modal.defaults with
                OnRequestClose = happyFunction |> Some
            }
            (props, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit
            |>! hasClass "modal active"
            |>! hasChild 1 (overlay |> ReactNode.unit)
            |>! hasChild 1 (buttonClose |> ReactNode.unit)
            |>! hasDescendentClass "modal-header"
            |>! hasDescendentClass "modal-container"
            |>! hasDescendentClass "modal-body"
            |> hasText ""
        }
        
        test "configures size" {
            let propsSmall =  { Modal.defaults with Size = Modal.Size.Small }
            let propsMedium =  { Modal.defaults with Size = Modal.Size.Medium }
            let propsLarge =  { Modal.defaults with Size = Modal.Size.Large }
            
            (propsSmall, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit    
            |> hasClass "modal active modal-sm"
            
            (propsMedium, Modal.children)
            |> Modal.ƒ
            |> ReactNode.unit
            |> hasClass "modal active"
            
            (propsLarge, Modal.children)
            |> Modal.ƒ 
            |> ReactNode.unit
            |> hasClass "modal active modal-lg"
        }
        
        test "renders body contents" {
            let babyLookAtThisBody = R.str "I work out!"
            let children = { Modal.children with Body = [babyLookAtThisBody] }
            
            (Modal.defaults, children)
            |> Modal.ƒ  
            |> ReactNode.unit
            |> hasChild 1 (babyLookAtThisBody |> ReactNode.unit)
        }
        
        test "renders header contents" {
            let headerConfig = Modal.Header.defaults, (Modal.Header.Text "Ciro 12")
            let headerChild = headerConfig |> Modal.Header.ƒ |> ReactNode.unit
            let children = { Modal.children with Header = Some headerConfig }
            
            (Modal.defaults, children)
            |> Modal.ƒ  
            |> ReactNode.unit
            |>! hasDescendentClass "modal-header"
            |> hasChild 1 headerChild
        }
        
        test "renders footer contents" {
//            let footerT = Modal.Footer.defaults, Modal.Footer.Children.Elements R.str "Yooolo" 
//            let footerChild = footerT ||> Modal.Footer.ƒ |> ReactNode.unit
                     
            ()
        }
    ]
    