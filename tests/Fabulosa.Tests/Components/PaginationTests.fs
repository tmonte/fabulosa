module PaginationTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Pagination tests" [

        test "Pagination default" {
            Pagination.ƒ
                Pagination.props
            |> ReactNode.unit
            |> hasUniqueClass "pagination"
        }

        test "Pagination html props" {
            Pagination.ƒ
                { Pagination.props with
                     HTMLProps = [ ClassName "custom" ] }
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Pagination prev and next" {
            let prev = R.str "Prev"
            let next = R.str "Next"
            Pagination.ƒ
                { Pagination.props with
                     PrevNext = true }
            |> ReactNode.unit
            |>! hasChild 1 (prev |> ReactNode.unit)
            |> hasChild 1 (next |> ReactNode.unit)
        }
        
        test "Pagination prev and next disabled" {
            Pagination.ƒ
                { Pagination.props with
                     PrevNext = false }
            |> ReactNode.unit
            |> hasText ""
        }

        test "Pagination prev and next enabled by default" {
            let prev = R.str "Prev"
            let next = R.str "Next"
            Pagination.ƒ
                Pagination.props
            |> ReactNode.unit
            |>! hasChild 1 (prev |> ReactNode.unit)
            |> hasChild 1 (next |> ReactNode.unit)
        }

        // test "Pagination page changed" {
        //     let fn _ = ()
        //     Pagination.ƒ
        //         { Pagination.props with
        //              PageChanged = Some fn }
        //     |> ReactNode.unit
        //     |> hasDescendentProp (OnClick (Pagination.pageChanged >> fn))
        // }

    ]