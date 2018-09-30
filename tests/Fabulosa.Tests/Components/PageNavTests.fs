module PageNavTests

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
    testList "PageNav tests" [

        test "PageNav default" {
           PageNav.ƒ
               (PageNav.props, PageNav.children)
            |> ReactNode.unit
            |> hasUniqueClass "pagination"
        }

        test "PageNav html props" {
            PageNav.ƒ
                ({ PageNav.props with
                     HTMLProps = [ ClassName "custom" ] },
                 PageNav.children)
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "PageNav children" {
            PageNav.ƒ
                (PageNav.props,
                 { Prev = Some
                     { SubTitle = "Previous"
                       Title = "Page 1"
                       Action = PageNav.Action.Link "" }
                   Next = Some
                     { SubTitle = "Next"
                       Title = "Page 3"
                       Action = PageNav.Action.Link "" } })
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 1
                 "page-item page-prev page-item page-next"
            |> hasText "Previous Page 1 Next Page 3"
        }

        test "PageNav next only" {
            PageNav.ƒ
                (PageNav.props,
                 { Prev = None
                   Next = Some
                     { SubTitle = "Next"
                       Title = "Page 3"
                       Action = PageNav.Action.Link "" } })
            |> ReactNode.unit
            |>! hasOrderedDescendentClass 1
                 "page-item page-next"
            |> hasText "Next Page 3"
        }

        test "PageNav item click" {
            let props =
                PageNav.action
                    "prev"
                    { Title = ""
                      SubTitle = ""
                      Action = PageNav.Action.OnPageChanged
                        (fun page ->
                            Expect.equal page -2 "Should be prev page") }
            match List.head props with
            | :? DOMAttr as attr ->
                match attr with
                | OnClick fn -> fn (mockClickable "")
                | _ -> ()
            | _ -> ()
            ()
        }

    ]