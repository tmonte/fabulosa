module PaginationTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect
open Foq

let mockClickable text =
    let mockElement =
        Mock<Fable.Import.Browser.Element>
            .Property(fun x -> <@ x.innerHTML @>)
            .Returns(text)
    Mock<Fable.Import.React.MouseEvent>
        .Property(fun x -> <@ x.currentTarget @>)
        .Returns(mockElement)


[<Tests>]
let tests =
    testList "Pagination tests" [

        //test "Pagination default" {
        //   Pagination.ƒ
        //       (Pagination.props, [])
        //    |> ReactNode.unit
        //    |> hasUniqueClass "pagination"
        //}

        //test "Pagination html props" {
        //    Pagination.ƒ
        //        ({ Pagination.props with
        //             HTMLProps = [ ClassName "custom" ] }, [])
        //    |> ReactNode.unit
        //    |> hasClass "custom"
        //}

        //test "Pagination prev and next" {
        //    let prev = Pagination.Item.props, "Prev"
        //    let next = Pagination.Item.props, "Next"
        //    Pagination.ƒ
        //        (Pagination.props,
        //         [ prev; next ])
        //    |> ReactNode.unit
        //    |>! hasChild 1 (Pagination.Item.ƒ prev |> ReactNode.unit)
        //    |> hasChild 1 (Pagination.Item.ƒ next |> ReactNode.unit)
        //}

        //test "Pagination some pages" {
        //    let pages =
        //        seq { 1 .. 10 }
        //        |> Seq.map
        //           (fun n ->
        //               Pagination.Item.props, "1")
        //        |> List.ofSeq
        //    Pagination.ƒ
        //        (Pagination.props, pages)
        //    |> ReactNode.unit
        //    |> hasChild 10 (Pagination.Item.ƒ (List.head pages) |> ReactNode.unit)
        //}

        //test "Pagination item defaults" {
        //    Pagination.Item.ƒ
        //        (Pagination.Item.props, "Next")
        //    |> ReactNode.unit
        //    |> hasUniqueClass "page-item"
        //}

        //test "Pagination item disabled" {
        //    Pagination.Item.ƒ
        //        ({ Pagination.Item.props with
        //             Disabled = true }, "Next")
        //    |> ReactNode.unit
        //    |> hasClass "disabled"
        //}

        //test "Pagination item active" {
        //    Pagination.Item.ƒ
        //        ({ Pagination.Item.props with
        //             Active = true }, "Next")
        //    |> ReactNode.unit
        //    |> hasClass "active"
        //}

        //test "Pagination page changed" {
        //    let page = Pagination.Item.onClick (mockClickable "Prev")
        //    Expect.equal page -2 "Should return -2 for prev"
        //    let page = Pagination.Item.onClick (mockClickable "Next")
        //    Expect.equal page -1 "Should return -2 for prev"
        //    seq { 1 .. 10 }
        //    |> Seq.iter (fun n ->
        //        let page = Pagination.Item.onClick (mockClickable (string n))
        //        Expect.equal page n "Should return the clicked page")
        //}

    ]