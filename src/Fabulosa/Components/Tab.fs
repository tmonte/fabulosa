namespace Fabulosa

[<RequireQualifiedAccess>]
module Tab =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module Item =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps
              Active: bool }

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let props =
            { Props.HTMLProps = []
              Props.Active = false }

        let private active =
            function
            | true -> "active"
            | false -> ""
            >> ClassName
              
        let ƒ (item: T) =
            let props, children = item
            props.HTMLProps
            |> addProps
                [ ClassName "tab-item"
                  active props.Active ]
            |> R.li <| children

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Action: (ReactElement list) option
          Block: bool }

    [<RequireQualifiedAccess>]
    type T<'Item> = Props * 'Item list

    let props =
        { Props.HTMLProps = []
          Props.Action = None
          Props.Block = false }

    let private renderAction =
        function
        | Some action ->
            R.li
                [ ClassName "tab-item tab-action" ]
                action
        | None -> R.ofOption None

    let private block =
        function
        | true -> "tab-block"
        | false -> ""
        >> ClassName

    let build<'Item> itemƒ (tab: T<'Item>) =
        let props, children = tab
        props.HTMLProps
        |> addProps
            [ ClassName "tab"
              block props.Block ]
        |> R.ul
        <| (List.map itemƒ children) @
           [ renderAction props.Action ]

    let ƒ = build Item.ƒ
