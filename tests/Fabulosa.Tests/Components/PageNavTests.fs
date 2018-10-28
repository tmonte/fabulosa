module PageNavTests

open Expecto
open Fabulosa.PageNav
module R = Fable.Helpers.React
module P = R.Props
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
    testList "PageNav tests" [

        test "PageNav default" {
            pageNav ([], [])
            |> ReactNode.unit
            |> hasUniqueClass "pagination"
        }

        test "PageNav html props" {
            pageNav ([ P.ClassName "custom" ], [])
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "PageNav children" {
            pageNav ([],
              [ Prev ([],
                  (Title "Page 1",
                   Subtitle "Previous",
                   Link ""))
                Next ([],
                  (Title "Page 3",
                   Subtitle "Next",
                   Link "")) ])
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 1
                 "page-item page-prev page-item page-next"
            |> hasText "Previous Page 1 Next Page 3"
        }

        test "PageNav next only" {
            pageNav ([],
              [ Next ([],
                  (Title "Page 3",
                   Subtitle "Next",
                   Link "")) ])
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 1
                 "page-item page-next page-item-subtitle page-item-title"
            |> hasText "Next Page 3"
        }

        test "PageNav item click" {
            let event = mockClickable "element"
            let props =
                pageNav ([],
                  [ Next ([],
                      (Title "Next",
                       Subtitle "Page 3",
                       OnPageChanged
                         (fun actual ->
                            Expect.equal actual event "Should click on the 'Next' link"))) ])
                |> ReactNode.unit
                |> ReactNode.descendentProps
            let onClick (prop: P.IProp) =
                match prop with
                | :? P.DOMAttr as attr ->
                    match attr with
                    | P.OnClick fn -> Some fn
                    | _ -> None
                | _ -> None
            match Seq.tryPick onClick props with
            | Some fn -> fn event
            | None -> ()
        }

    ]