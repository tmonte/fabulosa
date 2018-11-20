module IndexPage


open Fable.Import.React
open Fabulosa.Image
open Fabulosa.Button
open Fabulosa.Tooltip
module R = Fable.Helpers.React
module P = R.Props
open Renderer

(*** hide ***)
type OptionalProps = unit
type RequiredPropsTuple = unit
type ChildrenTuple = unit
//Could refer the actual types, but this is just easier for docs purposes.
type HTMLProps = unit 
type IHTMLProp = interface end 
type RequiredProps = unit
type Children = unit   

(*** define: anchor ***)
let fabulous =
    anchor
        ([ Kind Primary
           P.Href "button.html" ],
         [ R.str "Fabulosa Anchor-Button" ])
(*** hide ***)
let render () =
    tryMount "anchor-demo" fabulous
    
(*** define: button-type ***)
let buttonRenderingFn: Button -> ReactElement = Fabulosa.Button.button    

(*** define: button-rendering ***)
let buttonData: Button = ([ Kind Primary ], [ R.str "Default" ])
let renderedElement: ReactElement = button buttonData



(*** define: component-pattern ***)
type MyComponent = OptionalProps list * RequiredPropsTuple * ChildrenTuple

(*** define: tooltip-type-example ***)
type Tooltip = HTMLProps * TooltipContent * TooltipChildren

(*** define: tooltip-optional-params ***)
type TooltipOptional =
    | Orientation of Orientation
    interface IHTMLProp

(*** define: required-props ***)
type MyComponentType = OptionalProps * RequiredProps * Children

(*** define: missing-required-props ***)
type MySecondComponentType = OptionalProps * Children

(*** define: children-example ***)
type FigureChildren =
    | Image of Image
            
type Figure = HTMLProps * FigureChildren

(**
<div id="intro">

<h2 class="s-title">Intro to Fabulosa</h2>

We strongly recommend reading the whole section.

</div>

<div id="installation">

<h2 class="s-title">Installation</h2>

Documentation not ready yet.

</div>

*)

(**

<div id="getting-started">

<h2 class="s-title">Getting Started</h2>

Creating a fabulous button

*)
(*** include: anchor ***)
(**

<div class="demo" id="anchor-demo"></div>

This is quite a simple example. Anchor itself is quite simple and it just takes a list of optional parameters followed by
the anchors' children. More details on components at <a href="#complex-example">Anatomy of a Component</a>

</div>

<div id="anatomy-of-a-component">

<h2 class="s-title">Anatomy of a Component</h2>
 
Component interfaces are quite simple to understand in Fabulosa but also, if you are using other types of commponents
 available in the Fable Community, you want to check this out because Fabulosa's work conceptually different.

Every component is defined in its own module inside of Fabulosa. 
We recommend opening each module individually to avoid verbosity such as in <code>open Fabulosa.Button</code>

There are two main things you can expect to find inside of each module: 
 - a rendering function named after the component name
 - the component type definition
 
The rendering function takes only one parameter that is the type and returns a ReactElement.
Thus, in the button module, one will find the button function with the following type:
*)
(*** include: button-type ***)
(**
and it can be used like:
*)
(*** include: button-rendering ***)

(**
<br/>

### The Types

Every Component in Fabulosa can be defined in term of its type. So, a button component will have a Type 
<code>Button</code> associated with it, breakcrumb will have a <code>Breadcrumb</code> and so on.

There is a pattern to these types and it goes as follows:
*)
(*** include: component-pattern ***)

(**
<br/>

#### Optional Parameters

OptinalParameter list will contain a list of IHTMLProps(these are the same defined in fable-react) and additional OptionalParameters to that component.
For instance a modal component type <a href="https://github.com/tmonte/fabulosa/blob/d78ca0f41a7390c390436c9058d225c784435a12/src/Fabulosa/Components/Tooltip.fs#L32">straight from the source</a> is defined as
*)

(*** include: tooltip-type-example ***)

(**

where HTMLProps is alias to IHTMLProp list. On top of that, all of the <b>optional parameters will implement the IHTMLProp interface</b> in Fabulosa as seen <a href="https://github.com/tmonte/fabulosa/blob/d78ca0f41a7390c390436c9058d225c784435a12/src/Fabulosa/Components/Tooltip.fs#L28">here</a>     
*)
(*** include: tooltip-optional-params ***)
(**
<br />

#### Required Props

Required props are defined as tuple that sits in between the list of optional props and the children. 
*)
(*** include: required-props ***)
(**

In case a component has no required props, the component interface will be composed of a tuple of only 2 items
*)
(*** include: missing-required-props ***)
(**

#### Children

The biggest difference in fabulosa and other libraries is arguably the way we treat our children.
Most importantly, they will reference internal types over ReactElements as much as possible. The main diffence we we get by doing this is the fact that we believe in the manipulation of the data in destination components and we don't believe that that is easily achievable after componets are rendered. On the other hand, manipulating data is straight forward.
Let's take the Figure type for example

*)
(*** include: children-example ***)
(**

Making the dependency of Figure on Image and not a ReactElement, allows us a few things:
- Guarantee that it is a image that gets rendered
- Easy manipulate images attributes inside of Figure if necessary
- Simpler usage of Figure itself when trying to render it
- Future proof, as this pattern allows us more flexibility to future endeavors.

Also note that not all components have Children and in those case they just do not make part of the tuple defining the component type.  

</div>

<div id="theming">

<h2 class="s-title">Theming</h2>

Documentation not ready yet.

</div>

*)

