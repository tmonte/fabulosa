module App

open Fable.Import.Browser
open Fable.Core.JsInterop

importAll "./styles.scss"

open Elmish
open Elmish.Browser.UrlParser
open Elmish.Browser.Navigation
module R = Fable.Helpers.React
open R.Props

type Page =
  | GridPage
  | ButtonPage
  | TablePage
  | HomePage

type Model = {
    currentPage: Page
}

type Message = int

let toHash page =
    match page with
    | GridPage -> "#grid"
    | ButtonPage -> "#button"
    | TablePage -> "#table"
    | HomePage -> "#home"

let pageParser: Parser<Page->Page,Page> =
    oneOf [
        map GridPage (s "grid")
        map ButtonPage (s "button")
        map TablePage (s "table")
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
    R.div [ClassName "app-menu"] [
        R.div [ClassName "app-brand"] [
            R.a [ClassName "app-logo"] [
                R.img [Src "logo.svg"; Style [Width 32; Margin 10]]
                R.strong [] [R.str "FABULOSA"]
            ]
        ]
        R.ul [ ClassName "nav" ] [
            menuItem "Home" HomePage currentPage
            menuItem "Button" ButtonPage currentPage
            menuItem "Grid" GridPage currentPage
            menuItem "Table" TablePage currentPage
        ]
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
        | TablePage -> TablePage.view ()
        | HomePage -> Home.view ()
    R.div [ClassName "off-canvas off-canvas-sidebar-show"] [
        R.div [Id "sidebar-id"; ClassName "off-canvas-sidebar"] [
            menu model.currentPage
        ]
        R.a [ClassName "off-canvas-toggle btn btn-primary btn-action"; Href "#sidebar-id"] [
            R.i [ClassName "icon icon-menu"] []
        ]
        R.a [ClassName "off-canvas-overlay"; Href "#close"] []
        R.div [ClassName "off-canvas-content app-page"] [
            Navbar.header [] [
                Navbar.section [] []
                Navbar.section [] [Button.button [Button.Kind Button.Primary] [] [R.str "GitHub"]]
            ]
            pageHtml model.currentPage
        ]
    ]

open Elmish.React

Program.mkProgram init update view
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
|> Program.run