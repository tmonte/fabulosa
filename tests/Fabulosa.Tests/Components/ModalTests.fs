module ModalTests

open Expecto
open Fabulosa
open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Expect
open ReactNode
open Fabulosa.Modal


[<Tests>]
let headerTests =
    testList "Modal Header tests" [
        test "renders with text" {        
            let headerText = "Quem tem por que viver pode suportar quase qualquer como."
            let child = R.div [P.ClassName "modal-title h5"] [R.str headerText] |> ReactNode.unit 
            
            header ([], Text headerText) 
            |> ReactNode.unit
            |> hasChild 1 child
        }
        
        test "renders with element" {
            let complexChildContent = R.div [P.ClassName "h1"] [R.str  "Wie man mit dem Hammer philosophiert"]
            let child = complexChildContent |> ReactNode.unit 
        
            header ([], HeaderChildren.Elements [ complexChildContent ])
            |> ReactNode.unit
            |> hasChild 1 child
        }
        
        test "renders props" {
            let complexChildContent = R.div [P.ClassName "h1"] [R.str  "Wie man mit dem Hammer philosophiert"]
            let child = complexChildContent |> ReactNode.unit 
            header ([P.Id "hello-world"], HeaderChildren.Elements [ complexChildContent ])
            |> ReactNode.unit
            |>! hasProp (P.Id "hello-world")
            |> hasChild 1 child
        }
    ]
    
[<Tests>]
let footerTests =    
    testList "Modal Footer" [
        test "renders with element" {
            let content = R.div [P.ClassName "h1"] [R.str  "Wie man mit dem Hammer philosophiert"]
            let child = content |> ReactNode.unit 
        
            footer ([], Elements [content])
            |> ReactNode.unit
            |>! hasUniqueClass "modal-footer"
            |> hasChild 1 child
        }
        
        test "renders with buttons" {
            let buttons: Button list = [
                [ Kind Primary ], [R.str "Submit"]
                [ Kind Link ], [R.str "Close"]
            ]
            let primaryButton = buttons.[0] |> button |> ReactNode.unit 
            let linkButton = buttons.[1] |> button |> ReactNode.unit 
        
            footer ([], Buttons buttons)
            |> ReactNode.unit
            |>! hasUniqueClass "modal-footer"
            |>! hasChild 1 primaryButton
            |> hasChild 1 linkButton
        }
        
        test "renders props" {
            let complexChildContent = R.div [P.ClassName "h1"] [R.str  "trotzdem Ja zum Leben sagen"]
            let child = complexChildContent |> ReactNode.unit 
                    
            footer ([P.Id "hello-world"], Elements [complexChildContent])
            |> ReactNode.unit
            |>! hasProp (P.Id "hello-world")
            |> hasChild 1 child
        }
    ]
    
open Fabulosa.Modal
[<Tests>]
let modalTests =    
    testList "Modal" [
        test "does not render empty modal" {
            Expect.isNull (modal ([], (Header None, Body [], Footer None))) "Should be null"
        }

        test "renders default props" {
              modal ([Open true], (Header None, Body [], Footer None))
              |> ReactNode.unit
              |>! hasClass "modal active"
              |>! hasDescendentClass "modal-overlay modal-container modal-body"
              |>! hasNoDescendentClass "modal-header modal-footer"
              |> hasText ""
        }
        
        test "renders props" {
             modal ([Open true; P.Id "socrates"], (Header None, Body [R.str ""], Footer None))
            |> ReactNode.unit
            |>! hasProp (P.Id "socrates")
            |>! hasClass "modal active"
            |>! hasDescendentClass "modal-container"
            |>! hasDescendentClass "modal-body"
            |> hasText ""
        }
        
        test "configures OnClose overlay" {
            let happyFunction parms = ()
            let overlay = R.a [P.ClassName "modal-overlay"; P.OnClick happyFunction] []
            let buttonClose = R.a [P.ClassName "btn btn-clear float-right"; P.OnClick happyFunction] []

            modal ([Open true; OnRequestClose happyFunction], (Header None, Body [], Footer None))
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
            let children = (Header None, Body [], Footer None)
            
            modal ([Open true; Size Small], children)
            |> ReactNode.unit
            |> hasClass "modal active modal-sm"
            
            modal ([Open true; Size Medium], children)
            |> ReactNode.unit 
            |> hasClass "modal active"
            
            modal ([Open true; Size Large], children) 
            |> ReactNode.unit 
            |> hasClass "modal active modal-lg"
        }
        
        test "renders body contents" {
            let body = R.str "I love this body. I work out!"
            
            modal ([Open true], (Header None, Body [body], Footer None))  
            |> ReactNode.unit
            |> hasChild 1 (body |> ReactNode.unit)
        }
        
        test "renders header contents" {
            let headerElement = [], Text "Tudo que sei é que nada sei."
            let headerChild = header headerElement
            
            modal ([Open true], (Header ( Some headerElement), Body [], Footer None))
            |> ReactNode.unit
            |>! hasDescendentClass "modal-header"
            |> hasChild 1 (headerChild |> ReactNode.unit)
        }
        
        test "renders footer contents" {
            let footerElement = [], Elements [R.str "Tudo que sei é que nada sei."]
            let footerChild = footer footerElement
            
            modal ([Open true], (Header None, Body [], Footer (Some footerElement)))
            |> ReactNode.unit
            |>! hasDescendentClass "modal-footer"
            |> hasChild 1 (footerChild |> ReactNode.unit)
        }
    ]
    