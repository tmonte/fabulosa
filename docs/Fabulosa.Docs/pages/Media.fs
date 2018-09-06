module MediaPage

open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Docs
open R.Props
open Fable.Import.React
open Renderer

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

(*** define: figure-demo ***)
let figure =
    Media.Figure.ƒ { 
        Media.Figure.defaults with
        Image = { 
            Media.Image.defaults with
                Kind =  Media.Image.Cover 
                HTMLProps = [
                    Src "https://goo.gl/krg6x5"
                    Style [Background "#f8f9fa"; Height "10rem"; Width "100%"]
                ]
        }  
        Caption = { Media.Caption.defaults with Text = [R.str "Ciro Gomes Presidente 2018"]}    
    }
     

(*** hide ***)
let render () =
    tryMount "media-img-responsive-demo-a" (image "5rem")
    tryMount "media-img-responsive-demo-b" (image "12rem")
    tryMount "media-img-responsive-demo-c" (image "18rem")
    tryMount "media-img-fit-contain-demo" imageContain
    tryMount "media-img-fit-cover-demo" imageCover
    tryMount "media-img-props-table" (PropTable.propTable typeof<Media.Image.Props> Media.Image.defaults)
    tryMount "figure-demo" figure
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

<div class="props-table" id="media-img-props-table"></div>

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

(**

<div id="images">
    <h3 class="s-title">
        Figure
    </h3>
</div>    
    
Serves as a container for reponsive images and caption.

<div class="demo">
    <div class="columns">
        <div class="column col-6 col-mx-auto">
             <div id="figure-demo"></div>
        </div>
    </div>
</div>
*)

(*** include: figure-demo ***)
