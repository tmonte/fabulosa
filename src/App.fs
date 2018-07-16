module App

open Fable.Import.Browser
open Fable.Core.JsInterop
open Fable.Helpers.React.Props

importAll "./styles.scss"

open Elmish
open Button

type Model = int

type Message = None

type ModelAction = Model * Cmd<Message>

let init (): ModelAction = 0, []

let update (msg: Message) (model: Model): ModelAction =
    match msg with
    | None -> model, []

module R = Fable.Helpers.React

let view (model: Model) (dispatch: Dispatch<'a>) =
    R.div []
      [ button
            (SpectreProps [Size Small; Kind Primary;])
            (HTMLProps [OnClick (fun event -> event.target |> console.log)])
            (Children [R.str "TEXT"])
      ]

open Elmish.React

Program.mkProgram init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run