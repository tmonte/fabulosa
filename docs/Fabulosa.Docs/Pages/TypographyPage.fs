module TypographyPage
open Fable.Helpers
open Fable.PowerPack.Keyboard
open Fable.Helpers.React.Props
open ReactElementStringExtensions

module R = Fable.Helpers.React

let page header subheader body = 
    R.div [] [
        R.h1 [] [R.str header]
        R.p [] [R.str subheader]
        body
    ]
    
let block title stringfiedCode pageBlock =
    R.div [] 
        [
            ofString Typography.h4 title
            R.div [ClassName "component-view-container"] 
                [
                    pageBlock
                ]
            R.div [ClassName "code-container"]
                [
                    R.pre [] [R.str stringfiedCode]
                ]
        ]
        
        
let headingsBlock =  
    block 
       "Headings" 
       """
           ofString Typography.h1 "H1 Heading"
           ofString Typography.h2 "H2 Heading"
           ofString Typography.h3 "H3 Heading"
           ofString Typography.h4 "H4 Heading"
           ofString Typography.h5 "H5 Heading"
           ofString Typography.h6 "H6 Heading"
       """ 
       <| R.div [] 
           [
               ofString Typography.h1 "H1 Heading"
               ofString Typography.h2 "H2 Heading"
               ofString Typography.h3 "H3 Heading"
               ofString Typography.h4 "H4 Heading"
               ofString Typography.h5 "H5 Heading"
               ofString Typography.h6 "H6 Heading"
           ]       

let paragraphsBlock = 
    block 
           "Paragraphs" 
           """
               Typography.p []
                   [
                       R.str "Lorem ipsum dolor sit amet, consectetur "
                       R.a [] [R.str "adipiscing elit"]
                       R.str ". Praesent risus leo, dictum in vehicula sit amet, feugiat tempus tellus. Duis quis sodales risus. Etiam euismod ornare consequat"
                   ]
               ofString Typography.p "limb leg rub face on everything give attitude nap all day for under the bed. Chase mice attack feet but rub face on everything hopped up on goofballs."
           """ 
           <| R.div [] 
               [
                   Typography.p []
                        [
                            R.str "Lorem ipsum dolor sit amet, consectetur "
                            R.a [] [R.str "adipiscing elit"]
                            R.str ". Praesent risus leo, dictum in vehicula sit amet, feugiat tempus tellus. Duis quis sodales risus. Etiam euismod ornare consequat"
                        ]
                   ofString Typography.p "limb leg rub face on everything give attitude nap all day for under the bed. Chase mice attack feet but rub face on everything hopped up on goofballs."
               ]       
    
let typographyPage = 
    R.div []
        [
            headingsBlock
            paragraphsBlock
        ]
    

let view () = typographyPage |> page "Typography" "Typography sets default styles for headings, paragraphs, semantic text, blockquote and lists elements." 
