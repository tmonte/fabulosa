namespace Fabulosa

module R = Fable.Helpers.React
open R.Props


[<RequireQualifiedAccess>]
module Code =
    open Fable.Helpers.React.Props
    
    type Props = {
        Code: DangerousHtml
        Language: string
    }
    
    let defaults code = {
        Code = code
        Language = "F#"
    }
    
    let code props = 
        R.pre [ClassName "code"; Data ("lang", props.Language)] [
            R.code [DangerouslySetInnerHTML props.Code] []            
        ]