module IndexPage

open Fabulosa.Button
module R = Fable.Helpers.React
module P = R.Props
open Fable.Import.React
open Renderer

(*** define: sample ***)
let fabulous =
    anchor
        ([ Kind Primary
           P.Href "button.html" ],
         [ R.str "Fabulosa Anchor-Button" ])
(*** hide ***)
let render () =
    tryMount "button-demo" fabulous
(**
<h1>Intro to Fabulosa</h1>
We strongly recommend reading the whole section.

<h2>Installation</h2>

Just use the paket, yo. TO BE DONEs
*)


(**
<div id="example">
    <h2 class="s-title">Getting Started</h2>
</div> 
Creating a fabulous button
*)
(*** include: sample ***)
(** 
<div class="demo" id="button-demo"></div>
*)
(** 

This is quite a simple example. Anchor itself is quite simple and it just takes a list of optional parameters followed by
the anchors' children. More details on components at <a href="#complex-example">Anatomy of a Component</a>
*)



(**
<div id="complex-example">
    <h2 class="s-title">Anatomy of a Component</h2>
</div>
 
Component interfaces are quite simple to understand in Fabulosa but also, if you are using other types of commponents
 available in the Fable Community, you want to check this out because Fabulosa's work conceptually different.

Every component is defined in its own module inside of Fabulosa. 
We recommend opening each module individually to avoid verbosity such as in <code>open Fabulosa.Button</code>

There are two main things you can expect to find inside of each module: 
 - a rendering function named after the component name
 - the component type definition
 
The rendering function takes only one parameter that is the type and returns a ReactElement.
Thus, in the button module, one will find the button function with the following type:

let button: Button -> ReactElement

and it can be used like:

let buttonData: Button = ([ Kind Primary ], [ R.str "Default" ])
let renderedElement: ReactElement = button buttonData


<h3>The Types</h3>
Every Component in Fabulosa can be defined in term of its type. So, a button component will have a Type 
<code>Button</code> associated with it, breakcrumb will have a <code>Breadcrumb</code> and so on.

There are a pattern to these types and it goes as follows:
<code>
    type MyComponent = OptionalProps list * RequiredPropsTuple * ChildrenTuple
</code>

<h5>Optional Parameters</h5>
OptinalParameter list will contain a list of IHTMLProps(these are the same defined in fable-react) and additional OptionalParameters to that component.
For instance a modal component type <a href="https://github.com/tmonte/fabulosa/blob/d78ca0f41a7390c390436c9058d225c784435a12/src/Fabulosa/Components/Tooltip.fs#L32">straight from the source</a>is defined as

<code>
    type Tooltip = HTMLProps * TooltipContent * TooltipChildren
</code>

where HTMLProps is alias to IHTMLProp list. On top of that, all of the <b>optional parameters will implement the IHTMLProp interface</b> in Fabulosa as seen <a href="https://github.com/tmonte/fabulosa/blob/d78ca0f41a7390c390436c9058d225c784435a12/src/Fabulosa/Components/Tooltip.fs#L28">here</a>     
<pre>
<code>
    type TooltipOptional =
        | Orientation of Orientation
        interface IHTMLProp
</code>
</pre>

<h5>Required Props</h5>
Required props are defined as tuple that sits in between the list of optional props and the children. 
<code>type MyComponentType = OptionalProps * RequiredProps * Children</code>

In case a component has no required props, the component interface will be composed of a tuple of only 2 items
<code>type MyComponentType = OptionalProps * Children</code>

<h5>Children</h5>
The biggest difference in fabulosa and other libraries is arguably the way we treat our children.
Most importantly, they will reference internal types over ReactElements as much as possible. The main diffence we we get by doing this is the fact that we believe in the manipulation of the data in destination components and we don't believe that that is easily achievable after componets are rendered. On the other hand, manipulating data is straight forward.
Let's take the Figure type for example

<code>
type FigureChildren =
    | Image of Image
            
type Figure = HTMLProps * FigureChildren
</code>   

Making the dependency of Figure on Image and not a ReactElement, allows us a few things:
- Guarantee that it is a image that gets rendered
- Easy manipulate images attributes inside of Figure if necessary
- Simpler usage of Figure itself when trying to render it
- Future proof, as this pattern allows us more flexibility to future endeavors.

Also note that not all components have Children and in those case they just do not make part of the tuple defining the component type.  

*)

