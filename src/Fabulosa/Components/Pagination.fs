namespace Fabulosa

module Pagination =

    open Fable.Import
    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    type PaginationItemOptional =
        | Active
        | Disabled
        interface IHTMLProp

    type PaginationItemRequired =
        | OnPageChanged of (int -> unit)

    type PaginationItemChildren =
        Text of string

    type PaginationItem =
        HTMLProps * PaginationItemRequired * PaginationItemChildren

    let private (|Int|_|) str =
       match System.Int32.TryParse(str) with
       | (true, int) -> Some int
       | _ -> None

    let private onClick (e: MouseEvent) =
        let element = e.currentTarget :?> Browser.Element
        match element.innerHTML with
        | Int value -> value
        | value ->
            match value with
            | "Prev" -> -2
            | "Next" -> -1
            | _ -> -99

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? PaginationItemOptional as opt ->
            match opt with
            | Active -> className "active"
            | Disabled -> className "disabled"
        | _ -> prop

    let paginationItem ((opt, (OnPageChanged pc), (Text txt)): PaginationItem) =
        Unmerged opt
        |> addProp (ClassName "page-item")
        |> map propToClassName
        |> merge
        |> R.li
        <| [ R.a
               [ OnClick (onClick >> pc)
                 Href "#" ]
               [ R.str txt ] ]

    type PaginationChild =
        | Item of PaginationItem

    type Pagination =
        HTMLProps * PaginationChild list

    let pagination ((opt, chi): Pagination) =
        Unmerged opt
        |> addProp (ClassName "pagination")
        |> merge
        |> R.ul
        <| Seq.map
            (fun (Item item) -> paginationItem item)
            chi
