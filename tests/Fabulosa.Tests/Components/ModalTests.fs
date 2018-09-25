module ModalTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect
open Fable.Import.React

[<Tests>]
let headerTests =
    testList "Modal Header" [
        test "renders with text" {
            let child = R.div [ClassName "modal-title h5"] [R.str "Ciro 12"] |> ReactNode.unit 
        
            "Ciro 12" 
            |> Modal.Header.Children.Text
            |> Modal.Header.ƒ Modal.Header.props 
            |> ReactNode.unit
            |>! hasUniqueClass "modal-header"
            |> hasChild 1 child
        }
        
        test "renders with element" {
            let complexChildContent = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
        
            [complexChildContent]
            |> Modal.Header.Children.Elements
            |> Modal.Header.ƒ Modal.Header.props 
            |> ReactNode.unit
            |> hasChild 1 child
        }
        
        test "renders props" {
            let complexChildContent = R.div [ClassName "h1"] [R.str  "Cirão da Massa"]
            let child = complexChildContent |> ReactNode.unit 
            let props = { Modal.Header.props with HTMLProps = [Id "hello-world"] } 
        
            [complexChildContent]
            |> Modal.Header.Children.Elements
            |> Modal.Header.ƒ props
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
            let footer = Modal.Footer.props, [content] |> Modal.Footer.Children.Elements
            
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
            let primaryButton = buttons.[0] ||> Button.ƒ |> ReactNode.unit 
            let linkButton = buttons.[1] ||> Button.ƒ |> ReactNode.unit 
        
            let footer = Modal.Footer.props, buttons |> Modal.Footer.Children.Buttons
            
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
            let props = { Modal.Footer.props with HTMLProps = [Id "hello-world"] } 
        
            (props, Modal.Footer.Children.Elements [complexChildContent])
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
              Modal.ƒ Modal.props Modal.children
              |> ReactNode.unit
              |>! hasClass "modal active"
              |>! hasDescendentClass "modal-overlay modal-container modal-body"
              |>! hasNoDescendentClass "modal-header modal-footer"
              |> hasText ""
        }
        
        test "renders props" {
            let props =  { Modal.props with HTMLProps = [Id "pele"] }
            Modal.ƒ props Modal.children
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
            
            let props =  { Modal.props with
                OnRequestClose = happyFunction |> Some
            }
            Modal.ƒ props Modal.children
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
            let propsSmall =  { Modal.props with Size = Modal.Size.Small }
            let propsMedium =  { Modal.props with Size = Modal.Size.Medium }
            let propsLarge =  { Modal.props with Size = Modal.Size.Large }
            
            Modal.ƒ propsSmall Modal.children
            |> ReactNode.unit
            |> hasClass "modal active modal-sm"
            
            Modal.ƒ propsMedium Modal.children
            |> ReactNode.unit
            |> hasClass "modal active"
            
            Modal.ƒ propsLarge Modal.children
            |> ReactNode.unit
            |> hasClass "modal active modal-lg"
        }
        
        test "renders body contents" {
            let babyLookAtThisBody = R.str "I work out!"
            Modal.ƒ Modal.props {
                Header = None
                Footer = None
                Body = [babyLookAtThisBody]
            }
            |> ReactNode.unit
            |> hasChild 1 (babyLookAtThisBody |> ReactNode.unit)
        }
        
        test "renders header contents" {
            let headerConfig = Modal.Header.props, (Modal.Header.Text "Ciro 12")
            let headerChild = headerConfig ||> Modal.Header.ƒ |> ReactNode.unit
        
            Modal.ƒ Modal.props {
                Header = headerConfig |> Some
                Footer = None
                Body = []
            }
            |> ReactNode.unit
            |>! hasDescendentClass "modal-header"
            |> hasChild 1 headerChild
        }
        
        test "renders footer contents" {
            let footerT = Modal.Footer.props, Modal.Footer.Children.Elements <| [R.str "Yooolo"] 
            let footerChild = Modal.Footer.ƒ footerT |> ReactNode.unit
                   
            Modal.ƒ Modal.props {
                Header = None
                Body = []
                Footer =  footerT |> Some
            }  
            |> ReactNode.unit
            |>! hasDescendentClass "modal-footer"
            |> hasChild 1 footerChild
            
        }
    ]
    