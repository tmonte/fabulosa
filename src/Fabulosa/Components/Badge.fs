namespace Fabulosa

module Badge =

    open Fabulosa.Extensions
    open Fabulosa.Button
    open Fabulosa.Avatar
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    let private combine htmlProps (badge: int) =
        (htmlProps
         |> addProp (ClassName "badge"))
        @ [ Data ("badge", badge) ]
        
    type BadgeRequired =
        { Value: int }

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
        let optional, required, children = c
        match children with
        | BadgeAvatar (opt, children) ->
            avatar (combine opt required.Value, children)
        | BadgeButton (opt, req) ->
            button (combine opt required.Value, req)
        | BadgeAnchor (anchorProps, children) ->
            R.a (combine anchorProps required.Value) children
        | BadgeDiv (divProps, children) ->
            R.div (combine divProps required.Value) children
        | BadgeSpan (spanProps, children) ->
            R.span (combine spanProps required.Value) children