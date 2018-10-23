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

                type Unmerged =
                    Unmerged of HTMLProps

                let className text = ClassName text :> IHTMLProp

                let unit = Unmerged

                let addProp (prop: IHTMLProp) (htmlProps: HTMLProps) =
                    Unmerged (prop :: htmlProps)
                
                let addProps (other: HTMLProps) (existing: HTMLProps) = 
                    other |> List.fold
                        (fun (Unmerged acc) prop -> addProp prop acc) (Unmerged existing)
                
                let addPropToUnmerged (prop: IHTMLProp) (Unmerged htmlProps) =
                    prop :: htmlProps |> Unmerged      
                
                let merge (unmerged: Unmerged) =
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
                    let (Unmerged props) = unmerged
                    let classNames = propToClassNames props
                    let otherProps = withoutClassNames props
                    (classNames
                     |> String.concat " "
                     |> ClassName
                     :> IHTMLProp)
                    :: otherProps

                let map (mapping: IHTMLProp -> IHTMLProp) (unmerged: Unmerged) =
                    let (Unmerged props) = unmerged
                    List.map mapping props |> Unmerged

                module Unmerged =
                    let flip f a b = f b a
                
                    let addProp (prop: IHTMLProp) (Unmerged propList) =
                        prop :: propList |> Unmerged     
                    
                    let addPropOpt (prop: IHTMLProp option) propList =
                        match prop with
                        | Some p -> addProp p propList
                        | None -> propList
                        
                    let addProps (other: HTMLProps) (propList: Unmerged) = 
                        other
                        |> List.fold (flip addProp) propList