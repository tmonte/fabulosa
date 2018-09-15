namespace Fabulosa

module Portal =

    open Fable.Import
    open Fable.Import.Browser

    let ƒ selector element =
        let existing = document.getElementById selector
        let root =
            if existing = null then
                let created = document.createElement "div"
                created.id <- selector
                document.body.appendChild created |> ignore
                created
            else existing
        ReactDom.createPortal (element, root)