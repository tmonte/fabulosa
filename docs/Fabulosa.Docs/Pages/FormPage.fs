module FormPage

module R = Fable.Helpers.React
open R.Props
open Fabulosa

let view () =
    Fable.Helpers.React.div [] [
        R.h2 [] [R.str "Forms"]
        R.p [] [R.str "Forms provide the most common control styles used in forms, including input, textarea, select, checkbox, radio and switch."]
        Grid.ƒ Grid.defaults [
            Grid.Row.ƒ Grid.Row.defaults [
                Grid.Column.ƒ { Grid.Column.defaults with Size = 4 } [
                    R.form [] [
                        Group.ƒ Group.defaults [
                            Label.ƒ { Label.defaults with Text = "Name" }
                            Input.ƒ
                                { Input.defaults with
                                    HTMLProps = [Placeholder "Please enter your name"] }
                        ]
                        Group.ƒ Group.defaults [
                            Label.ƒ { Label.defaults with Text = "Phone" }
                            Input.ƒ
                                { Input.defaults with
                                    HTMLProps = [Placeholder "Please enter your phone number";
                                        Type "tel"] }
                        ]
                        Group.ƒ Group.defaults [
                            Label.ƒ { Label.defaults with Text = "Time" }
                            IconInput.ƒ IconInput.defaults [
                                Input.ƒ
                                    { Input.defaults with
                                        HTMLProps = [Placeholder "Please enter something"] }
                                Icon.ƒ { Icon.defaults with Kind = Icon.Kind.Time } []
                            ]
                        ]
                        Group.ƒ Group.defaults [
                            Label.ƒ { Label.defaults with Text = "Profile description" }
                            Textarea.ƒ
                                { Textarea.defaults with
                                    HTMLProps = [Placeholder "Please enter a description"] } []
                        ]
                        Group.ƒ Group.defaults [
                            Label.ƒ { Label.defaults with Text = "Contact preferences" }
                            Radio.ƒ
                                { Radio.defaults with
                                    HTMLProps = [Name "contact-prefs"];
                                    Text = "Call me" }
                                
                            Radio.ƒ
                                { Radio.defaults with
                                    HTMLProps = [Name "contact-prefs"];
                                    Text = "Text me" }
                        ]
                        Group.ƒ Group.defaults [
                            Label.ƒ { Label.defaults with Text = "Profile preferences" }
                            Switch.ƒ { Switch.defaults with Text = "Link my github account" }
                        ]
                        Group.ƒ Group.defaults [
                            Checkbox.ƒ { Checkbox.defaults with Text = "Remember me" }
                            Checkbox.ƒ { Checkbox.defaults with Text = "Forget me" }
                        ]
                        Anchor.ƒ Anchor.defaults [R.str "Submit"]
                    ]
                ]
            ]
        ]
    ]