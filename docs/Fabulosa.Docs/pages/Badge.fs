module BadgePage

open Fabulosa
open Renderer
module R = Fable.Helpers.React
open R.Props

let buttonBadge =
    Badge.ƒ
        { Badge.defaults with
            Badge = 1 }
        [Button.ƒ Button.defaults [R.str "Hello"]]
        
let render () =
    tryMount "badge-demo" buttonBadge

(**

<h2 class="s-title">
    Badge
</h2>

Forms provide the most common control styles
used in forms, including input, textarea,
select, checkbox, radio and switch.

<div id="badge-demo"></div>

*)