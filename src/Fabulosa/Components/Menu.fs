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
          Trigger: Trigger }

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
          Props.Trigger = Button.defaults, "Menu" }

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
            { props with
                HTMLProps =
                    [ OnClick (fun (e: MouseEvent) -> console.log e) ] }
            [ R.str children ]

    let ƒ (props: Props) (children: Children) =
        // let el = Fable.Import.Browser.document.createElement "div"
        // el.className <- "menu-container"
        // let root = Fable.Import.Browser.document.body
        // root.appendChild el |> ignore
        [ renderTrigger props.Trigger;
          props.HTMLProps
          |> addProp (ClassName "menu")
          |> R.ul <| renderChildren children ]
        |> R.fragment []
        
        //Fable.Import.ReactDom.createPortal (menu, el)
