namespace Fabulosa

module Card =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

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

    let header (c: Header) =
        let opt, (Title title, SubTitle subTitle) = c
        opt
        |> addProp (ClassName "card-header")
        |> R.div
        <| [ R.div
              [ ClassName "card-title h5" ]
              [ R.str title ]
             R.div
              [ ClassName "card-subtitle text-gray" ]
              [ R.str subTitle ] ]

    type Body = HTMLProps * ReactElements

    let body (c: Body) =
        let opt, chi = c
        if not (List.isEmpty chi) then
            opt
            |> addProp (ClassName "card-body")
            |> R.div <| chi
        else
            R.ofOption None

    type Footer =
        HTMLProps * ReactElements

    let footer (c: Footer) =
        let opt, chi = c
        if not (List.isEmpty chi) then
            opt
            |> addProp (ClassName "card-footer")
            |> R.div <| chi
        else
            R.ofOption None

    type CardHeader =
        Header of Header

    type CardBody =
        Body of Body

    type CardFooter =
        Footer of Footer

    type CardImage =
        Image of Media.Image.Props

    type CardChildren =
        CardImage * CardHeader * CardBody * CardFooter
        
    type Card =
        HTMLProps * CardChildren

    let card (c: Card) =
        let opt, (Image i, Header h, Body b, Footer f) = c
        opt
        |> addProp (ClassName "card")
        |> R.div <|
        [ header h
          R.div [ ClassName "card-image" ] [ Media.Image.ƒ i ]
          body b
          footer f ]
