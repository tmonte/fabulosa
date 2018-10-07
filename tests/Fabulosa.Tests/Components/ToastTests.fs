module ToastTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open Fable.Import.React
open R.Props
open Expect
open Foq

let mockElement text =
    Mock<Fable.Import.Browser.Element>
        .Property(fun x -> <@ x.innerHTML @>)
        .Returns(text)

let mockEvent mockElement =
    Mock<Fable.Import.React.MouseEvent>
        .Property(fun x -> <@ x.currentTarget @>)
        .Returns(mockElement)

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

        test "Toast colors" {
            Toast.ƒ
                ({ Toast.props with
                     Color = Toast.Color.Primary },
                 "Toast")
            |> ReactNode.unit
            |> hasClass "toast-primary"
            Toast.ƒ
                ({ Toast.props with
                     Color = Toast.Color.Success },
                 "Toast")
            |> ReactNode.unit
            |> hasClass "toast-success"
            Toast.ƒ
                ({ Toast.props with
                     Color = Toast.Color.Warning },
                 "Toast")
            |> ReactNode.unit
            |> hasClass "toast-warning"
            Toast.ƒ
                ({ Toast.props with
                     Color = Toast.Color.Error },
                 "Toast")
            |> ReactNode.unit
            |> hasClass "toast-error"
        }

        test "Toast close" {
            let clickable = mockElement "Text"
            let event = mockEvent clickable
            let fn (e: MouseEvent) =
                Expect.equal
                    ((e.currentTarget) :> obj)
                    ((clickable) :> obj)
                    "Should be the mocked element"
            let props =
                Toast.ƒ
                    ({ Toast.props with
                         OnRequestClose = Some fn },
                     "Toast")
                |> ReactNode.unit
                |> ReactNode.descendentProps
            let onClick (prop: IProp) =
                match prop with
                | :? DOMAttr as attr ->
                    match attr with
                    | OnClick fn -> Some fn
                    | _ -> None
                | _ -> None
            match Seq.tryPick onClick props with
            | Some fn -> fn (event)
            | None ->
                Expect.isTrue
                    false
                    "Did not contain onClick prop"
            
        }
       
    ]