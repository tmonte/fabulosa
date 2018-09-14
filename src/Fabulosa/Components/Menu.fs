namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fable.Import.React
    open Fable.Import.JS
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Trigger = Button.Props * string

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Root: string
          Trigger: Trigger
          Open: bool
          Position: int * int }

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
          Props.Root = "body"
          Props.Trigger = Button.defaults, "Menu"
          Props.Open = false
          Props.Position = 0, 0 }

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

    let private renderTrigger (trigger: Trigger) =
        let props, children = trigger
        Anchor.ƒ
            props
            [ R.str children ]

    let ƒ (props: Props) (children: Children) =
        let existing = Fable.Import.Browser.document.getElementById "menu-container"
        let element =
            if existing = null then
                let created = Fable.Import.Browser.document.createElement "div"
                created.id <- "menu-container"
                let root = Fable.Import.Browser.document.body
                root.appendChild created |> ignore
                created
            else existing
        let (x, y) = props.Position
        let menu =
            if props.Open then
                props.HTMLProps @ [Style [Position "fixed"; Left x; Top y]]
                |> addProp (ClassName "menu")
                |> R.ul <| renderChildren children
            else R.ofOption None
        [ renderTrigger props.Trigger; Fable.Import.ReactDom.createPortal (menu, element) ]
        |> R.fragment []

