namespace Fabulosa

module Menu =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

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
        { Props.HTMLProps = [] }

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

    let ƒ (props: Props) (children: Children) =
        props.HTMLProps
        |> addProp (ClassName "menu")
        |> R.ul <| renderChildren children