module AccordionPage

open Fabulosa.Accordion
open Fabulosa.Icon
open Fabulosa.Docs
module R = Fable.Helpers.React
open Renderer

(*** define: accordion-sample ***)
let element =
    accordion ([],
      [ Item ([],
          (Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ]))
        Item ([],
          (Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ])) ])
(*** define: accordion-custom-sample ***)
let custom =
    accordion ([],
      [ Item ([ Icon ([], Kind Forward) ],
          (Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ] ))
        Item ([ Icon ([], Kind Back) ],
          (Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ])) ])
(*** hide ***)
let render () =
    tryMount "accordion-demo" element
    tryMount "accordion-custom-demo" custom
    tryMount "accordion-item-header-table"
        (PropTable.unionPropTable typeof<AccordionHeader>)
    tryMount "accordion-item-body-table"
        (PropTable.unionPropTable typeof<AccordionBody>)
    tryMount "accordion-item-optional-table"
        (PropTable.unionPropTable typeof<AccordionItemOptional>)
(**

<div id="accordions">

<h2 class="s-title">
    Accordions
</h2>

Accordions are used to toggle sections of content.

</div>

<div id="accordion-default">

<h3 class="s-title">
    Default
</h3>

The default setting for accordions

<div class="demo" id="accordion-demo"></div>

*)

(*** include: accordion-sample ***)

(**

</div>

<div id="accordion-custom">

<h3 class="s-title">
    Custom Icon
</h3>

Accordions accept icon props for a custom icon.

<div class="demo" id="accordion-custom-demo"></div>

*)

(*** include: accordion-custom-sample ***)

(**

</div>

<div id="accordion-item-header">

<h3 class="s-title">
    Item header
</h3>

<div class="props-table" id="accordion-item-header-table"></div>

</div>

<div id="accordion-item-body">

<h3 class="s-title">
    Item body
</h3>

<div class="props-table" id="accordion-item-body-table"></div>

</div>

<div id="accordion-item-optional">

<h3 class="s-title">
    Item optional props
</h3>

<div class="props-table" id="accordion-item-optional-table"></div>

</div>

*)
    