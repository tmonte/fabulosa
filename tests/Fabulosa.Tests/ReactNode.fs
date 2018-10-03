module ReactNode

    open System.Linq
    open Fabulosa.Extensions
    open Fable.Import.React
    module R = Fable.Helpers.React
    open R.Props

    let stringEquals a b =
        let stringSort = Seq.map string >> Seq.sort
        Enumerable.SequenceEqual(stringSort a, stringSort b)

    [<CustomEquality; CustomComparison>]
    type T =
        { Kind: string
          Props: IProp seq
          Children: T list }
        override x.Equals yobj =
            match yobj with
            | :? T as y ->
                x.Kind = y.Kind &&
                stringEquals x.Props y.Props &&
                Enumerable.SequenceEqual(x.Children, y.Children)
            | _ -> false
        override x.GetHashCode () =
            hash (x.Kind, x.Props, x.Children)
        interface System.IComparable with
            member x.CompareTo yobj =
                match yobj with
                | :? T as y -> compare x y
                | _ -> invalidArg "yobj" "different types"

    let rec unit (element: ReactElement) =
        let (kind, props, children) =
            element :?> R.HTMLNode |> ReactNodeElement.extract
        { Kind = kind
          Props = props
          Children = List.map unit <| List.ofSeq children }

    let props node = node.Props

    let kind node = node.Kind

    let children node = node.Children

    let descendents =
        let rec loop acc stack =
            match stack with
            | [] -> acc
            | h::t ->
                loop (acc @ [h]) (h.Children @ t)
        children >> loop []

    let className =
        let classes =
            function
            | ClassName c -> Some c
            | _ -> None
        props
        >> Seq.choose htmlAttrs
        >> Seq.map classes
        >> Seq.choose id
        >> Seq.join " "

    let text node =
        let value =
            function
            | Value value -> Some value
            | _ -> None
        match kind node with
        | "<STRING>" ->
            props node
            |> Seq.choose htmlAttrs
            |> Seq.pick value
        | _ ->  ""

    let find child =
        descendents
        >> Seq.filter ((=) child)
        
    let findByClassName (c2: string) = 
        let filter n = 
            let getClass =
                function
                | ClassName c -> Some c
                | _ -> None
            
            let nodeClasses = 
                n
                |> props
                |> Seq.choose htmlAttrs
                |> Seq.map getClass
                |> Seq.choose id
                |> Set.ofSeq
            
            let classes = c2.Split " " |> Set.ofArray
            
            let intersection = Set.intersect nodeClasses classes  
            
            Set.isEmpty intersection
    
        descendents >> List.filter filter

    let descendentClassName =
        descendents
        >> Seq.map className
        >> String.concat " "

    let descendentProps =
        descendents
        >> Seq.collect props

    let descendentText =
        descendents
        >> Seq.map text
        >> Seq.filter String.isNotEmpty
        >> Seq.join " "
        