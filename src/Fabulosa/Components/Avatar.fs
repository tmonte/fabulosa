namespace Fabulosa

module Avatar =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type Size =
        | ExtraSmall
        | Small
        | Large
        | ExtraLarge

    type Presence =
        | Online
        | Busy
        | Away

    type AvatarOptional =
        | Presence of Presence
        | Size of Size
        interface IHTMLProp

    type AvatarChildren =
        | Initial of string
        | Url of string

    type Avatar =
        HTMLProps * AvatarChildren

    let private size (prop: IHTMLProp) =
        match prop with
        | :? AvatarOptional as opt ->
            match opt with
            | Size ExtraSmall -> Some "avatar-xs"
            | Size Small -> Some "avatar-sm"
            | Size Large -> Some "avatar-lg"
            | Size ExtraLarge -> Some "avatar-xl"
            | _ -> None
            |> Option.map ClassName
            |> Option.map (fun n -> n :> IHTMLProp)
            |> Option.orElse (Some prop)
            |> Option.get
        | _ -> prop

    let private presenceIcon presence =
        R.i
            ([presence] |> addProp (ClassName "avatar-presence")) []

    let private presence (prop: IHTMLProp) =
        match prop with
        | :? AvatarOptional as opt ->
            match opt with
            | Presence Away -> Some "away"
            | Presence Busy -> Some "busy"
            | Presence Online -> Some "online"
            | _ -> None
            |> Option.map ClassName
            |> Option.map presenceIcon
        | _ -> None

    let private initial children (props: IHTMLProp list) =
        match children with
        | Initial initial ->
            props @ [ Data ("initial", initial) ]
        | _ -> props

    let private image children =
        match children with
        | Url url ->
            R.img [ Src url ]
        | _ -> R.ofOption None

    let avatar (c: Avatar) =
        let optional, children = c
        optional
        |> List.map size
        |> addProp (ClassName "avatar")
        |> initial children
        |> R.figure
        <| [ image children
             (List.tryPick presence optional)
             |> R.ofOption ]