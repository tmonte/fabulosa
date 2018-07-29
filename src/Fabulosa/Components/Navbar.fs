namespace Fabulosa

[<RequireQualifiedAccess>]
module Navbar =

    module R = Fable.Helpers.React

    open ClassNames

    let header =
        ["navbar"]
        |> addClassesToProps
        >> R.header

    let section =
        ["navbar-section"]
        |> addClassesToProps
        >> R.section

    let center =
        ["navbar-center"]
        |> addClassesToProps
        >> R.section

    let brand  =
        ["navbar-brand"]
        |> addClassesToProps
        >> R.a