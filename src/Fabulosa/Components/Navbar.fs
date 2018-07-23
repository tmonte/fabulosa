[<RequireQualifiedAccess>]
module Navbar

module R = Fable.Helpers.React

open ClassNames

let header htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar"]
    R.header props children

let section htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar-section"]
    R.section props children

let center htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar-center"]
    R.section props children

let brand htmlProps children =
    let props = mergeClasses <| htmlProps <| ["navbar-brand"]
    R.a props children