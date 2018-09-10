namespace Fabulosa

[<RequireQualifiedAccess>]
module Card =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props = {
        HTMLProps: HTMLProps
    }
        
    [<RequireQualifiedAccess>]
    type Header = {
        Title: string
        SubTitle: string
    }

    [<RequireQualifiedAccess>]
    type Children = {
        Image: Media.Image.Props
        Header: Header
        Body: ReactElement list
        Footer: ReactElement list
    }

    let defaults = {
        Props.HTMLProps = []
    }

    let children: Children = {
        Header =
            { Header.Title = ""
              Header.SubTitle = ""} 
        Body = []
        Footer = []
        Image = Media.Image.defaults
    }

    let private renderIfNotEmpty elements className =
        if List.length elements > 0 then
            R.div [ClassName className] elements
        else
            R.ofOption None

    let private renderHeader (header: Header) =
        [ R.div [ ClassName "card-title h5" ] [ R.str header.Title ]
          R.div [ ClassName "card-subtitle text-gray" ] [ R.str header.SubTitle ] ]
             
    let private renderChildren (children: Children) =
        seq { yield renderHeader children.Header |> R.div [ ClassName "card-header" ]
              yield R.div [ ClassName "card-image" ] [ Media.Image.ƒ children.Image ]
              yield renderIfNotEmpty children.Body "card-body"
              yield renderIfNotEmpty children.Footer "card-footer" }

    let ƒ (props: Props) children = 
        props.HTMLProps
        |> addProp (ClassName "card")
        |> R.div <| renderChildren children