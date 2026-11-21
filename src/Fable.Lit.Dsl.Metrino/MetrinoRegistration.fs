namespace Fable.Lit.Dsl.Metrino

open Fable.Core

/// Registration API for Metrino web components.
///
/// Metrino does not register custom elements as an import side effect:
/// call `Metrino.registerAll()`, a category (`Metrino.registerInputs()`), or individual
/// components (`Metrino.Register.button()`) once at app startup.
/// Dependencies are registered automatically (e.g. `pivot()` also registers `metro-pivot-item`).
[<AutoOpen>]
module MetrinoRegistration =

    module Metrino =
        /// The npm package name for Metrino.
        let [<Literal>] Package = "@angelmunoz/metrino"

        /// Registers every Metrino component.
        [<Import("registerAllComponents", Package)>]
        let registerAll () : unit = jsNative

        // =====================================================================
        // Categories
        // =====================================================================

        /// Registers button, dropdown-button, hyperlink-button and repeat-button.
        [<Import("registerButtons", Package)>]
        let registerButtons () : unit = jsNative

        /// Registers calendar, calendar-date-picker, date-picker(-roller) and time-picker(-roller).
        [<Import("registerDatetime", Package)>]
        let registerDatetime () : unit = jsNative

        /// Registers content-dialog, flyout, message-dialog, settings-flyout and teaching-tip.
        [<Import("registerDialogs", Package)>]
        let registerDialogs () : unit = jsNative

        /// Registers all input controls (text-box, check-box, combo-box, slider, etc.).
        [<Import("registerInputs", Package)>]
        let registerInputs () : unit = jsNative

        /// Registers all layout panels (grid, stack-panel, wrap-panel, scroll-viewer, etc.).
        [<Import("registerLayout", Package)>]
        let registerLayout () : unit = jsNative

        /// Registers all navigation components (pivot, hub, panorama, app-bar, split-view, etc.).
        [<Import("registerNavigation", Package)>]
        let registerNavigation () : unit = jsNative

        /// Registers all primitives (icon, text-block, border, expander, toast, tooltip, etc.).
        [<Import("registerPrimitives", Package)>]
        let registerPrimitives () : unit = jsNative

        /// Registers progress-bar and progress-ring.
        [<Import("registerProgress", Package)>]
        let registerProgress () : unit = jsNative

        /// Registers all selection components (list-box, list-view, grid-view, tree-view, etc.).
        [<Import("registerSelection", Package)>]
        let registerSelection () : unit = jsNative

        /// Registers live-tile, flip-tile, cycle-tile and iconic-tile.
        [<Import("registerTiles", Package)>]
        let registerTiles () : unit = jsNative

        // =====================================================================
        // Individual components
        // =====================================================================

        /// Per-component registration, for the smallest bundles.
        module Register =
            // Buttons
            [<Import("registerMetroButton", Package)>]
            let button () : unit = jsNative
            [<Import("registerMetroDropdownButton", Package)>]
            let dropdownButton () : unit = jsNative
            [<Import("registerMetroHyperlinkButton", Package)>]
            let hyperlinkButton () : unit = jsNative
            [<Import("registerMetroRepeatButton", Package)>]
            let repeatButton () : unit = jsNative

            // Date & time
            [<Import("registerMetroCalendar", Package)>]
            let calendar () : unit = jsNative
            [<Import("registerMetroCalendarDatePicker", Package)>]
            let calendarDatePicker () : unit = jsNative
            [<Import("registerMetroDatePicker", Package)>]
            let datePicker () : unit = jsNative
            [<Import("registerMetroDatePickerRoller", Package)>]
            let datePickerRoller () : unit = jsNative
            [<Import("registerMetroTimePicker", Package)>]
            let timePicker () : unit = jsNative
            [<Import("registerMetroTimePickerRoller", Package)>]
            let timePickerRoller () : unit = jsNative

            // Dialogs
            [<Import("registerMetroContentDialog", Package)>]
            let contentDialog () : unit = jsNative
            [<Import("registerMetroFlyout", Package)>]
            let flyout () : unit = jsNative
            [<Import("registerMetroMessageDialog", Package)>]
            let messageDialog () : unit = jsNative
            [<Import("registerMetroSettingsFlyout", Package)>]
            let settingsFlyout () : unit = jsNative
            [<Import("registerMetroTeachingTip", Package)>]
            let teachingTip () : unit = jsNative

            // Input
            [<Import("registerMetroAutoSuggestBox", Package)>]
            let autoSuggestBox () : unit = jsNative
            [<Import("registerMetroCheckBox", Package)>]
            let checkBox () : unit = jsNative
            [<Import("registerMetroComboBox", Package)>]
            let comboBox () : unit = jsNative
            [<Import("registerMetroNumberBox", Package)>]
            let numberBox () : unit = jsNative
            [<Import("registerMetroPasswordBox", Package)>]
            let passwordBox () : unit = jsNative
            [<Import("registerMetroRadioButton", Package)>]
            let radioButton () : unit = jsNative
            [<Import("registerMetroRating", Package)>]
            let rating () : unit = jsNative
            [<Import("registerMetroRichEditBox", Package)>]
            let richEditBox () : unit = jsNative
            [<Import("registerMetroSlider", Package)>]
            let slider () : unit = jsNative
            [<Import("registerMetroTextBox", Package)>]
            let textBox () : unit = jsNative
            [<Import("registerMetroToggleSwitch", Package)>]
            let toggleSwitch () : unit = jsNative

            // Layout
            [<Import("registerMetroCanvas", Package)>]
            let canvas () : unit = jsNative
            [<Import("registerMetroGrid", Package)>]
            let grid () : unit = jsNative
            [<Import("registerMetroScrollViewer", Package)>]
            let scrollViewer () : unit = jsNative
            [<Import("registerMetroStackPanel", Package)>]
            let stackPanel () : unit = jsNative
            [<Import("registerMetroTileGrid", Package)>]
            let tileGrid () : unit = jsNative
            [<Import("registerMetroVariableSizedWrapGrid", Package)>]
            let variableSizedWrapGrid () : unit = jsNative
            [<Import("registerMetroViewbox", Package)>]
            let viewbox () : unit = jsNative
            [<Import("registerMetroWrapPanel", Package)>]
            let wrapPanel () : unit = jsNative

            // Navigation
            [<Import("registerMetroAppBar", Package)>]
            let appBar () : unit = jsNative
            [<Import("registerMetroAppBarButton", Package)>]
            let appBarButton () : unit = jsNative
            [<Import("registerMetroAppBarSeparator", Package)>]
            let appBarSeparator () : unit = jsNative
            [<Import("registerMetroAppBarToggleButton", Package)>]
            let appBarToggleButton () : unit = jsNative
            [<Import("registerMetroBreadcrumbBar", Package)>]
            let breadcrumbBar () : unit = jsNative
            [<Import("registerMetroBreadcrumbItem", Package)>]
            let breadcrumbItem () : unit = jsNative
            [<Import("registerMetroHub", Package)>]
            let hub () : unit = jsNative
            [<Import("registerMetroHubSection", Package)>]
            let hubSection () : unit = jsNative
            [<Import("registerMetroPanorama", Package)>]
            let panorama () : unit = jsNative
            [<Import("registerMetroPanoramaItem", Package)>]
            let panoramaItem () : unit = jsNative
            [<Import("registerMetroPivot", Package)>]
            let pivot () : unit = jsNative
            [<Import("registerMetroPivotItem", Package)>]
            let pivotItem () : unit = jsNative
            [<Import("registerMetroSplitView", Package)>]
            let splitView () : unit = jsNative
            [<Import("registerMetroTabView", Package)>]
            let tabView () : unit = jsNative
            [<Import("registerMetroTabViewItem", Package)>]
            let tabViewItem () : unit = jsNative

            // Primitives
            [<Import("registerMetroBorder", Package)>]
            let border () : unit = jsNative
            [<Import("registerMetroContextMenu", Package)>]
            let contextMenu () : unit = jsNative
            [<Import("registerMetroExpander", Package)>]
            let expander () : unit = jsNative
            [<Import("registerMetroIcon", Package)>]
            let icon () : unit = jsNative
            [<Import("registerMetroImage", Package)>]
            let image () : unit = jsNative
            [<Import("registerMetroInfoBar", Package)>]
            let infoBar () : unit = jsNative
            [<Import("registerMetroMediaElement", Package)>]
            let mediaElement () : unit = jsNative
            [<Import("registerMetroMenuFlyout", Package)>]
            let menuFlyout () : unit = jsNative
            [<Import("registerMetroPersonPicture", Package)>]
            let personPicture () : unit = jsNative
            [<Import("registerMetroRichTextBlock", Package)>]
            let richTextBlock () : unit = jsNative
            [<Import("registerMetroTextBlock", Package)>]
            let textBlock () : unit = jsNative
            [<Import("registerMetroToast", Package)>]
            let toast () : unit = jsNative
            [<Import("registerMetroTooltip", Package)>]
            let tooltip () : unit = jsNative

            // Progress
            [<Import("registerMetroProgressBar", Package)>]
            let progressBar () : unit = jsNative
            [<Import("registerMetroProgressRing", Package)>]
            let progressRing () : unit = jsNative

            // Selection
            [<Import("registerMetroFlipView", Package)>]
            let flipView () : unit = jsNative
            [<Import("registerMetroGridView", Package)>]
            let gridView () : unit = jsNative
            [<Import("registerMetroListBox", Package)>]
            let listBox () : unit = jsNative
            [<Import("registerMetroListPicker", Package)>]
            let listPicker () : unit = jsNative
            [<Import("registerMetroListView", Package)>]
            let listView () : unit = jsNative
            [<Import("registerMetroLongListSelector", Package)>]
            let longListSelector () : unit = jsNative
            [<Import("registerMetroSemanticZoom", Package)>]
            let semanticZoom () : unit = jsNative
            [<Import("registerMetroTreeView", Package)>]
            let treeView () : unit = jsNative

            // Tiles
            [<Import("registerMetroCycleTile", Package)>]
            let cycleTile () : unit = jsNative
            [<Import("registerMetroFlipTile", Package)>]
            let flipTile () : unit = jsNative
            [<Import("registerMetroIconicTile", Package)>]
            let iconicTile () : unit = jsNative
            [<Import("registerMetroLiveTile", Package)>]
            let liveTile () : unit = jsNative
