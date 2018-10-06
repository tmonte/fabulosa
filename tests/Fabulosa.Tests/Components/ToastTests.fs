module ToastTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect


[<Tests>]
let tests =
    testList "Toast tests" [

        test "Toast default" {
           Toast.ƒ
               (Toast.props, "Toast")
            |> ReactNode.unit
            |> hasUniqueClass "toast"
        }

        test "Toast html props" {
            Toast.ƒ
                ({ Toast.props with
                     HTMLProps =
                       [ ClassName "custom" ] },
                 "")
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Toast children" {
            Toast.ƒ
                (Toast.props, "Toast")
            |> ReactNode.unit
            |> hasText "Toast"
        }

        // colors

        // onRequestClose
       
    ]