namespace Fabulosa

module Tab =

    open Fabulosa.Extensions
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type TabItemOptional =
        | Active
        interface IHTMLProp

    type TabItem =
        HTMLProps * ReactElement list

    let private itemPropToClassName (prop: IHTMLProp) =
        match prop with
        | :? TabItemOptional as opt ->
            match opt with
            | Active -> className "active"
        | _ -> prop

    let tabItem ((opt, chi): TabItem) =
        Unmerged opt
        |> addProp (ClassName "tab-item")
        |> map itemPropToClassName
        |> merge
        |> R.li <| chi

    type TabOptional =
        | Block
        interface IHTMLProp

    type TabChild =
        Item of TabItem

    type Tab = HTMLProps * TabChild list

    let private propToClassName (prop: IHTMLProp) =
        match prop with
        | :? TabOptional as opt ->
            match opt with
            | Block -> className "tab-block"
        | _ -> prop

    let tab ((opt, chi): Tab) =
        Unmerged opt
        |> addProp (ClassName "tab")
        |> map propToClassName
        |> merge
        |> R.ul
        <| (List.map (fun (Item item) -> tabItem item) chi)
