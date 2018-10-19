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
        | Tooltip
        | Color of Color
        interface IHTMLProp

    type BarItemRequired =
        Value of int

    type private BarItem =
        HTMLProps * BarItemRequired

    let private toPercent =
        string >> (+) >> (|>) "%"

    let private tooltip value (prop: IHTMLProp) =
        match prop with
        | :? BarItemOptional as opt ->
            match opt with
            | Tooltip ->
                ((ClassName "tooltip") :> IHTMLProp)
                :: (Data ("tooltip", toPercent value) :> IHTMLProp)
                :: [] |> List.cast<IHTMLProp>
            | _ -> []
        | _ -> []

    let private style value =
        let width = R.Props.CSSProp.Width (toPercent value)
        Fable.Helpers.React.Props.Style [width]
        :> IHTMLProp

    let barItem (comp: BarItem) =
        let opt, (Value value) = comp
        opt
        |> addProp (ClassName "bar-item")
        |> addProp (style value)
        |> addProps (List.collect (tooltip value) opt)
        |> merge
        |> R.div <| []

    type BarOptional =
        | Small
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
            | Small -> "bar-sm"
            |> ClassName
            :> IHTMLProp
        | _ -> prop

    let bar (comp: Bar) =
        let opt, chi = comp
        opt
        |> addProp (ClassName "bar")
        |> mapMerge small
        |> R.div
        <| Seq.map
            (fun (BarItem item) -> barItem item)
            chi
        
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