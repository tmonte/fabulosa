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
              Badge: int option }

        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let props =
            { Props.HTMLProps = []
              Props.Badge = None }
              
        let ƒ (item: T) =
            let props, children = item
            props.HTMLProps
            |> addProp (ClassName "tab-item")
            |> R.li <| children


    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Action: (ReactElement list) option }

    [<RequireQualifiedAccess>]
    type T = Props * Item.T list

    let props =
        { Props.HTMLProps = []
          Props.Action = None }

    let private renderAction =
        function
        | Some action ->
            R.li
                [ClassName "tab-item tab-action"]
                action
        | None -> R.ofOption None


    let ƒ (tab: T) =
        let props, children = tab
        props.HTMLProps
        |> addProp (ClassName "tab")
        |> R.ul
        <| seq
            { yield! (Seq.map Item.ƒ children)
              yield renderAction props.Action }