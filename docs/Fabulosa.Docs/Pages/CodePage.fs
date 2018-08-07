module CodePage
open Fable.Helpers
open Fable.Helpers.React.Props
open Fabulosa
open Fabulosa.Docs.ListFlatMapExtension
open ReactElementStringExtensions
open Fabulosa.Docs.JavascriptMapping
open Fabulosa.Docs.Domain
open Fabulosa.Docs.JavascriptMapping



module R = Fable.Helpers.React
  
let code  = """<span class="hljs-comment">&lt;!-- code snippets --&gt;</span>
<span class="hljs-tag">&lt;<span class="hljs-name">button</span> <span class="hljs-attr">class</span>=<span class="hljs-string">"btn"</span>&gt;</span>
  Submit
<span class="hljs-tag">&lt;/<span class="hljs-name">button</span>&gt;</span>
"""  

let fsharpCode = """type Yolo = {
    Blah = string
}

let x y z = z y

type Bam = 
| B1
| B2
"""
  
let typographyPage = 
    R.div []
        [
            R.pre [ClassName "code"; Data ("lang", "HTML")] [
                R.code [DangerouslySetInnerHTML <| { __html = code }] []            
            ]
            R.pre [ClassName "code"; Data ("lang", "F#")] [
                R.code [DangerouslySetInnerHTML <|  Highlight.highlight fsharpCode] []            
            ]
        ]
    
let view () = 
    [ 
        ofString Typography.h1 "Code"
        ofString Typography.p "Typography sets default styles for headings, paragraphs, semantic text, blockquote and lists elements."
        typographyPage 
    ]
    |> 
    R.div [] 
