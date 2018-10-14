module AccordionPage

open Fabulosa.Accordion
open Fabulosa.Icon
open Fabulosa.Docs
module R = Fable.Helpers.React
open Renderer

(*** define: accordion-sample ***)
let element =
    accordion ([],
      [ AccordionItem ([],
          { Header = "Header One"
            Body =
              [ R.a [] [ R.str "Item One" ]
                R.a [] [ R.str "Item Two" ] ] })
        AccordionItem ([],
           { Header = "Header One"
             Body =
               [ R.a [] [ R.str "Item One" ]
                 R.a [] [ R.str "Item Two" ] ] }) ])
(*** define: accordion-custom-sample ***)
let custom =
    accordion ([],
      [ AccordionItem ([ Icon ([], { Kind = Forward }) ],
           { Header = "Header One"
             Body =
               [ R.a [] [ R.str "Item One" ]
                 R.a [] [ R.str "Item Two" ] ] })
        AccordionItem ([ Icon ([], { Kind = Back }) ],
           { Header = "Header One"
             Body =
               [ R.a [] [ R.str "Item One" ]
                 R.a [] [ R.str "Item Two" ] ] }) ])
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

<div id="accordion-item-children">

<h3 class="s-title">
    Item children
</h3>

<div class="props-table" id="accordion-item-children-table"></div>

</div>

*)

(*** hide ***)
let render () =
    tryMount "accordion-demo" element
    tryMount "accordion-custom-demo" custom
    tryMount "accordion-item-children-table"
        (PropTable.propTable typeof<AccordionItemChildren> { Header = "Text"; Body = [] })
    