module Renderer

module R = Fable.Helpers.React

let tryMount id elem =
    try
        R.mountById id elem
    with
        | _ -> ()