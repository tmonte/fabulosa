module ButtonPage

open Responsive
open Button
open Grid
open Fable.Helpers.React.Props
open Fable.Import.Browser

module R = Fable.Helpers.React

let view () =
    R.div [] [
        responsive [Hide SM] button
            [ButtonSize ButtonSmall; ButtonKind ButtonPrimary]
            [OnClick (fun event -> event.target |> console.log)]
            [R.str "TEXT"]
    ]