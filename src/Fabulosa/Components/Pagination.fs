namespace Fabulosa

module Pagination =

    open Fable.Import
    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    [<RequireQualifiedAccess>]
    type Props =
        { HTMLProps: HTMLProps
          PrevNext: bool
          Pages: uint32
          Active: uint32
          PageChanged: (int -> unit) option }

    [<RequireQualifiedAccess>]
    type T = Props

    let props =
        { Props.HTMLProps = []
          Props.PrevNext = true
          Props.Pages = 0u
          Props.Active = 0u
          Props.PageChanged = Some (fun _ -> ()) }

    let private (|Int|_|) str =
       match System.Int32.TryParse(str) with
       | (true,int) -> Some int
       | _ -> None

    let private pageChanged (e: MouseEvent) =
        let element = e.currentTarget :?> Browser.Element
        match element.innerHTML with
        | Int value -> value
        | value ->
            match value with
            | "Prev" -> -2
            | "Next" -> -1
            | _ -> -99

    let private item cb (props: HTMLProps) text =
        let combined =
            match cb with
            | Some cb -> props @ [ OnClick (pageChanged >> cb) ]
            | None -> props
            |> List.cast
        R.li
            []
            [ R.a
                combined
                [ R.str text ] ]

    let private active (number: uint32) (page: uint32): HTMLProps =
        if page = number then
            [ ClassName "page-item active" ]
        else [ ClassName "page-item" ]

    let private generate (pages: uint32) (active: uint32) =
        if pages > 3u then
            seq { yield active - 1u
                  yield active
                  yield active + 1u }
        else seq { 1u .. pages }

    let ƒ (pagination: T) =
        let createItem = item pagination.PageChanged
        pagination.HTMLProps
        |> addProp (ClassName "pagination")
        |> R.ul <|
        seq
            { yield
                (if pagination.PrevNext then
                    createItem [ ClassName "page-item" ] "Prev"
                 else R.ofOption None)
              yield!
                seq { 1u .. pagination.Pages }
                |> Seq.map
                    (fun n ->
                        createItem
                            (active pagination.Active n)
                            (string n))
              yield
                (if pagination.PrevNext then
                    createItem [ ClassName "page-item" ] "Next"
                 else R.ofOption None) }