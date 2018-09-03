module MediaPage

open Fabulosa
module R = Fable.Helpers.React
open System.Collections
open System.Reflection
open System.Reflection
open FSharp.Reflection
open Fabulosa
open R.Props

(*** define: media-img-responsive-demo ***)
let image containerWidth =
    R.div [Style [Width containerWidth]] [
        Media.Image.ƒ { 
            Media.Image.defaults with 
                Kind = Media.Image.Responsive
                HTMLProps = [Src "https://goo.gl/krg6x5 "] 
        }
    ]

(*** define: media-img-fit-contain-demo ***)
let imageContain =
    Media.Image.ƒ { 
        Media.Image.defaults with 
            Kind = Media.Image.Contain
            HTMLProps = [
                Src "https://goo.gl/krg6x5"
                Style [Background "#f8f9fa"; Height "10rem"; Width "100%"]
            ]
    }

(*** define: media-img-fit-cover-demo ***)
let imageCover =
    Media.Image.ƒ {
        Media.Image.defaults with
            Kind =  Media.Image.Cover 
            HTMLProps = [
                Src "https://goo.gl/krg6x5"
                Style [Background "#f8f9fa"; Height "10rem"; Width "100%"]
            ] 
    }

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
    
let getImagePropFields = 
    let typ = Media.Image.defaults.GetType()
    let record = Media.Image.defaults
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

let propTable rowValues =
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

(*** hide ***)
let render () =
    Renderer.tryMount "media-img-responsive-demo-a" (image "5rem")
    Renderer.tryMount "media-img-responsive-demo-b" (image "12rem")
    Renderer.tryMount "media-img-responsive-demo-c" (image "18rem")
    Renderer.tryMount "media-img-fit-contain-demo" imageContain
    Renderer.tryMount "media-img-fit-cover-demo" imageCover
    Renderer.tryMount "media-img-props-table" (propTable getImagePropFields)
(**
<div id="media">
    <h2 class="s-title">
        Media
    </h2>
</div>

Media includes responsive images, figures and video classes.

<div id="images">
    <h3 class="s-title">
        Images
    </h3>
</div>    
    
Add the ```img-responsive``` class to <img> elements. The images will scale with the parent sizes.

<div id="media-img-props-table"></div>

*)

(**
<h4 class="s-title">
    Image Responsive
</h4>
<div class="demo">
    <div class="columns">
        <div class="column col-4 col-mr-auto">
            <div class="bg-gray docs-block">container width 5rem</div>
        </div>
        <div class="column col-8 col-mx-auto">
            <div id="media-img-responsive-demo-a"></div>
        </div>
    </div>
    <div class="columns">
        <div class="column col-4 col-mr-auto">
            <div class="bg-gray docs-block">container width 12rem</div>
        </div>
        <div class="column col-8 col-mx-auto">
            <div id="media-img-responsive-demo-b"></div>
        </div>
    </div>
    <div class="columns">
        <div class="column col-4 col-mr-auto">
            <div class="bg-gray docs-block">container width 18rem</div>
        </div>
        <div class="column col-8 col-mx-auto">
            <div id="media-img-responsive-demo-c"></div>
        </div>
    </div>
</div>
*)

(*** include: media-img-responsive-demo ***)

(**
<h4 class="s-title">
    Image Contain
</h4>

<div class="columns">
  <div class="column col-6 col-mx-auto">
    <div id="media-img-fit-contain-demo"></div>
  </div>
</div>
*)
(*** include: media-img-fit-contain-demo ***)

(**
<h4 class="s-title">
    Image Cover
</h4>

<div class="columns">
  <div class="column col-6 col-mx-auto">
    <div id="media-img-fit-cover-demo"></div>
  </div>
</div>
*)
(*** include: media-img-fit-cover-demo ***)
