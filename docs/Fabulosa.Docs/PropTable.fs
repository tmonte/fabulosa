namespace Fabulosa.Docs

module PropTable =
    open System.Reflection
    open FSharp.Reflection
    module R = Fable.Helpers.React
    open R.Props
    open Fabulosa
    
    let flip f a b = f b a
    
    module SystemType =
        let name (typ: PropertyInfo) = typ.Name
    
    let rec systemTypeName(aType: System.Type) =
        let appendMap = ["FSharpList`1", "list"; "FSharpOption`1", "option"] |> Map.ofList
        let exists comparison key value = comparison = key
        
        let (|APPENDABLE|_|) (aType: System.Type) =
           match Map.tryFind aType.Name appendMap with 
           | Some appendableName -> Some appendableName
           | _ -> None
        
        match aType with 
            | APPENDABLE appendableName->
                aType.GenericTypeArguments
                |> List.ofArray
                |> List.map (fun f -> systemTypeName f)
                |> flip List.append [appendableName]
                |> List.reduce (fun x -> (fun y -> x + " " + y))
            | option when option.Name = "FSharpFunc`2" -> 
                option.GenericTypeArguments
                |> List.ofArray
                |> List.map (fun f -> systemTypeName f)
                |> List.reduce (fun x -> (fun y -> x + " -> " + y))
            | t ->
                t.Name

    let rec describeType (propType: System.Type) =
        if FSharpType.IsTuple propType then
            propType
            |> FSharpType.GetTupleElements
            |> Array.map systemTypeName
            |> List.ofArray
            |> String.concat " * "
        else if FSharpType.IsUnion propType then
            let cases = FSharpType.GetUnionCases propType
            let more =
                if Seq.length cases > 6
                then " | ..."
                else ""
            (cases
            |> Array.truncate 6
            |> Array.map (fun c -> c.Name)
            |> String.concat " | ") + more
        else
            systemTypeName propType

    let getRecordPropFields aType (record: obj) = 
        let recordTypeFields = FSharpType.GetRecordFields aType
        let fieldNames = recordTypeFields |> Array.map SystemType.name
        let fieldPropertyTypes =
            recordTypeFields
            |> Array.map (fun propInfo -> propInfo.PropertyType)
            |> Array.map describeType

        record
        |> FSharpValue.GetRecordFields
        |> Array.zip3 fieldNames fieldPropertyTypes
        |> List.ofArray 
        |> List.map (fun (x, y, _) -> R.str x, R.str y)
        
    let getUnionPropFields (union: System.Type) = 
        FSharpType.GetUnionCases union
        |> List.ofArray
        |> List.collect
            (fun case ->
                let fields = case.GetFields()
                let propTypes =
                    fields
                    |> Array.map (fun e -> e.PropertyType)
                propTypes
                |> Array.map
                    (fun typ -> (case.Name, describeType typ))
                |> Array.map (fun (a, b) -> (R.str a, R.str b))
                |> List.ofArray
            )

    let toTableRow rowValue =
        let (col1, col2) = rowValue
        (Table.Row.props,
         [ Table.Row.Child.Column
             (Table.Column.props, [col1])
           Table.Row.Child.Column
              ({ Table.Column.props with
                   HTMLProps = [ Style [ WhiteSpace "pre" ] ] },
                 [col2]) ])

    let renderTable rowValues =
        Table.ƒ
            ({ Table.props with
                 Kind = Table.Kind.Striped },
             [ Table.Child.Head
                 (Table.Head.props,
                  [ (Table.Row.props,
                     [ Table.Row.Child.TitleColumn
                         (Table.TitleColumn.props,
                          [R.str "Name"])
                       Table.Row.Child.TitleColumn
                           (Table.TitleColumn.props,
                            [R.str "Type"]) ]) ])
               Table.Child.Body
                  (Table.Body.props,
                   (rowValues |> List.map toTableRow)) ])

    let propTable aType obj = getRecordPropFields aType obj |> renderTable 

    let unionPropTable union = getUnionPropFields union |> renderTable
        