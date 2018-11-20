module AccordionPage

open Fabulosa.Icon
open Fabulosa.Accordion
open Fabulosa.Docs
module R = Fable.Helpers.React
module P = R.Props
open Renderer

(*** define: accordion-sample ***)
let def =
    accordion ([],
      [ Item ([],
          (OptIcon None,
           Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ]))
        Item ([],
          (OptIcon None,
           Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ])) ])
(*** define: accordion-custom-sample ***)
let custom =
    accordion ([],
      [ Item ([],
          (OptIcon (Some ([], Kind Forward)),
           Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ] ))
        Item ([],
          (OptIcon (Some ([], Kind Back)),
           Header "Header One",
           Body
             [ R.a [] [ R.str "Item One" ]
               R.a [] [ R.str "Item Two" ] ])) ])
(*** hide ***)
let render () =
    tryMount "accordion-demo" def
    tryMount "accordion-custom-demo" custom
    tryMount "accordion-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<AccordionChild>))
    tryMount "accordion-item-params-table"
        (PropTable.paramTable
            None
            None
            (Some typeof<AccordionItemChildren>))
(**

<div id="accordions">

<h2 class="s-title">Accordions</h2>

Accordions are used to toggle sections of content.

#### Parameters

<div class="props-table" id="accordion-params-table"></div>

#### Item Parameters

<div class="props-table" id="accordion-item-params-table"></div>

#### Example

An accordion with default settings.

<div class="demo" id="accordion-demo"></div>

*)
(*** include: accordion-sample ***)
(**

#### Custom Icon

Accordions accept icon props for a custom icon.

<div class="demo" id="accordion-custom-demo"></div>

*)
(*** include: accordion-custom-sample ***)
(**

</div>

*)
    