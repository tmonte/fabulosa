module BreadcrumbTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Breadcrumbs tests" [
        test "Breadcrumbs display an empty container by default" {
            Breadcrumbs.ƒ Breadcrumbs.defaults
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |> hasNoChildren
        }
        
        test "Finds the children" {
            let itemContent = R.span [ClassName "hello-world"] [R.str "item"]
            let breadCrumb = Breadcrumbs.ƒ {
                Breadcrumbs.defaults with
                    BreadcrumbItems = [
                        itemContent
                        itemContent
                    ]
            }
            
            let breadCrumbItem = R.li [ClassName "breadcrumb-item"] [itemContent] |> ReactNode.unit
            
            breadCrumb
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |>! hasDescendentClass "breadcrumb-item"
            |> hasChild 2 breadCrumbItem
        }
    ]