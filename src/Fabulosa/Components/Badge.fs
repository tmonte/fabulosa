namespace Fabulosa

module Badge =

    open Fabulosa.Extensions
    open Fabulosa.Button
    open Fabulosa.Avatar
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    let private combine props badge =
        props
        |> addProps
            [ ClassName "badge"
              Data ("badge", badge) ]
        |> merge
        
    type BadgeRequired =
        Value of int

    type private Element = HTMLProps * ReactElement list
        
    type BadgeChildren =
        | BadgeAvatar of Avatar
        | BadgeButton of Button
        | BadgeAnchor of Element
        | BadgeDiv of Element
        | BadgeSpan of Element

    type Badge =
        HTMLProps * BadgeRequired * BadgeChildren

    let badge (c: Badge) =
        let optional, (Value value), children = c
        match children with
        | BadgeAvatar (opt, children) ->
            avatar (combine opt value, children)
        | BadgeButton (opt, req) ->
            button (combine opt value, req)
        | BadgeAnchor (anchorProps, children) ->
            R.a (combine anchorProps value) children
        | BadgeDiv (divProps, children) ->
            R.div (combine divProps value) children
        | BadgeSpan (spanProps, children) ->
            R.span (combine spanProps value) children