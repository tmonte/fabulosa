module BreadcrumbTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<FTests>]
let tests =
    testList "Breadcrumbs tests" [

        test "Breadcrumbs display an empty container by default" {
            Breadcrumbs.ƒ Breadcrumbs.defaults
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |> hasNoChildren
        }
    ]