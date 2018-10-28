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

    type PageNavItem =
        P.HTMLProps * (Title * Subtitle * Action)

    type PageNavChild =
        | Prev of PageNavItem
        | Next of PageNavItem

    type PageNav = P.HTMLProps * PageNavChild list

    let private action =
        function
        | Link href -> [ (P.Href href) :> P.IHTMLProp ]
        | OnPageChanged fn -> [ (P.OnClick fn) :> P.IHTMLProp ]

    let pageNavItem kind ((opt, (Title t, Subtitle st, act))) =
        R.li
            [ P.ClassName ("page-item page-" + kind) ]
            [ R.a
                (action act)
                [ R.div
                    [ P.ClassName "page-item-subtitle" ]
                    [ R.str st ]
                  R.div
                    [ P.ClassName "page-item-title h5" ]
                    [ R.str t ] ] ]

    let private pageNavChild =
        function
        | Prev prev -> pageNavItem "prev" prev
        | Next next -> pageNavItem "next" next

    let pageNav ((opt, chi): PageNav) =
        P.Unmerged opt
        |> P.addProp (P.ClassName "pagination")
        |> P.merge
        |> R.ul
        <| Seq.map pageNavChild chi
