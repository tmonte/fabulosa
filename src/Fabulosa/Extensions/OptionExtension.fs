namespace Fabulosa.Extensions

module Option =
    let map2 f x y =
        match x, y with 
        | Some a, Some b -> Some (f a b)
        | _ -> None
        