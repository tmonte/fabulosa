namespace Fabulosa

module Card =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa.Media.Image

    type Text = string

    type ReactElements = ReactElement list

    type HeaderTitle =
        Title of Text

    type HeaderSubTitle =
        SubTitle of Text

    type HeaderChildren =
        HeaderTitle * HeaderSubTitle

    type Header =
        HTMLProps * HeaderChildren

    let cardHeader ((opt, (Title title, SubTitle subTitle)): Header) =
        Unmerged opt
        |> addProp (ClassName "card-header")
        |> merge
        |> R.div
        <| [ R.div
              [ ClassName "card-title h5" ]
              [ R.str title ]
             R.div
              [ ClassName "card-subtitle text-gray" ]
              [ R.str subTitle ] ]

    type Body = HTMLProps * ReactElements

    let cardBody ((opt, chi): Body) =
        if not (List.isEmpty chi) then
            Unmerged opt
            |> addProp (ClassName "card-body")
            |> merge
            |> R.div <| chi
        else
            R.ofOption None

    type Footer =
        HTMLProps * ReactElements

    let cardFooter ((opt, chi): Footer) =
        if not (List.isEmpty chi) then
            Unmerged opt
            |> addProp (ClassName "card-footer")
            |> merge
            |> R.div <| chi
        else
            R.ofOption None

    type CardChild =
        | Header of Header
        | Body of Body
        | Footer of Footer
        | Image of Image

    type CardChildren = CardChild list
        
    type Card =
        HTMLProps * CardChildren

    let card ((opt, chi): Card) =
        Unmerged opt
        |> addProp (ClassName "card")
        |> merge
        |> R.div
        <| Seq.map
            (function
            | Header hdr -> cardHeader hdr
            | Image img -> R.div [ ClassName "card-image" ] [ image img ]
            | Body bod -> cardBody bod
            | Footer ftr -> cardFooter ftr)
            chi