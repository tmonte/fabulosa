namespace Fabulosa

[<RequireQualifiedAccess>]
module Tile =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    [<RequireQualifiedAccess>]
    module TileIcon =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }
            
        [<RequireQualifiedAccess>]
        type T<'Icon> = Props * 'Icon

        let props =
            { Props.HTMLProps = [] }

        let build<'Icon> iconƒ (icon: T<'Icon>) =
            let props, children = icon
            props.HTMLProps
            |> addProp (ClassName "tile-icon")
            |> R.div <| [ iconƒ children ]

        let ƒ = build Icon.ƒ

    [<RequireQualifiedAccess>]
    module Content =

        [<RequireQualifiedAccess>]
        type Props =
            { HTMLProps: HTMLProps }
            
        [<RequireQualifiedAccess>]
        type T = Props * ReactElement list

        let props =
            { Props.HTMLProps = [] }

        let children: ReactElement list = []

        let build (icon: T) =
            let props, children = icon
            props.HTMLProps
            |> addProp (ClassName "tile-icon")
            |> R.div <| children

        let ƒ = build

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          Compact: bool }

    [<RequireQualifiedAccess>]
    type Children<'Icon, 'Content> =
        { Icon: 'Icon option
          Content: 'Content }

    [<RequireQualifiedAccess>]
    type T<'Icon, 'Content> = Props * Children<'Icon, 'Content>

    let props =
        { Props.HTMLProps = []
          Props.Compact = false }

    let children =
        { Children.Icon = None
          Children.Content = Content.children }

    let private compact =
        function
        | true -> "tile-centered"
        | false -> ""
        >> ClassName

    let private icon iconƒ =
        function
        | Some props ->
            R.div
                [ ClassName "tile-icon" ]
                [ iconƒ props ]
        | None -> R.ofOption None

    let build<'Icon, 'Content> iconƒ contentƒ (tile: T<'Icon, 'Content>) =
        let props, children = tile
        props.HTMLProps
        |> addProps 
            [ ClassName "tile"
              compact props.Compact ]
        |> R.div
        <| [ icon iconƒ children.Icon
             contentƒ children.Content ]

    let ƒ = build TileIcon.ƒ Content.ƒ