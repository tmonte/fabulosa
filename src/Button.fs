module Button

open Fable.Helpers.React.Props
module R = Fable.Helpers.React

let button onClick text =
    R.button [OnClick onClick; ClassName "btn btn-primary"] [R.str text]