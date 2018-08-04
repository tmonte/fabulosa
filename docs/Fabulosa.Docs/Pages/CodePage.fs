module CodePage
open Fable.Helpers
open Fable.Helpers.React.Props
open Fabulosa

open ReactElementStringExtensions
open Fabulosa.Docs.JavascriptMapping
open Fabulosa.Docs.Domain


module R = Fable.Helpers.React

let p = ofString Typography.p
  
let htmlCode  = """
let code  = @"<!-- code snippets -->
<button class='btn'>
 Submit
</button>"

let myCustomComponent = 
    { 
        Code.defaults (Highlight.html htmlCode) with 
            Language = "HTML" 
    }
    |> Code.code
"""  

let fsharpCode = """
let myFsharpCode = @"type Yolo = {
    Blah = string
}

let x y z = z y

type Bam = 
| B1
| B2
"

let myCustomComponent = 
    Highlight.fsharp fsharpCode 
    |> Code.defaults
    |> Code.code 

"""
  
let codePage = 
    R.div []
        [
            "Dependencies" |> ofString Typography.h2  
            
            R.str "This component has a dependency on "
            R.a [Href "Code is used for styling inline and multiline code snippets."] [R.str "highlight.js"]
            R.str ". Make sure highlight.js is present in your page."
                
            "Usage" |> ofString Typography.h2
                        
            Highlight.fsharp fsharpCode 
            |> Code.defaults
            |> Code.code 
            
            Highlight.fsharp htmlCode 
            |> Code.defaults
            |> Code.code 
            
        ]

    
let view () = 
    Page.page
        "Code"
        "Code is used for styling inline and multiline code snippets."
        codePage
    