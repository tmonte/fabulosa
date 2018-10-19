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
            | Size ExtraSmall -> "avatar-xs"
            | Size Small -> "avatar-sm"
            | Size Large -> "avatar-lg"
            | Size ExtraLarge -> "avatar-xl"
            | _ -> ""
            |> ClassName
            :> IHTMLProp
        | _ -> prop

    let private presenceIcon presence =
        R.i ([ presence; ClassName "avatar-presence" ]) []

    let private presence (props: HTMLProps) =
        List.tryPick
            (fun (prop: IHTMLProp) ->
                match prop with
                | :? AvatarOptional as opt ->
                    match opt with
                    | Presence Away -> Some "away"
                    | Presence Busy -> Some "busy"
                    | Presence Online -> Some "online"
                    | _ -> None
                    |> Option.map ClassName
                    |> Option.map presenceIcon
                | _ -> None)
            props
        |> R.ofOption

    let private initial children (props: IHTMLProp list) =
        match children with
        | Initial initial ->
            props |> addProp (Data ("initial", initial))
        | _ -> props

    let private image children =
        match children with
        | Url url ->
            R.img [ Src url ]
        | _ -> R.ofOption None

    let avatar (comp: Avatar) =
        let opt, chi = comp
        opt
        |> addProp (ClassName "avatar")
        |> mapMerge size
        |> initial chi
        |> R.figure
        <| [ image chi
             presence opt ]