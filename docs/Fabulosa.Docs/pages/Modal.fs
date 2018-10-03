module ModalPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: modal-sample ***)
let modal = 
    Modal.ƒ (Modal.props, 
        {
            Header = (Modal.Header.props, Modal.Header.Children.Text "#Cirão da massa") |> Some
            Body = [
                Media.Figure.ƒ 
                    (Media.Figure.props, {
                        Image = { Media.Image.props with HTMLProps = [Src "https://multimidia.gazetadopovo.com.br/media/info/posicionamento-economico.png?12"] }
                        Caption = (Media.Caption.props, Media.Caption.Children.Text "Choose your destiny") |> Some
                    })
            ]
            Footer = (
                Modal.Footer.props, 
                [
                    (Button.props, [R.str "Vote Amoerda"])
                    ({Button.props with Kind = Button.Primary}, [R.str "Vote Ciro 12"])
                ] |> Modal.Footer.Buttons)  
            |> Some
        }
    )

(*** hide ***)
module Container =
 open Fabulosa.Extensions
    open Fable.Import
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Helpers.React.ReactiveComponents
    open R.Props
    
    type Props = { Dumb: bool}
    type State = { Opened: bool}
    type Children = ReactElement list
    type Message = 
        | Open
        | Close
    type T = Props * Children
    type private Dispatch = Message -> unit
    
    let private init (props: Props) = { Opened = false }

    let private update message state =
       match message with 
       | Open -> { state with Opened = true }
       | Close -> { state with Opened = false }

    let private view (model: Model<Props, State>) (dispatch: Dispatch) =
        R.fragment [][
            R.div [] [
                Button.ƒ ({Button.props with Kind = Button.Primary; HTMLProps = [OnClick (fun _ -> dispatch Open)] }, [R.str "Open Modal"])
            ] 
            Modal.ƒ (
                { Modal.props with 
                    IsOpen = model.state.Opened
                    OnRequestClose = Some (fun _ -> dispatch Close)
                }, 
                {
                    Header = (Modal.Header.props, Modal.Header.Children.Text "#Cirão da massa") |> Some
                    Body = [
                        Media.Figure.ƒ 
                            (Media.Figure.props, {
                                Image = { Media.Image.props with HTMLProps = [Src "https://multimidia.gazetadopovo.com.br/media/info/posicionamento-economico.png?12"] }
                                Caption = (Media.Caption.props, Media.Caption.Children.Text "Choose your destiny") |> Some
                            })
                    ]
                    Footer = (
                        Modal.Footer.props, 
                        [
                            (Button.props, [R.str "Vote Coiso"])
                            ({Button.props with Kind = Button.Primary}, [R.str "Vote Ciro 12"])
                        ] |> Modal.Footer.Buttons)  
                    |> Some
                }
            )
        ]
    
    let ƒ (container : T) =
        let props, children = container
        R.reactiveCom
            init
            update
            view
            ""
            props
            []




let demo = R.div [Style [MaxWidth "50%"]] [
    Container.ƒ ({ Dumb = true }, [])
]

let render () =
    tryMount "modal-demo" demo
    tryMount "modal-props-table" (PropTable.propTable typeof<Modal.Props> Modal.props)
(**

<div id="modal">
    <h2 class="s-title">Cards</h2>
    Modal
</div>

<div id="modal-props">
    <h3 class="s-title">Props</h3>
    <div class="props-table" id="modal-props-table"></div>
</div>

<div id="modal-default">
    <h3 class="s-title">Default</h3>
    The default modal
    <div class="demo" id="modal-demo"></div>
</div>
*)

(*** include: modal-sample ***)

