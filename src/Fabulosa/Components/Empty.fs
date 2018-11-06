namespace Fabulosa

module Empty =

    open Fabulosa.Extensions
    open Fabulosa.Icon
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    let emptyIcon ((opt, req): Icon) =
        R.div
            [ P.ClassName "empty-icon" ]
            [ icon ([ Size X3 ], req) ]

    type Title = string

    let emptyTitle (comp: Title) =
        R.p
            [ P.ClassName "empty-title h5" ]
            [ R.str comp ]

    type Subtitle = string

    let emptySubtitle (comp: Subtitle) =
        R.p
            [ P.ClassName "empty-subtitle" ]
            [ R.str comp ]

    type Action = ReactElement list

    type EmptyChild =
        | Icon of Icon
        | Title of Title
        | Subtitle of Subtitle
        | Action of Action

    let emptyAction (comp: Action) =
        R.div
            [ P.ClassName "empty-action" ]
            comp

    type EmptyChildren = EmptyChild list

    type Empty =
        P.HTMLProps * EmptyChildren

    let empty ((opt, chi): Empty) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "empty")
        |> P.merge
        |> R.div
        <| Seq.map
            (function
            | Icon icn -> emptyIcon icn
            | Title ttl -> emptyTitle ttl
            | Subtitle stt -> emptySubtitle stt
            | Action act -> emptyAction act)
            chi
        
