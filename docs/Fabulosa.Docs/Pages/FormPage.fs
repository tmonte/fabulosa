module FormPage

module R = Fable.Helpers.React
open R.Props

let view () =
    R.div [] [
        R.h2 [] [R.str "Forms"]
        R.p [] [R.str "Forms provide the most common control styles used in forms, including input, textarea, select, checkbox, radio and switch."]
        Grid.grid [] [
            Grid.row [] [] [
                Grid.column [Grid.Column.Size 4] [] [
                    R.form [] [
                        Form.group [] [
                            Form.label [] [R.str "Name"]
                            Form.input [] [Placeholder "Please enter your name"]
                        ]
                        Form.group [] [
                            Form.label [] [R.str "Phone"]
                            Form.input [] [Placeholder "Please enter your phone number"; Type "tel"]
                        ]
                        Form.group [] [
                            Form.label [] [R.str "Profile description"]
                            Form.textarea [Placeholder "Please enter a description"] []
                        ]
                        Form.group [] [
                            Form.label [] [R.str "Contact preferences"]
                            Form.checkbox [] "Call me"
                            Form.checkbox [] "Text me"
                        ]
                        Form.group [] [
                            Form.label [] [R.str "Profile preferences"]
                            Form.switch [] "Link my github account"
                        ]
                        Button.anchor [Button.Kind Button.Primary] [Style [MarginTop 10]] [R.str "Submit"]
                    ]
                ]
            ]
        ]
    ]