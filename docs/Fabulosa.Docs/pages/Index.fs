module IndexPage

open Fabulosa
module R = Fable.Helpers.React
open R.Props

(*** define: sample ***)
let fabulousButton =
    Anchor.ƒ {
        Anchor.defaults with
            Kind = Button.Kind.Primary
            HTMLProps = [Href "button.html"]
    } [R.str "Fabulosa"]
(*** hide ***)
let render () =
    Renderer.tryMount "button-demo" fabulousButton
(**
<h2 class="s-title">
    Getting Started
</h2>
*)

(*** include: sample ***)

(**
<div class="demo" id="button-demo">
</div>
*)
