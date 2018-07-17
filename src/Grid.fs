module Grid

module R = Fable.Helpers.React

open Utils

let grid htmlProps children =
    let props =
        mergeComponentClasses
        <| HTMLProps htmlProps
        <| ["container"]
    R.div props children

let columns htmlProps children =
    let props =
        mergeComponentClasses
        <| HTMLProps htmlProps
        <| ["columns"]
    R.div props children

let column (size: int) htmlProps children =
    let props =
        mergeComponentClasses
        <| HTMLProps htmlProps
        <| ["column col-" + size.ToString()]
    R.div props children