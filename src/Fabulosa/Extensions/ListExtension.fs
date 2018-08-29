namespace Fabulosa

module List =
    let cast<'a> = Seq.cast<'a> >> List.ofSeq 