namespace Fabulosa

module rec Select =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    module P = R.Props

    type SelectOption = P.HTMLProps * FabulosaText

    let selectOption ((opt, (Text txt)): SelectOption) =
        R.option opt [ R.str txt ]

    type SelectOptionGroupChild =
        | Option of SelectOption

    type SelectOptionGroup =
        P.HTMLProps * SelectChild list

    type SelectChild =
        | Group of SelectOptionGroup
        | Option of SelectOption

    let selectOptionGroup ((opt, chi): SelectOptionGroup) =
        R.optgroup opt
            (Seq.map
                (function
                | Option opt -> selectOption opt
                | Group grp -> selectOptionGroup grp)
                chi)

    type Select =
        P.HTMLProps * SelectChild list

    let private propToClassName (prop: P.IHTMLProp) =
        match prop with
        | :? FabulosaFormSize as opt ->
            match opt with
            | Size Small -> "select-sm"
            | Size Large -> "select-lg"
            |> P.className
        | _ -> prop

    let select ((opt, chi): Select) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "form-select")
        |> P.map propToClassName
        |> P.merge
        |> R.select
        <| Seq.map
            (function
             | Group g -> selectOptionGroup g
             | Option o -> selectOption o)
            chi
