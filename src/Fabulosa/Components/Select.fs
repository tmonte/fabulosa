namespace Fabulosa

[<RequireQualifiedAccess>]
module Select =

    open ClassNames

    module R = Fable.Helpers.React

    let select =
        ["form-select"]
        |> addClassesToProps
        >> R.select

    let option = R.option

    let optGroup = R.optgroup