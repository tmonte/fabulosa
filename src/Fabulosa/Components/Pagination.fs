namespace Fabulosa

module Pagination =

    open Fable.Import
    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    module Item =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Active: bool
              Disabled: bool
              OnPageChanged: int -> unit }

        [<RequireQualifiedAccess>]
        type Children = string

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let private (|Int|_|) str =
           match System.Int32.TryParse(str) with
           | (true,int) -> Some int
           | _ -> None

        let private onClick (e: MouseEvent) =
            let element = e.currentTarget :?> Browser.Element
            match element.innerHTML with
            | Int value -> value
            | value ->
                match value with
                | "Prev" -> -2
                | "Next" -> -1
                | _ -> -99

        let private active =
            function
            | true -> "active"
            | false -> ""
            >> ClassName

        let private disabled =
            function
            | true -> "disabled"
            | false -> ""
            >> ClassName

        let props =
            { Props.HTMLProps = []
              Props.OnPageChanged = fun _ -> ()
              Props.Active = false
              Props.Disabled = false }

        let ƒ (item: T) =
            let props, children = item
            let onPageChanged =
                onClick >> props.OnPageChanged
            let anchor =
                Anchor.ƒ
                    ({ Button.props with
                         HTMLProps =
                           [OnClick onPageChanged] },
                     [ R.str children ])
            props.HTMLProps
            |> addProps
                [ ClassName "page-item"
                  active props.Active
                  disabled props.Disabled ]
            |> R.li <| [ anchor ]

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children = Item.T list

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let ƒ (pagination: T) =
        let props, children = pagination
        props.HTMLProps
        |> addProp (ClassName "pagination")
        |> R.ul <| Seq.map Item.ƒ children