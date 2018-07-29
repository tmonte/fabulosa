namespace Fabulosa

module ReactElementStringExtensions =

    module R = Fable.Helpers.React

    let ofString element str = element [] [R.str str] 