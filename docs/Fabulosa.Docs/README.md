## Docs

Fabulosa docs are generated with FSharp.Formatting using the FSharp.Literate package.
Each page should be located in the `pages` directory. The doc generation is done in a three step process: 

Write [Component].fs page -> Generate [component].fsx page -> Generate [component].html

You only need to write the <Component>.fs file that will include the code snippets, component demos, and markdown docs.
For the demos use the `React.mountById` helper to inject the fabulosa components into specific containers in the markdown.

To get add a doc page, you need to:

1. Create the new F# [Component].fs file under the `pages` folder
2. Add the page to `App.fs` inside the docs root
3. Add the new [page].html to `webpack.config.js`, inside the pages array
4. Add the menu link entry to docs/Assets/template where appropriate
5. Celebrate

#### Example

```fsharp
// CoolComponent.fs
// NOTE: The module name must be on the first line of the file
module CoolComponentPage


(*** define: my-sample ***)
let coolComponent = R.div [] [R.str "I'm cool, man."]

(** // Some markdown here
## A Cool Component

This is a very cool component
*)

(*** include: my-sample ***) // Code snippet from above appears here

(**
<span class="my-demo"></span> // Demo goes here
*)

(*
tryMount is just a helper to ignore errors from mounting
to a non-existing id, as all these will be all bundled together
*)
tryMount "my-demo" coolComponent
```

This will generate coolcomponent.fsx inside the pages folder, and coolcomponent.html in the root folder.
