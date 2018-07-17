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

type ColumnSize = ColumnSize of int

let column columnSize htmlProps children =
    let props =
        mergeComponentClasses
        <| HTMLProps htmlProps
        <| ["column col-" + columnSize.ToString()]
    R.div props children