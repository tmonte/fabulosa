module App

open Fable.Import.Browser
open Fable.Core.JsInterop

importAll "./styles.scss"

open Elmish
open Elmish.Browser.UrlParser
open Elmish.Browser.Navigation
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

type Page =
  | GridPage
  | ButtonPage
  | HomePage

type Model = {
    currentPage: Page
}

type Message = int

let toHash page =
    match page with
    | GridPage -> "#grid"
    | ButtonPage -> "#button"
    | HomePage -> "#home"

let pageParser: Parser<Page->Page,Page> =
    oneOf [
        map GridPage (s "grid")
        map ButtonPage (s "button")
        map HomePage (s "home")
    ]

let menuItem label page currentPage =
    R.li
      [ ClassName "nav-item" ]
      [ R.a
          [ R.classList [ "is-active", page = currentPage ]
            Href (toHash page) ]
          [ R.str label ] ]

let menu currentPage =
    R.ul [ ClassName "nav" ] [
        menuItem "Home" HomePage currentPage
        menuItem "Button" ButtonPage currentPage
        menuItem "Grid" GridPage currentPage
    ]

let urlUpdate (result: Option<Page>) model =
    match result with
    | None ->
        console.error("Error parsing url")
        model, Navigation.modifyUrl (toHash model.currentPage)
    | Some page ->
        { model with currentPage = page }, []

let init result =
    let (model, cmd) =
        urlUpdate result { currentPage = HomePage }
    model, Cmd.batch [ cmd ]

let update (msg: Message) (model: Model): Model * Cmd<Message> =
    match msg with
    | _ -> model, []

let view (model: Model) (dispatch: Dispatch<'a>) =
    let pageHtml =
        function
        | GridPage -> GridPage.view ()
        | ButtonPage -> ButtonPage.view ()
        | HomePage -> Home.view ()
    R.div [] [
        Grid.grid [] [
            Grid.columns [] [] [
                Grid.column [Grid.Column.Size 2] [] [
                    menu model.currentPage
                ]
                Grid.column [Grid.Column.Size 10] [] [
                    Navbar.header [] [
                        Navbar.section [] [
                            Navbar.brand [] [R.str "Fabulosa"]
                        ]
                        Navbar.center [] [R.str "NICE_LOGO"]
                        Navbar.section [] [R.str "Github"]
                    ]
                    pageHtml model.currentPage
                ]
            ]
        ]
    ]

open Elmish.React

Program.mkProgram init update view
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
|> Program.run