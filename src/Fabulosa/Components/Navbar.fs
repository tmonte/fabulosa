[<RequireQualifiedAccess>]
module Navbar

module R = Fable.Helpers.React

open ClassNames

let header htmlProps =
    let props = mergeClasses htmlProps ["navbar"]
    R.header props

let section htmlProps =
    let props = mergeClasses htmlProps ["navbar-section"]
    R.section props

let center htmlProps =
    let props = mergeClasses htmlProps ["navbar-center"]
    R.section props

let brand htmlProps =
    let props = mergeClasses htmlProps ["navbar-brand"]
    R.a props