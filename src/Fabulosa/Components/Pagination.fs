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
          PageChanged: (int -> unit) option }

    [<RequireQualifiedAccess>]
    type T = Props

    let props =
        { Props.HTMLProps = []
          Props.PrevNext = true
          Props.PageChanged = Some (fun _ -> ()) }

    let (|Int|_|) str =
       match System.Int32.TryParse(str) with
       | (true,int) -> Some int
       | _ -> None

    let pageChanged (e: MouseEvent) =
        let element = e.currentTarget :?> Browser.Element
        match element.innerHTML with
        | Int value -> value
        | value ->
            match value with
            | "Prev" -> -2
            | "Next" -> -1
            | _ -> -99

    let private item cb text =
        let props =
            match cb with
            | Some cb -> [ OnClick (pageChanged >> cb) ]
            | None -> []
            |> List.cast
        R.li
            []
            [ R.a
                props
                [ R.str text ] ]

    let ƒ (pagination: T) =
        let createItem = item pagination.PageChanged
        pagination.HTMLProps
        |> addProp (ClassName "pagination")
        |> R.ul
        <| [ (if pagination.PrevNext then
                createItem "Prev"
              else R.ofOption None)
             (if pagination.PrevNext then
                createItem "Next"
              else R.ofOption None) ]