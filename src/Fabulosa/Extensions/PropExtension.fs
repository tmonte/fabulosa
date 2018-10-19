namespace Fabulosa.Extensions

open Fable.Helpers.React.Props

module Fable =
    module Helpers =
        module React =
            module Props =
                type HTMLProps = IHTMLProp list
                
                let nonEmpty =
                    function
                    | "" -> None
                    | value -> Some value

                let concatStrings =
                    List.choose nonEmpty
                    >> String.concat " "

                let htmlAttrs (prop: IProp) =
                    match prop with
                    | :? HTMLAttr as htmlAttr -> Some htmlAttr
                    | _ -> None

                let tryCast (prop: IHTMLProp) =
                    try  prop :?> HTMLAttr with e -> Id ""

                let combineProp (prop: IHTMLProp) (htmlProp: IHTMLProp) =
                    match tryCast prop , tryCast htmlProp with
                    | ClassName a, ClassName b ->
                        concatStrings [a;b]
                        |> ClassName
                        :> IHTMLProp
                        |> Some
                    | _ -> None
                    
                let addPropOld (prop: IHTMLProp) (htmlProps: IHTMLProp list) =
                    if htmlProps |> List.length > 0 then
                        let filtered = htmlProps |> List.filter (combineProp prop >> Option.isNone)
                        let combined = htmlProps |> List.choose (combineProp prop)
                        if combined |> List.length > 0 then
                            List.append combined filtered
                        else
                            prop :: filtered
                    else [prop]

                let addPropsOld (props: HTMLProps) (htmlProps: HTMLProps) =
                    props |> List.fold
                        (fun acc prop -> acc |> addPropOld prop) htmlProps

                let addProp (prop: IHTMLProp) (htmlProps: HTMLProps) =
                    prop :: htmlProps

                let addProps (other: HTMLProps) (existing: HTMLProps) = 
                    other |> List.fold
                        (fun acc prop -> acc |> addProp prop) existing

                let merge (props: HTMLProps) =
                    let propToClassNames =
                        List.choose htmlAttrs
                        >> List.choose
                            (function
                             | ClassName a -> Some a
                             | _ -> None)
                    let withoutClassNames =
                        List.filter
                            (fun (prop: IHTMLProp) ->
                                match prop with
                                | :? HTMLAttr as htmlAttr ->
                                    match htmlAttr with
                                    | ClassName _ -> false
                                    | _ -> true
                                | _ -> true)
                    let classNames = propToClassNames props
                    let otherProps = withoutClassNames props
                    (classNames
                     |> String.concat " "
                     |> ClassName
                     :> IHTMLProp)
                    :: otherProps

                let map (mapping: IHTMLProp -> IHTMLProp) =
                    List.map mapping

                let mapMerge (mapping: IHTMLProp -> IHTMLProp) =
                    map mapping >> merge
                                            
