namespace Fable.Lit.Dsl.Metrino

open Fable.Lit.Dsl

/// Element helpers for Metrino (Windows Phone / Windows 8 Metro) web components.
/// These are thin wrappers over the core DSL's ElementBuilder.
[<AutoOpen>]
module MetrinoElements =

    // Buttons
    /// Standard push button. Use `accent` for the accent-colored primary variant.
    let metroButton = ElementBuilder("metro-button")
    /// Button that reveals a dropdown menu.
    let metroDropdownButton = ElementBuilder("metro-dropdown-button")
    /// Link-styled navigation button.
    let metroHyperlinkButton = ElementBuilder("metro-hyperlink-button")
    /// Button that fires `click` repeatedly while held.
    let metroRepeatButton = ElementBuilder("metro-repeat-button")

    // Date & time
    /// Month view calendar display.
    let metroCalendar = ElementBuilder("metro-calendar")
    /// Text field with a drop-down calendar.
    let metroCalendarDatePicker = ElementBuilder("metro-calendar-date-picker")
    /// Date selection.
    let metroDatePicker = ElementBuilder("metro-date-picker")
    /// Roller-style (Windows Phone) date picker.
    let metroDatePickerRoller = ElementBuilder("metro-date-picker-roller")
    /// Time selection.
    let metroTimePicker = ElementBuilder("metro-time-picker")
    /// Roller-style (Windows Phone) time picker.
    let metroTimePickerRoller = ElementBuilder("metro-time-picker-roller")

    // Dialogs
    /// Modal dialog with custom content. Put buttons in the `buttons` slot.
    let metroContentDialog = ElementBuilder("metro-content-dialog")
    /// Contextual popup anchored to a target element.
    let metroFlyout = ElementBuilder("metro-flyout")
    /// Alert / confirmation dialog. Put buttons in the `buttons` slot.
    let metroMessageDialog = ElementBuilder("metro-message-dialog")
    /// Settings panel that slides in from the edge.
    let metroSettingsFlyout = ElementBuilder("metro-settings-flyout")
    /// Teaching tip callout anchored to a target. Put actions in the `action` slot.
    let metroTeachingTip = ElementBuilder("metro-teaching-tip")

    // Input
    /// Autocomplete input. Supply suggestions with `MetroRef.setSuggestions`.
    let metroAutoSuggestBox = ElementBuilder("metro-auto-suggest-box")
    /// Checkbox control.
    let metroCheckBox = ElementBuilder("metro-check-box")
    /// Dropdown selection. Supply options with `MetroRef.setOptions`.
    let metroComboBox = ElementBuilder("metro-combo-box")
    /// Numeric input with spinners.
    let metroNumberBox = ElementBuilder("metro-number-box")
    /// Password input with reveal toggle.
    let metroPasswordBox = ElementBuilder("metro-password-box")
    /// Radio button for mutually exclusive choices (grouped by `name'`).
    let metroRadioButton = ElementBuilder("metro-radio-button")
    /// Star rating control.
    let metroRating = ElementBuilder("metro-rating")
    /// Rich text editor.
    let metroRichEditBox = ElementBuilder("metro-rich-edit-box")
    /// Range value selector.
    let metroSlider = ElementBuilder("metro-slider")
    /// Single-line text input.
    let metroTextBox = ElementBuilder("metro-text-box")
    /// On/off sliding switch (state is set with `on'`).
    let metroToggleSwitch = ElementBuilder("metro-toggle-switch")

    // Layout
    /// Absolute positioning container.
    let metroCanvas = ElementBuilder("metro-canvas")
    /// CSS Grid container (`gridRows` / `gridColumns`).
    let metroGrid = ElementBuilder("metro-grid")
    /// Scrollable container with touch physics.
    let metroScrollViewer = ElementBuilder("metro-scroll-viewer")
    /// Vertical / horizontal flexbox stack.
    let metroStackPanel = ElementBuilder("metro-stack-panel")
    /// Responsive tile layout.
    let metroTileGrid = ElementBuilder("metro-tile-grid")
    /// Mixed-size flow layout.
    let metroVariableSizedWrapGrid = ElementBuilder("metro-variable-sized-wrap-grid")
    /// Scalable content container.
    let metroViewbox = ElementBuilder("metro-viewbox")
    /// Flowing wrap layout.
    let metroWrapPanel = ElementBuilder("metro-wrap-panel")

    // Navigation
    /// Command bar. Slots: default (primary commands), `content`, `menu` (secondary commands).
    let metroAppBar = ElementBuilder("metro-app-bar")
    /// Circular icon button for an app bar.
    let metroAppBarButton = ElementBuilder("metro-app-bar-button")
    /// Visual divider for an app bar.
    let metroAppBarSeparator = ElementBuilder("metro-app-bar-separator")
    /// Checkable app bar command.
    let metroAppBarToggleButton = ElementBuilder("metro-app-bar-toggle-button")
    /// Breadcrumb navigation bar.
    let metroBreadcrumbBar = ElementBuilder("metro-breadcrumb-bar")
    /// Item within a breadcrumb bar.
    let metroBreadcrumbItem = ElementBuilder("metro-breadcrumb-item")
    /// Horizontal section grouping.
    let metroHub = ElementBuilder("metro-hub")
    /// Hub content section.
    let metroHubSection = ElementBuilder("metro-hub-section")
    /// Full-screen horizontal scrolling view.
    let metroPanorama = ElementBuilder("metro-panorama")
    /// Panorama panel.
    let metroPanoramaItem = ElementBuilder("metro-panorama-item")
    /// Tab-based navigation.
    let metroPivot = ElementBuilder("metro-pivot")
    /// Pivot tab content.
    let metroPivotItem = ElementBuilder("metro-pivot-item")
    /// Collapsible sidebar layout. Put the sidebar in the `pane` slot.
    let metroSplitView = ElementBuilder("metro-split-view")
    /// Tabbed document view.
    let metroTabView = ElementBuilder("metro-tab-view")
    /// Tab within a tab view. Optional `icon` slot.
    let metroTabViewItem = ElementBuilder("metro-tab-view-item")

    // Primitives
    /// Styled container.
    let metroBorder = ElementBuilder("metro-border")
    /// Right-click menu. Put items in the `item` slot.
    let metroContextMenu = ElementBuilder("metro-context-menu")
    /// Collapsible section. Optional `header` slot.
    let metroExpander = ElementBuilder("metro-expander")
    /// Material Design icon by name (e.g. "home", "settings", "add").
    let metroIcon = ElementBuilder("metro-icon")
    /// Image display with placeholder / fallback.
    let metroImage = ElementBuilder("metro-image")
    /// Informational banner.
    let metroInfoBar = ElementBuilder("metro-info-bar")
    /// Audio / video player.
    let metroMediaElement = ElementBuilder("metro-media-element")
    /// Popup menu of commands.
    let metroMenuFlyout = ElementBuilder("metro-menu-flyout")
    /// Contact avatar.
    let metroPersonPicture = ElementBuilder("metro-person-picture")
    /// Formatted text block.
    let metroRichTextBlock = ElementBuilder("metro-rich-text-block")
    /// Typography element.
    let metroTextBlock = ElementBuilder("metro-text-block")
    /// Toast host element. Usually created for you by `ToastHost`.
    let metroToast = ElementBuilder("metro-toast")
    /// Hover information.
    let metroTooltip = ElementBuilder("metro-tooltip")

    // Progress
    /// Determinate / indeterminate linear progress.
    let metroProgressBar = ElementBuilder("metro-progress-bar")
    /// Indeterminate circular spinner.
    let metroProgressRing = ElementBuilder("metro-progress-ring")

    // Selection
    /// Swipeable carousel.
    let metroFlipView = ElementBuilder("metro-flip-view")
    /// Virtualized tiled grid (data supplied with `items`).
    let metroGridView = ElementBuilder("metro-grid-view")
    /// Selectable item list. Children with `data-value` are the items.
    let metroListBox = ElementBuilder("metro-list-box")
    /// Modal selection dialog.
    let metroListPicker = ElementBuilder("metro-list-picker")
    /// Virtualized list with gestures (data supplied with `items`).
    let metroListView = ElementBuilder("metro-list-view")
    /// Virtualized grouped list with jump grid.
    let metroLongListSelector = ElementBuilder("metro-long-list-selector")
    /// Zoom between overview and detail views (`zoomed-in` / `zoomed-out` slots).
    let metroSemanticZoom = ElementBuilder("metro-semantic-zoom")
    /// Hierarchical expandable list.
    let metroTreeView = ElementBuilder("metro-tree-view")

    // Tiles
    /// Tile that cycles through content (`front` / `cycle` slots).
    let metroCycleTile = ElementBuilder("metro-cycle-tile")
    /// Tile with a 3D flip (`front` / `back` slots).
    let metroFlipTile = ElementBuilder("metro-flip-tile")
    /// Icon tile with a counter.
    let metroIconicTile = ElementBuilder("metro-iconic-tile")
    /// Tile with animated content updates.
    let metroLiveTile = ElementBuilder("metro-live-tile")
