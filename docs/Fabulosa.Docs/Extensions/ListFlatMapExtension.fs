namespace Fabulosa.Docs.ListFlatMapExtension

module List = 
    let flatMap list = List.collect (fun x -> x) list