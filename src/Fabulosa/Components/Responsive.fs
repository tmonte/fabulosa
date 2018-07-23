[<RequireQualifiedAccess>]
module Responsive

open ClassNames

type Size =
| XS
| SM
| MD
| LG
| XL

type HideOrShow =
| Hide of Size
| Show of Size

let classes =
    function
    | Hide XS -> "hide-xs"
    | Hide SM -> "hide-sm"
    | Hide MD -> "hide-md"
    | Hide LG -> "hide-lg"
    | Hide XL -> "hide-xl"
    | Show XS -> "show-xs"
    | Show SM -> "show-sm"
    | Show MD -> "show-md"
    | Show LG -> "show-lg"
    | Show XL -> "show-xl"

let responsiveP hideOrShowProps element elementProps htmlProps children =
    let props = mergeClasses <| htmlProps <| ["responsive"] @ List.map classes hideOrShowProps
    element elementProps props children

let responsive hideOrShowProps element htmlProps children =
    let props = mergeClasses <| htmlProps <| ["responsive"] @ List.map classes hideOrShowProps
    element props children