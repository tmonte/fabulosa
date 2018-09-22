namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fable.Import
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Helpers.React.ReactiveComponents
    open R.Props

    [<RequireQualifiedAccess>]
    module Item =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (item: T) =
            R.li [ ClassName "menu-item" ] item

    [<RequireQualifiedAccess>]
    module Divider =

        [<RequireQualifiedAccess>]
        type T = string option

        let ƒ (divider: T) =
            match divider with
            | Some text ->
                R.li
                    [ ClassName "divider"
                      Data ("content", text) ] []
            | None ->
                R.li
                    [ ClassName "divider" ] []

    [<RequireQualifiedAccess>]
    module Trigger =

        [<RequireQualifiedAccess>]
        type Message =
        | Click of int * int

        [<RequireQualifiedAccess>]
        type private Props =
            Message -> unit

        [<RequireQualifiedAccess>]
        type private Children = Button.T

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props _ = ()

        let children =
            Button.props,
            [ Icon.ƒ
                { Icon.props with Kind = Icon.Kind.Menu } ]

        let onClick (e: MouseEvent) =
            let element = e.currentTarget :?> Browser.Element
            let rect = element.getBoundingClientRect ()
            let x = (rect.left |> int) + (Browser.window.scrollX |> int)
            let y = (rect.bottom |> int) + (Browser.window.scrollY |> int)
            Message.Click (x, y)

        let ƒ (trigger: T) =
            let props, children = trigger
            let cProps, cChildren = children
            let withClick =
                cProps.HTMLProps @ [ OnClick (onClick >> props) ]
            Anchor.ƒ
                ( { cProps with
                      HTMLProps = withClick },
                  cChildren )

    [<RequireQualifiedAccess>]
    module Container =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Opened: bool
              Position: int * int }

        [<RequireQualifiedAccess>]
        type Children = ReactElement []

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let props =
            { Props.HTMLProps = []
              Props.Opened = false
              Props.Position = 0, 0 }

        let ƒ (container: T) =
            let props, children = container
            let (x, y) = props.Position
            if props.Opened then
                props.HTMLProps
                @
                [ Style
                    [ Position "absolute"
                      Left x
                      Top y ] ]
                |> addProp (ClassName "menu")
                |> R.ul <| children
            else R.ofOption None

    [<RequireQualifiedAccess>]
    type Child =
    | Item of ReactElement list
    | Divider of Divider.T

    [<RequireQualifiedAccess>]
    type Children = Child list

    type Props =
        { HTMLProps: HTMLProps
          Trigger: Button.T
          Opened: bool }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    type State =
        { Opened: bool
          Position: int * int }
                
    let private renderChild =
        function
        | Child.Item elements -> Item.ƒ elements
        | Child.Divider divider -> Divider.ƒ divider

    let private renderChildren children =
        List.map renderChild children

    let private init (props: Props) =
        { Opened = props.Opened
          Position = Container.props.Position }

    let private update message state =
        match message with
        | Trigger.Message.Click (x, y) ->
            { state with
                Opened = not state.Opened
                Position = x, y }

    let private view model dispatch =
        R.fragment [] 
            [ Trigger.ƒ (dispatch, model.props.Trigger)
              Container.ƒ
                ({ Opened = model.state.Opened
                   Position = model.state.Position
                   HTMLProps = model.props.HTMLProps },
                 model.children)
              |> Portal.ƒ "menu-container" ]

    let props =
        { HTMLProps = Container.props.HTMLProps
          Trigger = Trigger.children
          Opened = Container.props.Opened }

    let ƒ (menu: T) =
        let props, children = menu
        R.reactiveCom
            init
            update
            view
            ""
            props
            (renderChildren children)