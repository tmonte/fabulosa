namespace Fabulosa

module Button =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type Kind =
        | Default
        | Primary
        | Link

    type Color =
        | Success
        | Error

    type Size =
        | Small
        | Large

    type State =
        | Disabled
        | Active
        | Loading

    type Shape =
        | Squared
        | Round

    type ButtonOptional =
        | Kind of Kind
        | Color of Color
        | Size of Size
        | State of State
        | Shape of Shape
        interface IHTMLProp

    type Button = HTMLProps * ReactElement list

    let private props (prop: IHTMLProp) =
        match prop with
        | :? ButtonOptional as opt ->
            match opt with
            | Kind Default -> "btn-default"
            | Kind Primary -> "btn-primary"
            | Kind Link -> "btn-link"
            | Color Success -> "btn-success"
            | Color Error -> "btn-error"
            | Size Small -> "btn-sm"
            | Size Large -> "btn-lg"
            | State Disabled -> "disabled"
            | State Loading -> "loading"
            | State Active -> "active"
            | Shape Squared -> "btn-action"
            | Shape Round -> "btn-action circle"
            |> ClassName
            :> IHTMLProp
        | _ -> prop

    let button (c: Button) =
        let optional, children = c
        optional
        |> List.map props
        |> addProp (ClassName "btn")
        |> R.button <| children
        
//[<RequireQualifiedAccess>]
//module Anchor =

//    open Fable.Import.React
//    open Fabulosa.Extensions
//    module R = Fable.Helpers.React
//    open R.Props

//    [<RequireQualifiedAccess>]
//    type Children = ReactElement list

//    [<RequireQualifiedAccess>]
//    type T = Button.T

//    let props = Button.props

//    let build (anchor: T) =
//        let props, children = anchor
//        props.HTMLProps
//        |> addProps
//            [ ClassName "btn"
//              Button.kind props.Kind
//              Button.size props.Size
//              Button.color props.Color
//              Button.state props.State
//              Button.format props.Format ]
//        |> R.a <| children

//    let ƒ = build

//module ButtonGroup =

    //open Fabulosa.Extensions
    //module R = Fable.Helpers.React
    //open R.Props

    //[<RequireQualifiedAccess>]
    //type Block = bool

    //[<RequireQualifiedAccess>]
    //type Props =
    //    { Block: Block
    //      HTMLProps: IHTMLProp list }

    //[<RequireQualifiedAccess>]
    //type Children<'Button> = 'Button list

    //[<RequireQualifiedAccess>]
    //type T<'Button> = Props * Children<'Button>

    //let props =
    //    { Props.Block = false
    //      Props.HTMLProps = [] }

    //let private block =
    //    function
    //    | true -> "btn-group-block"
    //    | false -> ""

    //let build buttonƒ (buttonGroup: T<'Button>) =
    //    let props, children = buttonGroup
    //    props.HTMLProps
    //    |> addProp (ClassName "btn-group")
    //    |> R.div
    //    <| Seq.map buttonƒ children

    //let ƒ = build Button.ƒ