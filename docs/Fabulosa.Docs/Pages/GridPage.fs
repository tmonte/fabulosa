module GridPage

module R = Fable.Helpers.React
open R.Props

open Fable.Import.React

let cols: seq<ReactElement> = seq {
    for n in 1 .. 11 do
        yield Grid.row [] [] [
            Grid.column [ Grid.Column.Size n ] [] [
                R.div [ Style [ Background "#f8f9fa" ] ] [ R.str ("c " + n.ToString()) ]
            ]
            Grid.column [ Grid.Column.Size (12 - n) ] [] [
                R.div [ Style [ Background "#f8f9fa" ] ] [ R.str ("c " + (12 - n).ToString()) ]
            ]
        ]
}

let view () =
    R.div [] [
        R.h2 [] [R.str "Grid"]
        R.p [] [R.str "Layout includes flexbox based responsive grid system with 12 columns."]
        Grid.grid [] (Seq.toList cols)
    ]