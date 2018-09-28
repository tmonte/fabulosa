module PaginationTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect
open Foq
open System.Reflection

[<Tests>]
let tests =
    testList "Pagination tests" [

        test "Pagination default" {
           Pagination.ƒ
               (Pagination.props, [])
            |> ReactNode.unit
            |> hasUniqueClass "pagination"
        }

        test "Pagination html props" {
            Pagination.ƒ
                ({ Pagination.props with
                     HTMLProps = [ ClassName "custom" ] }, [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Pagination prev and next" {
            let prev = Pagination.Item.props, "Prev"
            let next = Pagination.Item.props, "Next"
            Pagination.ƒ
                (Pagination.props,
                 [ prev; next ])
            |> ReactNode.unit
            |>! hasChild 1 (Pagination.Item.ƒ prev |> ReactNode.unit)
            |> hasChild 1 (Pagination.Item.ƒ next |> ReactNode.unit)
        }

        test "Pagination some pages" {
            let pages =
                seq { 1 .. 7 }
                |> Seq.map
                   (fun n ->
                       Pagination.Item.props, string n)
                |> List.ofSeq
            let pagination =
                Pagination.ƒ
                    (Pagination.props, pages)
                |> ReactNode.unit
            pages
            |> List.map
                (Pagination.Item.ƒ >> ReactNode.unit)
            |> List.iter
                (fun child -> pagination |> hasChild 1 child)
        }

        test "Pagination item defaults" {
            Pagination.Item.ƒ
                (Pagination.Item.props, "Next")
            |> ReactNode.unit
            |> hasUniqueClass "page-item"
        }

        test "Pagination item disabled" {
            Pagination.Item.ƒ
                ({ Pagination.Item.props with
                     Disabled = true }, "Next")
            |> ReactNode.unit
            |> hasClass "disabled"
        }

        test "Pagination item active" {
            Pagination.Item.ƒ
                ({ Pagination.Item.props with
                     Active = true }, "Next")
            |> ReactNode.unit
            |> hasClass "active"
        }

        //test "Pagination page changed" {
        //    let mockElement =
        //        Mock<Fable.Import.Browser.Element>
        //            .Property(fun x -> <@ x.innerHTML @>)
        //            .Returns("Prev")
        //    let mockEvent =
        //        Mock<Fable.Import.React.MouseEvent>
        //            .Property(fun x -> <@ x.currentTarget @>)
        //            .Returns(mockElement)
        //    let moduleInfo = 
        //        Assembly.GetAssembly(typeof<Pagination.T>).GetTypes()
        //        |> Seq.find (fun t -> t.Name = "Pagination")
        //    let result =
        //        moduleInfo
        //            .GetMethod(
        //                "pageChanged",
        //                BindingFlags.NonPublic |||
        //                BindingFlags.Public |||
        //                BindingFlags.Static)
        //            .Invoke(null, [| mockEvent |])
        //    Expect.equal (result :?> int) -2 "Should change page to prev"
        //}

    ]