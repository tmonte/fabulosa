namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fable.Import.React
    open Fable.Import.JS
    module Browser =  Fable.Import.Browser
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Position = int * int

    [<RequireQualifiedAccess>]
    type Trigger = Button.Props * string
    
    [<RequireQualifiedAccess>]
    type GetPosition = Position -> unit

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Trigger: Trigger
          Open: bool
          Position: int * int
          GetPosition: GetPosition }

    [<RequireQualifiedAccess>]
    type Divider =
    | Text of string
    | Empty

    [<RequireQualifiedAccess>]
    type Child =
    | Item of ReactElement seq
    | Divider of Divider

    [<RequireQualifiedAccess>]
    type Children = Child seq

    let defaults =
        { Props.HTMLProps = []
          Props.Trigger = Button.defaults, "Menu"
          Props.Open = false
          Props.Position = 0, 0
          Props.GetPosition = fun (_, _) -> () }

    let private renderItem =
        R.li [ClassName "menu-item"]

    let private renderDivider =
        function
        | Divider.Text text ->
            R.li
                [ ClassName "divider"
                  Data ("content", text) ] []
        | Divider.Empty ->
            R.li
                [ ClassName "divider" ] []
 
    let private renderChild =
        function
        | Child.Item elements -> renderItem elements
        | Child.Divider divider -> renderDivider divider

    let private renderChildren children =
        Seq.map renderChild children

    let private onClick (e: MouseEvent) (getPos: GetPosition)=
        let element = e.currentTarget :?> Browser.Element
        let rect = element.getBoundingClientRect ()
        getPos (rect.left |> int, rect.bottom |> int)
        
    let private renderTrigger (trigger: Trigger) (getPos: GetPosition) =
        let props, children = trigger
        Anchor.ƒ
            { props with
                HTMLProps = props.HTMLProps
                    @ [ OnClick (fun e -> onClick e getPos ) ] }
            [ R.str children ]

    let private renderMenu (props: Props) children =
        let (x, y) = props.Position
        if props.Open then
            props.HTMLProps
            @
            [ Style
                [ Position "fixed"
                  Left x
                  Top y ] ]
            |> addProp (ClassName "menu")
            |> R.ul <| renderChildren children
        else R.ofOption None

    let ƒ (props: Props) children =
        [ renderTrigger props.Trigger props.GetPosition
          renderMenu props children |> Portal.ƒ "menu-container" ]
        |> R.fragment []

