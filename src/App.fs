module App

open Fable.Import.Browser
open Fable.Core.JsInterop
open Fable.Helpers.React.Props

importAll "./styles.scss"

open Elmish
open Button
open Grid
open Responsive
open Elmish.Browser.UrlParser
open Elmish.Browser.Navigation

type Page =
  | ButtonPage
  | HomePage

type Model = {
    currentPage: Page
}

type Message = int

let toHash page =
  match page with
  | ButtonPage -> "#button"
  | HomePage -> "#home"

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map ButtonPage (s "button")
    map HomePage (s "home")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      { model with currentPage = page }, []

let init result =
    let (model, cmd) =
        urlUpdate result { currentPage = HomePage }
    model, Cmd.batch [ cmd ]

let update (msg: Message) (model: Model): Model * Cmd<Message> =
    match msg with
    | _ -> model, []

module R = Fable.Helpers.React

let view (model: Model) (dispatch: Dispatch<'a>) =
    let pageHtml =
        function
        | ButtonPage -> ButtonPage.view ()
        | HomePage -> Home.view ()
    R.div [] [ pageHtml model.currentPage]

open Elmish.React

Program.mkProgram init update view
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
|> Program.run