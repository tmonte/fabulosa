namespace Fabulosa

module Step =

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
        type Children = ReactElement list

        [<RequireQualifiedAccess>]
        type T = Props * Children

        let private active =
            function
            | true -> "active"
            | false -> ""
            >> ClassName

        let props =
            { Props.HTMLProps = []
              Props.Active = false }

        let ƒ (item: T) =
            let props, children = item
            R.li
                ([] |> addProps
                    [ ClassName "step-item"
                      active props.Active ])
                [ R.a props.HTMLProps children ]

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps }

    [<RequireQualifiedAccess>]
    type Children = Item.T list

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let props =
        { Props.HTMLProps = [] }

    let ƒ (step: T) =
        let props, children = step
        props.HTMLProps
        |> addProp (ClassName "step")
        |> R.div
        <| Seq.map Item.ƒ children