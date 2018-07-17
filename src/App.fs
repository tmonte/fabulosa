module App

open Fable.Import.Browser
open Fable.Core.JsInterop
open Fable.Helpers.React.Props

importAll "./styles.scss"

open Elmish
open Button
open Grid
open Responsive

type Model = int

type Message = None

type ModelAction = Model * Cmd<Message>

let init (): ModelAction = 0, []

let update (msg: Message) (model: Model): ModelAction =
    match msg with
    | None -> model, []

module R = Fable.Helpers.React

let view (model: Model) (dispatch: Dispatch<'a>) =
    R.div [] [
        responsive [Hide SM] button
            [ButtonSize Small; ButtonKind Primary]
            [OnClick (fun event -> event.target |> console.log)]
            [R.str "TEXT"]
        grid [] [
            columns [ColumnsKind Gapless] [] [
                column [ColumnSize 1] [] [R.str "Column 1"]
                column [ColumnSize 11] [] [R.str "Column 11"]
            ]
        ]
    ]

open Elmish.React

Program.mkProgram init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run