namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Core
    open Fable.Import.React
    module R = Fable.Helpers.React

    [<Pojo>]
    type Elem<'a> = {
        ``type``: string
        props: 'a
    }

    [<Pojo>]
    type NativeProps = {
        children: Elem<NativeProps> list
        className: string
    }

    let getChildren =
        function
        | Some object -> object
        | None -> []

    let extractProps (element: ReactElement) =
        let native = unbox<Elem<NativeProps>> element
        (native.``type``, native.props, native.props.children)

    let transform mapping props element =
        let (elType, elProps, elChilren) = extractProps element
        let appended =
            [elProps.className]
            @ List.map mapping props
            |> String.concat " "
        R.createElement (elType, {elProps with className = appended}, elChilren)