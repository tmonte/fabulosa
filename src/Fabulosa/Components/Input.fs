[<RequireQualifiedAccess>]
module Input

open ClassNames
module R = Fable.Helpers.React
open R.Props

type Icon =
| Left
| Right

type Size =
| Small
| Large

type Props =
| Size of Size
| LeftIcon of Icon.Type
| RightIcon of Icon.Type

let containerPropToClass =
    function
    | LeftIcon _ -> Some "has-icon-left"
    | RightIcon _ -> Some "has-icon-right"
    | _ -> None

let iconPropToIcon =
    function
    | LeftIcon icon -> Some <| Icon.Type icon
    | RightIcon icon -> Some <| Icon.Type icon
    | _ -> None

let propToClass =
    function
    | Size Small -> "input-sm"
    | Size Large -> "input-lg"
    | _ -> ""

let mapsAny mapping =
    List.choose mapping
    >> List.length
    >> (<) 0

let withIcon input props =
    let containerClass =
        String.concat " "
        <| List.choose containerPropToClass props
    let iconProps = List.choose iconPropToIcon props
    R.div [ClassName containerClass] [
        input
        Icon.i iconProps [ClassName "form-icon"] []
    ]

let private create inputProps =
    ["form-input"]
    @ List.map propToClass inputProps
    |> addClassesToProps
    >> R.input

let input inputProps htmlProps =
    let element = create inputProps htmlProps
    match inputProps |> mapsAny containerPropToClass with
    | true -> withIcon element inputProps
    | false -> element
