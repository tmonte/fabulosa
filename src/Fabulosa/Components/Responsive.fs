namespace Fabulosa

module Responsive =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type Size =
        | XS
        | SM
        | MD
        | LG
        | XL

    type ResponsiveOptional =
        | Hide of Size
        | Show of Size
        interface IHTMLProp

    type Responsive = HTMLProps * ReactElement list

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? ResponsiveOptional as opt ->
            match opt with
            | Hide XS -> "hide-xs"
            | Hide SM -> "hide-sm"
            | Hide MD -> "hide-md"
            | Hide LG -> "hide-lg"
            | Hide XL -> "hide-xl"
            | Show XS -> "show-xs"
            | Show SM -> "show-sm"
            | Show MD -> "show-md"
            | Show LG -> "show-lg"
            | Show XL -> "show-xl"
            |> className
        | _ -> prop

    let responsive ((opt, chi): Responsive) =
        Unmerged opt
        |> addProp (ClassName "responsive")
        |> map propToClassName
        |> merge
        |> R.span <| chi
        