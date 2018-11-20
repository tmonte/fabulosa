module MediaPage

open Fabulosa
module R = Fable.Helpers.React
open Fabulosa.Docs
open R.Props
open Fable.Import.React
open Renderer
open Fabulosa.Image

(*** define: media-img-responsive-demo ***)
let demo =
    image [ Src "https://goo.gl/DbSvSD" ]

let imageContainer containerWidth =
    R.div
        [ Style [ Width containerWidth ] ]
        [ demo ]

(*** hide ***)
let style =
    Style
        [ Background "#f8f9fa"
          Height "10rem"
          Width "100%" ]

(*** define: media-img-fit-contain-demo ***)
let contain =
    image [ Kind Contain
            Src "https://goo.gl/DbSvSD"
            style ] 
(*** define: media-img-fit-cover-demo ***)
let cover =
    image [ Kind Cover 
            Src "https://goo.gl/DbSvSD"
            style ] 

(*** hide ***)
let src = "https://interactive-examples.mdn.mozilla.net/media/examples/stream_of_water.webm"
open Fabulosa.Video

(*** define: video-demo ***)
let videoDemo =
    video ([], Kind (Source src) )

let youtube =
    video (
        [ HTMLAttr.Width 560
          HTMLAttr.Height 315
          Src "https://www.youtube.com/embed/6AgiQWk4kqA"
          AllowFullScreen true ],
          Kind Frame ) 
(*** hide ***)
open Fabulosa.Figure
(*** define: figure-demo ***)
let figureDemo = 
    figure ([Caption ([], Fabulosa.Caption.Text "Who controls the past controls the future: who controls the present controls the past.")], 
             Image [Src "https://wallpaper-house.com/data/out/10/wallpaper2you_385583.jpg"])
    
(*** hide ***)
let render () = 
    tryMount "media-img-responsive-demo-a" (imageContainer "5rem")
    tryMount "media-img-responsive-demo-b" (imageContainer "12rem")
    tryMount "media-img-responsive-demo-c" (imageContainer "18rem")
    tryMount "media-img-fit-contain-demo" contain
    tryMount "media-img-fit-cover-demo" cover
    // tryMount "media-img-props-table"
    //     (PropTable.unionPropTable typeof<Media.Image.ImageOptional>)
    // tryMount "figure-props-table"
    //     (PropTable.unionPropTable typeof<Media.Figure.FigureOptional>)
    // tryMount "figure-demo" figureDemo
    // tryMount "caption-props-table"
    //     (PropTable.unionPropTable typeof<Media.Caption.CaptionOptional> )
    tryMount "video-demo" videoDemo
    tryMount "youtube-demo" youtube
    //     (PropTable.unionPropTable typeof<Media.Video.VideoOptional>)
(**
<div id="media">
<h2 class="s-title">Media</h2>

Media includes responsive images, figures and video classes.

</div>

<div id="images">
<h3 class="s-title">Images</h3>

Add the ```img-responsive``` class to <img> elements. The images will scale with the parent sizes.

</div>

<div id="image-props">
<h3 class="s-title">Image Props</h3>
<div class="props-table" id="media-img-props-table"></div>
</div>

<div id="image-responsive">
<h4 class="s-title">Image Responsive</h4>
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
</div>
*)

(**
<div id="image-contain">
<h4 class="s-title">Image Contain</h4>
<div class="columns">
<div class="column col-6 col-mx-auto">
<div id="media-img-fit-contain-demo"></div>
</div>
</div>
*)
(*** include: media-img-fit-contain-demo ***)
(**
</div>
*)

(**
<div id="image-cover">
<h4 class="s-title">Image Cover</h4>
<div class="columns">
<div class="column col-6 col-mx-auto">
<div id="media-img-fit-cover-demo"></div>
</div>
</div>
*)
(*** include: media-img-fit-cover-demo ***)
(**
</div>
*)


(**
<div id="video">
<h3 class="s-title">Video</h3>

A container for video elements

</div>

<div id="video-props">
<h4 class="s-title">Video Props</h4>
<div class="props-table" id="video-props-table"></div>
</div>

<div id="video-examples">
<h4 class="s-title">Video Examples</h4>
<div class="demo">
<div class="columns">
<div class="column col-6 col-mx-auto">
<div id="video-demo"></div>
</div>
</div>
<div class="columns">
<div class="column col-6 col-mx-auto">
<div id="youtube-demo"></div>
</div>
</div>
</div>    
</div>
**)

(*** include: video-demo ***)

(**
<div id="figure">
<h3 class="s-title">Figure/Caption</h3>

Figure serves as a container for reponsive
images and caption. Caption defines the
text(or any ReactElement) that is displayed
as metadata about the image.

</div>

<div id="figure-props">
<h4 class="s-title">
Figure Props
</h4>
<div class="props-table" id="figure-props-table"></div>
</div>    

<div id="caption-props">
<h4 class="s-title">Caption Props</h4>
<div class="props-table" id="caption-props-table"></div>
</div>

<div id="figure-examples">

<h4 class="s-title">
Figure Example
</div>

<div class="demo">
<div class="columns">
<div class="column col-6 col-mx-auto">
<div id="figure-demo"></div>
</div>
</div>
</div>
*)

(*** include: figure-demo ***)
