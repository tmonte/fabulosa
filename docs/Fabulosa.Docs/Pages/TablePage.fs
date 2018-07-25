module TablePage

module R = Fable.Helpers.React

let view () =
    R.div [] [
        R.h2 [] [R.str "Table"]
        R.p [] [R.str "Tables include default styles for tables and data sets."]
        Table.table [Table.Kind Table.Striped] [] [
            Table.thead [] [
                Table.tr [] [] [
                    Table.th [] [R.str "Column 1"]
                    Table.th [] [R.str "Column 2"]
                    Table.th [] [R.str "Column 3"]
                ]
            ]
            Table.tbody [] [
                Table.tr [] [] [
                    Table.td [] [R.str "Value 1"]
                    Table.td [] [R.str "Value 2"]
                    Table.td [] [R.str "Value 3"]
                ]
                Table.tr [] [] [
                    Table.td [] [R.str "Value 4"]
                    Table.td [] [R.str "Value 5"]
                    Table.td [] [R.str "Value 6"]
                ]
                Table.tr [] [] [
                    Table.td [] [R.str "Value 7"]
                    Table.td [] [R.str "Value 8"]
                    Table.td [] [R.str "Value 9"]
                ]
            ]
        ]
    ]