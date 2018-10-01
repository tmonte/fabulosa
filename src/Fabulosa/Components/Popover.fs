namespace Fabulosa

module Popover =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module Trigger =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (trigger: T) =
            R.fragment [] trigger

    [<RequireQualifiedAccess>]
    module Content =

        [<RequireQualifiedAccess>]
        type T = ReactElement list

        let ƒ (content: T) =
            R.div [ClassName "popover-container"] content

    [<RequireQualifiedAccess>]
    type Position =
        | Top
        | Right
        | Bottom
        | Left

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Position: Position }

    [<RequireQualifiedAccess>]
    type Children =
        { Trigger: Trigger.T
          Content: ReactElement list }

    [<RequireQualifiedAccess>]
    type T = Props * Children

    let private position =
        function
        | Position.Top -> ""
        | Position.Right -> "popover-right"
        | Position.Bottom -> "popover-bottom"
        | Position.Left -> "popover-left"
        >> ClassName

    let props =
        { Props.HTMLProps = []
          Props.Position = Position.Top }

    let ƒ (popover: T) =
        let props, children = popover
        props.HTMLProps
        |> addProps
            [ ClassName "popover"
              position props.Position ]
        |> R.div
        <| [ Trigger.ƒ children.Trigger
             Content.ƒ children.Content ] 