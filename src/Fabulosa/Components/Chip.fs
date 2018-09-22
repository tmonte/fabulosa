namespace Fabulosa

open Fable.Import.React
[<RequireQualifiedAccess>]
module Chip =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    module Remove =

        type Props =
            { OnRemove: MouseEvent -> unit }

        type T = Props

        let ƒ (remove: T) =
            ({ Anchor.defaults with
                 HTMLProps =
                   [ ClassName "btn btn-clear"
                     Role "button"
                     OnClick remove.OnRemove ] }, [])
            |> Anchor.ƒ

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          OnRemove: (MouseEvent -> unit) option }

    [<RequireQualifiedAccess>]
    type Children =
        { Text: string
          Avatar: Avatar.T option }

    [<RequireQualifiedAccess>]
    type T = Props * Children

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

    let private avatar =
        function
        | Some avatar ->
            Avatar.ƒ
                { avatar with
                    Size = Avatar.Size.Small }
        | None -> R.ofOption None

    let ƒ (chip: T) =
        let props, children = chip
        props.HTMLProps
        |> addProp (ClassName "chip")
        |> R.div <|
        [ avatar children.Avatar
          R.str children.Text
          remove props.OnRemove ]