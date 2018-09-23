module TagPage

open Fabulosa
open Fabulosa.Docs
module R = Fable.Helpers.React
open R.Props
open Fable.Import.React
open Renderer

(*** define: tag-color-demo ***)
let tag =
    Tag.ƒ (Tag.props, "default label")

let primary =
    Tag.ƒ
        ({ Tag.props with
             Color = Tag.Color.Primary },
         "primary label")

let secondary =
    Tag.ƒ
        ({ Tag.props with
             Color = Tag.Color.Secondary },
         "secondary label")

let success =
    Tag.ƒ
        ({ Tag.props with
             Color = Tag.Color.Success },
         "success label")

let warning =
    Tag.ƒ
        ({ Tag.props with
             Color = Tag.Color.Warning },
         "warning label")

let error =
    Tag.ƒ
        ({ Tag.props with
             Color = Tag.Color.Error },
         "error label")
(*** define: tag-rounded-demo ***)
let rounded =
    Tag.ƒ
        ({ Tag.props with
             Rounded = true },
         "rounded label")
(*** hide ***)
let colorDemo =    
    R.div
        [ ClassName "tag-container" ]
        [ R.div [] [ tag ]
          R.div [] [ primary ]
          R.div [] [ secondary ]
          R.div [] [ success ]
          R.div [] [ warning ]
          R.div [] [ error ] ]

let roundedDemo =
    R.div
        [ ClassName "tag-container" ]
        [ R.div [] [ rounded ] ]

let render () =
    tryMount "tag-props-table"
        (PropTable.propTable typeof<Tag.Props> Tag.props)
    tryMount "tag-color-demo" colorDemo
    tryMount "tag-rounded-demo" roundedDemo
(**
<div id="tags">
    <h2 class="s-title">
        Tags
    </h2>
</div>

Tags are formatted text tags for highlighted,
informative information. Tags refere to
Spectre.css [Labels](https://picturepan2.github.io/spectre/elements.html#labels)

<div id="props">
    <h3 class="s-title">
        Props
    </h3>
</div>

<div id="tag-props-table"></div>
*)

(**
<div id="color">
    <h3 class="s-title">
        Color
    </h3>
</div>

<div id="tag-color-demo"></div>

*)
(*** include: tag-color-demo ***)


(**
<div id="rounded">
    <h3 class="s-title">
        Rounded
    </h3>
</div>

<div id="tag-rounded-demo"></div>

*)
(*** include: tag-rounded-demo ***)
