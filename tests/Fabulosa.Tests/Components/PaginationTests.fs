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

        test "Pagination page changed" {
            let mockElement =
                Mock<Fable.Import.Browser.Element>
                    .Property(fun x -> <@ x.innerHTML @>)
                    .Returns("Prev")
            let mockEvent =
                Mock<Fable.Import.React.MouseEvent>
                    .Property(fun x -> <@ x.currentTarget @>)
                    .Returns(mockElement)
            let moduleInfo = 
                Assembly.GetAssembly(typeof<Pagination.T>).GetTypes()
                |> Seq.find (fun t -> t.Name = "Pagination")
            let result =
                moduleInfo
                    .GetMethod(
                        "pageChanged",
                        BindingFlags.NonPublic |||
                        BindingFlags.Public |||
                        BindingFlags.Static)
                    .Invoke(null, [| mockEvent |])
            Expect.equal (result :?> int) -2 "Should have a Prev button"
        }

    ]