namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fabulosa.Icon
    open Fabulosa.Button
    open Fable.Import
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Helpers.React.ReactiveComponents
    module P = R.Props

    type MenuItem = ReactElement list

    let menuItem (comp: MenuItem) =
        R.li [ P.ClassName "menu-item" ] comp

    type MenuDividerOptional =
        | Text of string
        interface P.IHTMLProp

    type MenuDivider =
        P.HTMLProps

    let private menuDividerText (prop: P.IHTMLProp) =
        match prop with
         | :? MenuDividerOptional as opt ->
             match opt with
             | Text txt ->
                 P.Data ("content", txt) :> P.IHTMLProp
         | _ -> prop 

    let menuDivider (opt: MenuDivider) =
        opt
        |> P.addProp (P.ClassName "divider")
        |> P.map menuDividerText
        |> P.merge
        |> R.li <| []

    type TriggerMessage =
        Click of int * int

    type private TriggerRequired =
        TriggerMessage -> unit

    type TriggerChildren =
        Button of Button

    type private Trigger = TriggerRequired * TriggerChildren

    let private onTriggerClicked (e: MouseEvent) =
        Fable.Import.JS.console.log e
        let element = e.currentTarget :?> Browser.Element
        let rect = element.getBoundingClientRect ()
        let x = (rect.left |> int) + (Browser.window.scrollX |> int)
        let y = (rect.bottom |> int) + (Browser.window.scrollY |> int)
        TriggerMessage.Click (x, y)

    let menuTrigger (comp: Trigger) =
        let req, (Button btn) = comp
        let btnOpt, btnChi = btn
        let withClick =
            btnOpt
            |> P.addProps
                [ P.ClassName "btn"
                  P.OnClick (onTriggerClicked >> req) ]
            |> P.merge
        R.a withClick btnChi

    type MenuContainerOptional =
        | Opened
        interface P.IHTMLProp

    type MenuContainerRequired =
        Position of int * int

    type MenuContainerChildren = ReactElement []

    type private MenuContainer =
        P.HTMLProps * MenuContainerRequired * MenuContainerChildren

    let menuContainer (comp: MenuContainer) =
        let opt, (Position (x, y)), chi = comp
        Fable.Import.JS.console.log opt
        let v =
            List.tryPick
                (fun (prop: P.IHTMLProp) ->
                    match prop with
                    | :? MenuContainerOptional as opt ->
                        match opt with
                        | Opened ->
                            Some (R.ul
                                [ P.Style
                                    [ P.Position "absolute"
                                      P.Left x
                                      P.Top y ] ] chi)
                    | _ -> None)
                opt
        Fable.Import.JS.console.log v
        v |> R.ofOption

    type MenuChild =
    | Item of MenuItem
    | Divider of MenuDivider

    type MenuChildren =
        MenuChild list

    type MenuRequired =
        Trigger of Button

    type Menu =
        P.HTMLProps * MenuRequired * MenuChildren

    type State =
        { Opened: bool
          Position: int * int }

    let private init (opt, req) =
        let opened =
            List.tryFind
                (fun (prop: P.IHTMLProp) ->
                    match prop with
                    | :? MenuContainerOptional as opt ->
                        match opt with
                        | Opened -> true
                    | _ -> false)
                opt
        { Opened = opened.IsSome
          Position = 0, 0 }

    let private update message state =
        Fable.Import.JS.console.log message
        match message with
        | TriggerMessage.Click (x, y) ->
            { state with
                Opened = not state.Opened
                Position = x, y }

    let private view (model) dispatch =
        let opt, (Trigger trig) = model.props
        let opn =
            if model.state.Opened then [ Opened :> P.IHTMLProp ] else [] 
        R.fragment [] 
            [ menuTrigger (dispatch, Button trig)
              menuContainer
                (opn, Position model.state.Position, 
                 model.children)
              |> Portal.ƒ "menu-container" ]

    let menu (comp: Menu) =
        let opt, req, children = comp
        R.reactiveCom
            init
            update
            view
            ""
            (opt, req)
            (Seq.map
                (function
                 | Item elements -> menuItem elements
                 | Divider divider -> menuDivider divider)
                children)
                