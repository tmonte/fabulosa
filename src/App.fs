module App

open Fable.Import.Browser
open Fable.Core.JsInterop

importAll "./styles.scss"

open Elmish
open Button

type Model = int

type Message = None

let init (): Model * Cmd<Message> = 0, []

let update (msg: Message) (model: Model): Model * Cmd<Message> =
    match msg with
    | None -> model, []

module R = Fable.Helpers.React

let view (model: Model) (dispatch: Dispatch<'a>) =
    R.div []
      [ button (fun event -> event.target |> console.log ) "hey" ]

open Elmish.React

Program.mkProgram init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run