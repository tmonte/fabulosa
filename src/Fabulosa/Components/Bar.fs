namespace Fabulosa

module Bar =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props

    type Color =
        | Primary
        | Secondary
        | Dark
        | Gray
        | Success
        | Warning
        | Error
        | Unset

    type BarItemOptional =
        | Tooltip of bool
        | Color of Color
        interface IHTMLProp

    type BarItemRequired =
        Value of int

    type private BarItem =
        HTMLProps * BarItemRequired

    let private toPercent =
        string >> (+) >> (|>) "%"

    let private tooltip (prop: IHTMLProp) =
        match prop with
        | :? BarItemOptional as opt ->
            match opt with
            | Tooltip true -> Some "tooltip"
            | _ -> None
        | _ -> None

    let private tooltipData value (prop: IHTMLProp) =
        match prop with
        | :? BarItemOptional as opt ->
            match opt with
            | Tooltip true ->
                Data ("tooltip", toPercent value)
                :> IHTMLProp
            | _ -> prop
        | _ -> prop

    let private style value =
        let width = R.Props.CSSProp.Width (toPercent value)
        let style = Fable.Helpers.React.Props.Style [width]
        [style]
        |> List.cast<IHTMLProp>

    let barItem (c: BarItem) =
        let opt, (Value value) = c
        (opt @ style value)
        |> addClass tooltip
        |> List.map (tooltipData value)
        |> addProp (ClassName "bar-item")
        |> R.div <| []

    type BarOptional =
        | Small of bool
        interface IHTMLProp

    type BarChild =
        BarItem of BarItem

    type private BarChildren =
        BarChild list

    type private Bar = HTMLProps * BarChildren

    let private small (prop: IHTMLProp) =
        match prop with
        | :? BarOptional as opt ->
            match opt with
            | Small true -> Some "bar-sm"
            | _ -> None
        | _ -> None

    let bar (c: Bar) =
        let optional, children = c
        optional
        |> addClass small
        |> addProp (ClassName "bar")
        |> R.div
        <| Seq.map
            (fun (BarItem item) -> barItem item)
            children
        
    //[<RequireQualifiedAccess>]
    //module Slider =

        //let props = props

        //let build (slider: T<Item.T>) =
        //    let props, children = slider
        //    props.HTMLProps
        //    |> addProps
        //        [ ClassName "bar bar-slider"
        //          small props.Small ]
        //    |> R.div
        //    <| Seq.map
        //        (fun item ->
        //            let props, children = item
        //            Item.ƒ
        //                (props,
        //                 [ button
        //                     ([ ClassName "bar-slider-btn" ], []) ]))
        //        children

        //let ƒ = build