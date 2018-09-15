module BreadcrumbTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect
open Fabulosa

[<Tests>]
let tests =
    testList "Breadcrumbs" [
        test "display an empty container by default" {
            Breadcrumbs.ƒ Breadcrumbs.defaults []
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |> hasNoChildren
        }
        
        test "receives HTMLProps" {
            Breadcrumbs.ƒ { Breadcrumbs.defaults with HTMLProps = [Id "hello-world"]} []
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |>! hasProp (Id "hello-world")
            |> hasNoChildren
        }
        
        test "renders children" {
            let breadCrumbItems = [
                BreadcrumbItem.ƒ BreadcrumbItem.defaults (BreadcrumbItem.Text "Ciro > Haddad")
                BreadcrumbItem.ƒ BreadcrumbItem.defaults (BreadcrumbItem.Text "Ciro > Boulos > Haddad")
                BreadcrumbItem.ƒ BreadcrumbItem.defaults (BreadcrumbItem.Link { Href = "cirogomes.com.br" ; Text = "Ciro Gomes"})
                BreadcrumbItem.ƒ BreadcrumbItem.defaults (BreadcrumbItem.Link { Href = "ubuntu.com" ; Text = "Linux > any"})
                BreadcrumbItem.ƒ BreadcrumbItem.defaults (BreadcrumbItem.Elements [R.div [ClassName "find-me"] []])
            ]
        
            breadCrumbItems
            |> Breadcrumbs.ƒ Breadcrumbs.defaults 
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |>! hasChild 1 (breadCrumbItems.[0] |> ReactNode.unit)
            |>! hasChild 1 (breadCrumbItems.[1] |> ReactNode.unit)
            |>! hasChild 1 (breadCrumbItems.[2] |> ReactNode.unit)
            |>! hasChild 1 (breadCrumbItems.[3] |> ReactNode.unit)
            |> hasChild 1 (breadCrumbItems.[4] |> ReactNode.unit)
        }
                
    ]
[<Tests>]
let breadcrumbItemsTest =    
    testList "BreadcrumbItem tests" [
        test "BreadcrumbItem render the defaults" {
            BreadcrumbItem.ƒ BreadcrumbItem.defaults (BreadcrumbItem.Children.Text "Pele")
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasText "Pele"
        }
        
        test "BreadcrumbItem receives HTMLProps" {
            BreadcrumbItem.ƒ { BreadcrumbItem.defaults with HTMLProps = [Id "hello-world"]} (BreadcrumbItem.Children.Text "Pele")
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |>! hasProp (Id "hello-world")
            |> hasText "Pele"
        }
        
        test "BreadcrumbItem renders link" {
            let expectedChild = R.a [Href "google.com"] [R.str "Hello"] |> ReactNode.unit
        
            let breadCrumbItemChild: BreadcrumbItem.Link = { 
                Href = "google.com"
                Text = "Hello" 
            }

            breadCrumbItemChild
            |> BreadcrumbItem.Children.Link
            |> BreadcrumbItem.ƒ BreadcrumbItem.defaults 
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasChild 1 expectedChild
        }
        
        test "BreadcrumbItem renders react element" {
            let div = R.div [Id "happy-div"] [R.str "Ciro 12"]
            let expectedChild = div |> ReactNode.unit
        
            [div]
            |> BreadcrumbItem.Children.Elements
            |> BreadcrumbItem.ƒ BreadcrumbItem.defaults 
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasChild 1 expectedChild
        }
    ]