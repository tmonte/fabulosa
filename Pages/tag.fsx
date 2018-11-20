(*** hide ***)
module TagPage
#r "Facades/netstandard"
#r "../../../src/Fabulosa/bin/Release/netstandard2.0/Fabulosa.dll"
#r "../../../node_modules/fable-core/Fable.Core.dll"
#r "../../../node_modules/fable-react/Fable.React.dll"
#load "../../../.paket/load/netstandard2.0/Fable.React.fsx"


open Fabulosa
open Fabulosa.Tag
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Renderer
open Fabulosa.Extensions.Fable.Helpers.React.Props
open Fable.Import.React

(*** define: tag-color-demo ***)
let def = tag ([], Text "default label")

let primary = tag ([ Color Primary ], Text "primary label")

let secondary = tag ([ Color Secondary ], Text "secondary label")

let success = tag ([ Color Success ], Text "success label")

let warning = tag ([ Color Warning ], Text "warning label")

let error = tag ([ Color Error ], Text "error label")
(*** define: tag-rounded-demo ***)
let rounded = tag ([ Rounded ], Text "rounded label")
(*** hide ***)
let colorDemo =    
    R.div
        [ P.ClassName "tag-container" ]
        [ R.div [] [ def ]
          R.div [] [ primary ]
          R.div [] [ secondary ]
          R.div [] [ success ]
          R.div [] [ warning ]
          R.div [] [ error ] ]

let roundedDemo =
    R.div
        [ P.ClassName "tag-container" ]
        [ R.div [] [ rounded ] ]

let render () =
    tryMount "tag-params-table"
        (PropTable.paramTable
            (Some typeof<TagOptional>)
            None
            (Some typeof<FabulosaText>))
    tryMount "tag-color-demo" colorDemo
    tryMount "tag-rounded-demo" roundedDemo
(**
<div id="tags">

<h2 class="s-title">Tags</h2>

Tags are formatted text tags for highlighted,
informative information. Tags refere to
Spectre.css [Labels](https://picturepan2.github.io/spectre/elements.html#labels)

#### Parameters

<div class="props-table" id="tag-params-table"></div>

#### Color

<div id="tag-color-demo"></div>

*)
(*** include: tag-color-demo ***)
(**

#### Rounded

<div id="tag-rounded-demo"></div>

*)
(*** include: tag-rounded-demo ***)
(**

</div>

*)