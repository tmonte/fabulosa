namespace Fabulosa

[<RequireQualifiedAccess>]
module Label =

    open ClassNames

    module R = Fable.Helpers.React

    let label =
        ["form-label"]
        |> addClassesToProps
        >> R.label