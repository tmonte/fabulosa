module Form

open ClassNames

module R = Fable.Helpers.React

let group htmlProps =
    let props = mergeClasses htmlProps ["form-group"]
    R.div props

let label htmlProps =
    let props = mergeClasses htmlProps ["form-label"]
    R.label props

let input htmlProps =
    let props = mergeClasses htmlProps ["form-input"]
    R.input props

let textarea htmlProps =
    let props = mergeClasses htmlProps ["form-input"]
    R.textarea props