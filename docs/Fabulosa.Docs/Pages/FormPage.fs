module FormPage

module R = Fable.Helpers.React

let view () =
    R.div [] [
        R.h2 [] [R.str "Forms"]
        R.p [] [R.str "Forms provide the most common control styles used in forms, including input, textarea, select, checkbox, radio and switch."]
        Form.input [] []
    ]