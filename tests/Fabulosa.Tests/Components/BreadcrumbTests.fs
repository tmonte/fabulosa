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
            Breadcrumb.ƒ
                (Breadcrumb.props, [])
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |> hasNoChildren
        }
        
        test "receives HTMLProps" {
            Breadcrumb.ƒ
                ({ Breadcrumb.props with
                     HTMLProps = [ Id "hello-world" ]}, [])
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb"
            |>! hasProp (Id "hello-world")
            |> hasNoChildren
        }
        
        test "renders children" {
            let items =
                [ (Breadcrumb.Item.props,
                   Breadcrumb.Item.Children.Text "Ciro > Haddad")
                  (Breadcrumb.Item.props,
                   Breadcrumb.Item.Children.Text "Ciro > Boulos > Haddad")
                  (Breadcrumb.Item.props, 
                   Breadcrumb.Item.Children.Link
                     { Href = "cirogomes.com.br" ; Text = "Ciro Gomes" })
                  (Breadcrumb.Item.props,
                   Breadcrumb.Item.Children.Link
                     { Href = "ubuntu.com" ; Text = "Linux > any" })
                  (Breadcrumb.Item.props, 
                   Breadcrumb.Item.Children.Elements
                     [ R.div [ ClassName "find-me" ] [] ]) ]

            let breadcrumb = 
                Breadcrumb.ƒ (Breadcrumb.props, items)
                |> ReactNode.unit


            breadcrumb |> hasUniqueClass "breadcrumb"

            items
            |> List.map Breadcrumb.Item.ƒ
            |> List.iter
                (fun item ->
                    breadcrumb
                    |> hasChild 1 (item |> ReactNode.unit))
        }

    ]

[<Tests>]
let breadcrumbItemsTest =    
    testList "Breadcrumb item tests" [
        test "render the defaults" {
            Breadcrumb.Item.ƒ
                (Breadcrumb.Item.props, 
                 Breadcrumb.Item.Children.Text "Pele")
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasText "Pele"
        }

        test "receives HTMLProps" {
            Breadcrumb.Item.ƒ
                ({ Breadcrumb.Item.props with
                     HTMLProps = [ Id "hello-world" ] },
                 Breadcrumb.Item.Children.Text "Pele")
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |>! hasProp (Id "hello-world")
            |> hasText "Pele"
        }

        test "renders link" {
            let expectedChild =
                R.a
                    [ Href "google.com" ]
                    [ R.str "Hello" ]
                |> ReactNode.unit

            Breadcrumb.Item.ƒ
                (Breadcrumb.Item.props,
                 Breadcrumb.Item.Children.Link
                   { Breadcrumb.Item.Link.Href = "google.com"
                     Breadcrumb.Item.Link.Text = "Hello" })
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasChild 1 expectedChild
        }
        
        test "BreadcrumbItem renders react element" {
            let div =
                R.div
                    [ Id "happy-div" ]
                    [ R.str "Ciro 12" ]
            let expectedChild = div |> ReactNode.unit

            Breadcrumb.Item.ƒ
                (Breadcrumb.Item.props,
                 Breadcrumb.Item.Children.Elements
                   [ div ])
            |> ReactNode.unit
            |>! hasUniqueClass "breadcrumb-item"
            |> hasChild 1 (div |> ReactNode.unit)
        }
    ]