namespace Fabulosa

module Panel =

    open Fabulosa.Extensions
    open Fabulosa.Tab
    open Fabulosa.Pagination
    open Fabulosa.Breadcrumb
    module R = Fable.Helpers.React
    open R.Props
    open Fable.Import.React

    type PanelHeaderChild =
        | Title of string
        | Subtitle of string
        | Elements of ReactElement list

    type PanelHeaderChildren =
        PanelHeaderChild list

    type PanelHeader =
        HTMLProps * PanelHeaderChildren

    let panelHeaderChildren =
        function
        | Title title ->
            R.div
                [ ClassName "panel-subtitle" ]
                [ R.str title ]
        | Subtitle subtitle ->
            R.div
                [ ClassName "panel-subtitle" ]
                [ R.str subtitle ]
        | Elements elements ->
            R.fragment [] elements

    let panelHeader ((opt, chi): PanelHeader) =
        Unmerged opt
        |> addProp (ClassName "panel-header")
        |> merge
        |> R.div
        <| [ R.div
               [ ClassName "panel-title h6"]
               (Seq.map panelHeaderChildren chi) ]

    type PanelNavChild =
        | Breadcrumb of Breadcrumb
        | Pagination of Pagination
        | Tab of Tab

    type PanelNav =
        HTMLProps * PanelNavChild

    let private panelNavChild =
        function
        | Breadcrumb bc -> breadcrumb bc
        | Pagination pg -> pagination pg
        | Tab tb -> tab tb

    let panelNav ((opt, chi): PanelNav) =
        Unmerged opt
        |> addProp (ClassName "panel-nav")
        |> merge
        |> R.div
        <| [ panelNavChild chi ]

    type PanelBody =
        HTMLProps * ReactElement list

    let panelBody ((opt, chi): PanelBody) =
        Unmerged opt
        |> addProp (ClassName "panel-body")
        |> merge
        |> R.div <| chi

    type PanelFooter =
        HTMLProps * ReactElement list

    let panelFooter ((opt, chi): PanelFooter) =
        Unmerged opt
        |> addProp (ClassName "panel-footer")
        |> merge
        |> R.div <| chi

    type PanelChild =
        | Header of PanelHeader
        | Nav of PanelNav
        | Body of PanelBody
        | Footer of PanelFooter

    type Panel =
        HTMLProps * PanelChild list

    let private panelChild =
        function
        | Header header -> panelHeader header
        | Nav nav -> panelNav nav
        | Body body -> panelBody body
        | Footer footer -> panelFooter footer

    let panel ((opt, chi): Panel) =
        Unmerged opt
        |> addProp (ClassName "panel")
        |> merge
        |> R.div
        <| Seq.map panelChild chi
