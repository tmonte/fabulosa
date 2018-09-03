namespace Fabulosa.Docs

module PropTable =
    open System.Reflection
    open FSharp.Reflection
    module R = Fable.Helpers.React
    open Fabulosa
    
    let flip f a b = f b a
    
    module SystemType =
        let name (typ: PropertyInfo) = typ.Name
    
    let rec describeName (typeInfo: PropertyInfo) =
        match typeInfo.PropertyType with 
        | list when list.Name = "FSharpList`1" -> 
            list.GenericTypeArguments
            |> List.ofArray
            |> List.map (fun f -> f.Name)
            |> flip List.append ["list"]
            |> List.reduce (fun x -> (fun y -> x + " " + y))
        | t -> t.Name
        
    let getPropFields aType (obj: obj) = 
        let typ = aType
        let record = obj
        let recordTypeFields = FSharpType.GetRecordFields typ
        let recordValueFields = FSharpValue.GetRecordFields record
        let fieldNames = recordTypeFields |> Array.map SystemType.name
        let fieldPropertyTypes = recordTypeFields |> Array.map describeName
    
        Fable.Import.JS.console.log(recordTypeFields |> Array.map describeName)
        
        recordValueFields
        |> Array.zip3 fieldNames fieldPropertyTypes
        |> List.ofArray 
        |> List.map (fun (x, y, z) -> x.ToString(), y, z.ToString())
        
    
    let toTableRow rowValue =
        let (col1, col2, col3) = rowValue
        Table.Row.ƒ Table.Row.defaults [
            Table.Column.ƒ Table.Column.defaults [R.str col1]
            Table.Column.ƒ Table.Column.defaults [R.str col2]
            Table.Column.ƒ Table.Column.defaults [R.str col3]
        ]
    
    let renderTable rowValues =
        Table.ƒ Table.defaults [
            Table.Head.ƒ Table.Head.defaults [
                Table.Row.ƒ Table.Row.defaults [
                    Table.Column.ƒ Table.Column.defaults [R.str "Name"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Type"]
                    Table.Column.ƒ Table.Column.defaults [R.str "Default"]
                ]
            ]
            Table.Body.ƒ Table.Body.defaults (rowValues |> List.map toTableRow) 
            
        ]
        
    let propTable aType obj = getPropFields aType obj |> renderTable 
        