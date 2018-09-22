module SelectTests

open Expecto
open Fabulosa
module R = Fable.Helpers.React
open R.Props
open Expect

[<Tests>]
let tests =
    testList "Select tests" [

        test "Select default" {
            let props = Select.props
            let select = Select.ƒ (props, [])
            
            select
            |> ReactNode.unit
            |> hasUniqueClass "form-select"
        }

        test "Select size small" {
            let props = { Select.props with Size = Select.Size.Small }
            let select = Select.ƒ (props, [])
            
            select
            |> ReactNode.unit
            |> hasClass "select-sm"
        }

        test "Select size large" {
            let props = { Select.props with Size = Select.Size.Large }
            let select = Select.ƒ (props, [])
            
            select
            |> ReactNode.unit
            |> hasClass "select-lg"
        }

        test "Select html props" {
            let props = { Select.props with HTMLProps = [ClassName "custom"] }
            let select = Select.ƒ (props, [])
            
            select
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Select children with name" {
            let props = Select.props
            let grandChild = R.str "Value"
            let optionProps = (Select.Option.props, [grandChild])
            let child = Select.Option.ƒ optionProps
            let select = Select.ƒ ( props, [ Select.Child.Option optionProps ] )
            
            select
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Option default" {
            let props = Select.Option.props
            let child = R.str "Value"
            let option = Select.Option.ƒ ( props, [child] )

            option
            |> ReactNode.unit
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Option html props" {
            let props = { Select.Option.props with HTMLProps = [ClassName "custom"] }
            let option = Select.Option.ƒ ( props, [] )
            
            option
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Option children with name" {
            let props = Select.Option.props
            let grandChild = R.RawText "Value"
            let child = R.span [] [grandChild]
            let option = Select.Option.ƒ ( props, [child] )
            
            option
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Option children with class" {
            let props = Select.Option.props
            let grandChild = R.RawText "Value"
            let child = R.span [ClassName "custom"] [grandChild]
            let option = Select.Option.ƒ ( props, [child] )
            
            option
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Option group default" {
            let props = Select.OptionGroup.props
            let optionProps = ( Select.Option.props, [] )
            let child = Select.Option.ƒ optionProps
            let optionGroup = Select.OptionGroup.ƒ ( props, [ optionProps ] )
            
            optionGroup
            |> ReactNode.unit
            |> hasChild 1 (child |> ReactNode.unit)
        }

        test "Option group html props" {
            let props = { Select.OptionGroup.props with HTMLProps = [ClassName "custom"] }
            let optionGroup =
                Select.OptionGroup.ƒ
                    ( props, [] )
            
            optionGroup
            |> ReactNode.unit
            |> hasClass "custom"
        }

        test "Option group children with name" {
            let props = Select.OptionGroup.props
            let grandChild = R.str "Value"
            let optionProps = ( Select.Option.props, [grandChild] )
            let child = Select.Option.ƒ optionProps
            let optionGroup = Select.OptionGroup.ƒ ( props, [optionProps] )
            
            optionGroup
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

        test "Option group children with class" {
            let props = Select.OptionGroup.props
            let grandChild = R.str "Value"
            let optionProps =
                ( { Select.Option.props with
                      HTMLProps = [ClassName "custom"] }, [grandChild] )
            let child =
                Select.Option.ƒ optionProps
            let optionGroup =
                Select.OptionGroup.ƒ ( props, [optionProps] )
            
            optionGroup
            |> ReactNode.unit
            |>! hasChild 1 (child |> ReactNode.unit)
            |> hasChild 1 (grandChild |> ReactNode.unit)
        }

    ]