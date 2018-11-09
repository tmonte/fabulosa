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
let header: HeaderData option = (Some ([], Text "A quote"))
let body = [ R.str "History repeats itself, first as tragedy, second as farce." ]
let footer = Some ([], Buttons [ button1 ]) 
(*** define: modal-sample ***)
let def =
    modal ([], 
        (Header header, 
         Body body, 
         Footer footer))
(*** hide ***)
let modalData: Modal = 
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
    
    let private view (model: Model<Modal * Size, State>) (dispatch: Dispatch) =
        let props, size = model.props
        
        let modalData = 
            props
            |> Modal.addProps 
                [ Modal.Open model.state.Opened 
                  Size size  
                  OnRequestClose (fun _ -> dispatch Close) ]
                
        R.fragment [][
            button ([ Button.Kind Primary; P.OnClick (fun _ -> dispatch Open) ], [R.str (sprintf "Open %A Modal" size)]) 
            modal modalData
        ]
    
    let container (content : Modal * Size) =
        R.reactiveCom
            init
            update
            view
            ""
            content
            []
            
let style = P.Style [P.Background "#f8f9fa"; P.TextAlign "center"; P.Padding "20px"]
let demo = R.div [style] [ 
        grid
            ([],
             [ Row
                 ([],
                  [ Column
                      ([ Grid.Size 4; SMSize 12 ],
                       [ Container.container (modalData, Small) ])
                    Column
                      ([ Grid.Size 4; SMSize 12 ],
                       [ Container.container (modalData, Medium)  ])
                    Column
                      ([ Grid.Size 4; SMSize 12 ],
                       [ Container.container (modalData, Large)  ]) ]) ])
    ]

let render () =
    tryMount "modal-demo" demo
    tryMount "modal-props-table"
        (PropTable.paramTable
            (Some typeof<ModalOptional>)
            None
            (Some typeof<ModalChildren>))
(**

<div id="modal">

<h2 class="s-title">Modal</h2>

Modals are flexible dialog prompts.

#### Modal Parameters

<div class="props-table" id="modal-props-table"></div>

#### Example

Modals come in 3 different sizes:

<div class="demo" id="modal-demo"></div>

*)
(*** include: modal-sample ***)
(**

</div>

*)
