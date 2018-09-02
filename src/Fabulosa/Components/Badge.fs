namespace Fabulosa

module Badge =

    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { Badge: int
          HTMLProps: IHTMLProp list }

    let defaults =
        { Props.Badge = 0
          Props.HTMLProps = [] }

    let ƒ (props: Props) =
        R.div
            [ ClassName "badge"
              Data ("badge", props.Badge) ]