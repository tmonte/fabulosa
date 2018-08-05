namespace Fabulosa

module ReactAPIExtensions =

    open Fable.Core
    open Fable.Import.React
    module R = Fable.Helpers.React
    open Fable.Core.JsInterop

    [<Emit("$0 === undefined")>]
    let isUndefined (x: 'a) : bool = jsNative

    [<Emit("undefined")>]
    let undefined : obj = jsNative

    [<Pojo>]
    type NativeProps = {
        children: obj
        className: string
    }

    [<Pojo>]
    type NativeElement = {
        ``type``: string
        props: NativeProps
    }

    let toReactElement element =
        if isUndefined element.props.children then
            R.createElement (element.``type``, element.props, [] :> obj)
        else
            R.createElement (element.``type``, element.props, element.props.children)

    let extractProps (element: ReactElement) =
        let native = unbox<NativeElement> element
        (native.``type``, native.props, native.props.children)

    let appendClass classes element =
        let (elType, elProps, elChilren) = extractProps element
        let originalClasses = if isUndefined elProps.className then "" else elProps.className
        let appended =
            [originalClasses]
            @ classes
            |> String.concat " "
        toReactElement {
            ``type`` = elType;
            props = {elProps with className = appended}
        }