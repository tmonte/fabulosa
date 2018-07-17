module Responsive

open Utils

type ResponsiveSize =
| XS
| SM
| MD
| LG
| XL

type HideOrShow =
| Hide of ResponsiveSize
| Show of ResponsiveSize

let hideOrShowClasses =
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

let responsive hideOrShowProps element elementProps htmlProps children: Fable.Import.React.ReactElement =
    let props = mergeClasses <| htmlProps <| ["responsive"] @ List.map hideOrShowClasses hideOrShowProps
    element elementProps props children