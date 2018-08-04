namespace Fabulosa

module Index =

    open Fable.Import.React
    module R = Fable.Helpers.React


    let Fi (props : obj) c : ReactElement = 
         match props with 
         | :? Button.Props as p -> R.div [] c
         | :? Pacoquinha.Props as p -> R.span [] c
         | _ -> R.span [] []
         
         
    let ø = R.div [] [R.str "hey yo"] 