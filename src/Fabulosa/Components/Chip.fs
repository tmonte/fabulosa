namespace Fabulosa

open Fable.Import.React
[<RequireQualifiedAccess>]
module Chip =

    open Fabulosa.Extensions
    open Fabulosa.Avatar
    module R = Fable.Helpers.React
    module P = R.Props

    module Remove =

        [<RequireQualifiedAccess>]
        type Props =
            { OnRemove: MouseEvent -> unit }

        [<RequireQualifiedAccess>]
        type T = Props

        let ƒ (remove: T) =
            R.a
                [ P.ClassName "btn btn-clear"
                  P.Role "button"
                  P.OnClick remove.OnRemove ]
                []

    module ChipAvatar =

        let build (c: Avatar) =
            let optional, children = c
            avatar ([ Size Small ], children)

        let ƒ = build

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: P.HTMLProps
          OnRemove: (MouseEvent -> unit) option }

    [<RequireQualifiedAccess>]
    type Children<'Avatar> =
        { Text: string
          Avatar: 'Avatar option }

    [<RequireQualifiedAccess>]
    type T<'Avatar> =
        Props * Children<'Avatar>

    let props =
        { Props.HTMLProps = []
          Props.OnRemove = None }

    let children =
        { Children.Text = ""
          Children.Avatar = None }

    let private remove =
        function
        | Some fn -> Remove.ƒ { OnRemove = fn }
        | None -> R.ofOption None

    let private avatar avatarƒ =
        function
        | Some avatar ->
            avatarƒ avatar
        | None -> R.ofOption None

    let build avatarƒ (chip: T<'Avatar>) =
        let props, children = chip
        props.HTMLProps
        |> P.addProp (P.ClassName "chip")
        |> R.div <|
        [ avatar avatarƒ children.Avatar
          R.str children.Text
          remove props.OnRemove ]

    let ƒ = build ChipAvatar.ƒ