module ModalPage

open Fabulosa
open Fabulosa.Docs
open Fabulosa.Button
open Fabulosa.Grid
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer
open Fabulosa.Media.Figure
open Fabulosa.Modal
open Fabulosa.Button

let button1: Button = ([], [R.str "Click me!"])

(*** define: modal-sample ***)
let header = (Some ([], Text "A quote"))
let body = 
    [ figure ( [ Caption ([], Media.Caption.Children.Text "Choose your destiny" ) ], 
                Image [P.Src "https://multimidia.gazetadopovo.com.br/media/info/posicionamento-economico.png?12"] )   
      Typography.blockquote [] [R.str "History repeats itself, first as tragedy, second as farce."] ]
let footer = Some ( [], Buttons [ button1 ] ) 
      
let smallModal: Modal = 
    [], 
    ( Header header, 
      Body body, 
      Footer footer ) 
    
module Container =
    open Fabulosa.Extensions
    open Fable.Import
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Helpers.React.ReactiveComponents
    module P = R.Props
    
    type State = { Opened: bool}
    type Message = 
        | Open
        | Close
    
    type private Dispatch = Message -> unit
    
    let private init _ = { Opened = false }
    
    let private update message state =
        match message with 
        | Open -> { state with Opened = true }
        | Close -> { state with Opened = false }
    
    let private view (model: Model<Modal, State>) (dispatch: Dispatch) =
        
        let modalData = 
            model.props 
            |> Modal.setOpen model.state.Opened
            |> Modal.setOnRequestClose (fun _ -> dispatch Close)
        
        R.fragment [][
            button ([ Button.Kind Primary; P.OnClick (fun _ -> dispatch Open) ], [R.str (sprintf "Open %A Modal" 5)]) 
            modal modalData
        ]
    
    let container (content : Modal) =
        R.reactiveCom
            init
            update
            view
            ""
            content
            []
            
(*** hide ***)
let style = P.Style [P.Background "#f8f9fa"; P.TextAlign "center"; P.Padding "20px"]
let demo = R.div [style] [ 
        grid
            ([],
             [ Row
                 ([],
                  [ Column
                      ([ Grid.Size 4; SMSize 12 ],
                       [ Container.container smallModal ])
                    Column
                      ([ Grid.Size 4; SMSize 12 ],
                       [  ])
                    Column
                      ([ Grid.Size 4; SMSize 12 ],
                       [  ]) ]) ])
    ]

let render () =
    tryMount "modal-demo" demo
//    tryMount "modal-props-table" (PropTable.propTable typeof<Modal.Props> Modal.props)
//    tryMount "modal-header-props-table" (PropTable.propTable typeof<Modal.Header.Props> Modal.Header.props)
//    tryMount "modal-footer-props-table" (PropTable.propTable typeof<Modal.Footer.Props> Modal.Footer.props)
(**

<div id="modal">
    <h2 class="s-title">Modal</h2>
    Modals are flexible dialog prompts.
</div>

<div id="modal-props">
    <h3 class="s-title">Modal Props</h3>
    <div class="props-table" id="modal-props-table"></div>
    <h3 class="s-title">Header Props</h3>
    <div class="props-table" id="modal-header-props-table"></div>
    <h3 class="s-title">Footer Props</h3>
    <div class="props-table" id="modal-footer-props-table"></div>
</div>

<div id="modal-default">
    <h3 class="s-title">Example</h3>
    Modals come in 3 different sizes:
    <div class="demo" id="modal-demo"></div>
</div>
*)

(*** include: modal-sample ***)

