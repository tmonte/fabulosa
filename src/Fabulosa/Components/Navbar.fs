namespace Fabulosa

module Navbar =

    open Fable.Import.React
    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type NavbarSection = HTMLProps * ReactElement list

    let navbarSection ((opt, chi): NavbarSection) =
        Unmerged opt
        |> addProp (ClassName "navbar-section")
        |> merge
        |> R.section <| chi

    type NavbarCenter = HTMLProps * ReactElement list

    let navbarCenter ((opt, chi): NavbarCenter) =
        Unmerged opt
        |> addProp (ClassName "navbar-center")
        |> merge
        |> R.section <| chi

    type NavbarBrand = HTMLProps * ReactElement list

    let navbarBrand ((opt, chi): NavbarBrand) =
        Unmerged opt
        |> addProp (ClassName "navbar-brand")
        |> merge
        |> R.a <| chi

    type NavbarChild =
    | Brand of NavbarBrand
    | Section of NavbarSection
    | Center of NavbarCenter

    type Navbar = HTMLProps * NavbarChild list

    let navbar ((opt, chi): Navbar) =
        Unmerged opt
        |> addProp (ClassName "navbar")
        |> merge
        |> R.header
        <| Seq.map
            (function
             | Brand brand ->
                 navbarBrand brand
             | Section section ->
                 navbarSection section
             | Center center ->
                 navbarCenter center)
            chi
