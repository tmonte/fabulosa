namespace Fabulosa

module PageNav =

    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    module P = R.Props

    type Action =
        | Link of string
        | OnPageChanged of (MouseEvent -> unit)

    type Title =
        Title of string

    type Subtitle =
        Subtitle of string

    type PageNavItemChildren = Title * Subtitle * Action

    type PageNavItem =
        P.HTMLProps * PageNavItemChildren

    type PageNavPrev =
        | Prev of (PageNavItem option)

    type PageNavNext =
        | Next of (PageNavItem option)

    type PageNavChildren = PageNavPrev * PageNavNext

    type PageNav = P.HTMLProps * PageNavChildren

    let private action =
        function
        | Link href -> [ (P.Href href) :> P.IHTMLProp ]
        | OnPageChanged fn -> [ (P.OnClick fn) :> P.IHTMLProp ]

    let pageNavItem kind ((opt, (Title t, Subtitle st, act))) =
        P.Unmerged opt
        |> P.addProp (P.ClassName ("page-item page-" + kind))
        |> P.merge
        |> R.li
        <| [ R.a
                (action act)
                [ R.div
                    [ P.ClassName "page-item-subtitle" ]
                    [ R.str st ]
                  R.div
                    [ P.ClassName "page-item-title h5" ]
                    [ R.str t ] ] ]

    let pageNav ((opt, (Prev prv, Next nxt)): PageNav) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "pagination")
        |> P.merge
        |> R.ul <|
        [ prv
          |> Option.map (pageNavItem "prev")
          |> R.ofOption
          nxt
          |> Option.map (pageNavItem "next")
          |> R.ofOption ]
