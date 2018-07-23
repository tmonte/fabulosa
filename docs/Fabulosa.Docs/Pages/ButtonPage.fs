module ButtonPage

open Fable.Helpers.React.Props
open Fable.Import.Browser

module R = Fable.Helpers.React

let view () =
    R.div [] [
        Responsive.responsiveP [Responsive.Hide Responsive.SM] Button.button
            [Button.Size Button.Small; Button.Kind Button.Primary]
            [OnClick (fun event -> event.target |> console.log)]
            [R.str "TEXT"]
    ]