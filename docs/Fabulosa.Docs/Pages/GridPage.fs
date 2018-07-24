module GridPage

module R = Fable.Helpers.React
open Fable.Helpers.React.Props

open Fable.Import.React

let cols: seq<ReactElement> = seq {
    for n in 1 .. 11 do
        yield Grid.columns [] [] [
            Grid.column [ Grid.Column.Size n ] [] [
                R.div [ Style [ Background "#eee" ] ] [ R.str ("c " + n.ToString()) ]
            ]
            Grid.column [ Grid.Column.Size (12 - n) ] [] [
                R.div [ Style [ Background "#eee" ] ] [ R.str ("c " + (12 - n).ToString()) ]
            ]
        ]
}

let view () =
    Grid.grid [] (Seq.toList cols)