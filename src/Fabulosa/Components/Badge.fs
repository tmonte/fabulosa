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
        | Avatar of Avatar
        | Button of Button
        | Anchor of Element
        | Div of Element
        | Span of Element

    type Badge =
        HTMLProps * BadgeRequired * BadgeChildren

    let badge (c: Badge) =
        let optional, (Value value), children = c
        match children with
        | Avatar (opt, children) ->
            avatar (combine opt value, children)
        | Button (opt, req) ->
            button (combine opt value, req)
        | Anchor (anchorProps, children) ->
            R.a (combine anchorProps value) children
        | Div (divProps, children) ->
            R.div (combine divProps value) children
        | Span (spanProps, children) ->
            R.span (combine spanProps value) children