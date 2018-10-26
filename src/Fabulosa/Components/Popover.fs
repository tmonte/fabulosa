namespace Fabulosa

module Popover =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type Position =
        | Top
        | Right
        | Bottom
        | Left

    type PopoverOptional =
        | Position of Position
        interface IHTMLProp

    type PopoverTrigger =
        Trigger of ReactElement list

    type PopoverContent =
        Content of ReactElement list

    type PopoverChildren =
        PopoverTrigger * PopoverContent

    type Popover =
        HTMLProps * PopoverChildren

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? PopoverOptional as opt ->
            match opt with
            | Position Top -> className ""
            | Position Right -> className "popover-right"
            | Position Bottom -> className "popover-bottom"
            | Position Left -> className "popover-left"
        | _ -> prop

    let popover ((opt, (Trigger tri, Content con)): Popover) =
        Unmerged opt
        |> addProp (ClassName "popover")
        |> map propToClassName
        |> merge
        |> R.div
        <| [ R.fragment [] tri
             R.div [ClassName "popover-container"] con ] 
