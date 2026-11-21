namespace Fable.Lit.Dsl.Metrino

open Fable.Lit.Dsl

/// Property helpers for Metrino web components.
/// These use `prop` (JavaScript properties) because Metrino components are Lit elements
/// with reactive properties. Names ending in `'` avoid clashing with the core HTML DSL
/// helpers (which set attributes) and match the Shoelace DSL's naming.
[<AutoOpen>]
module MetrinoAttrs =

    // =========================================================================
    // Common state
    // =========================================================================

    let disabled' (isDisabled: bool) = prop "disabled" isDisabled
    let checked' (isChecked: bool) = prop "checked" isChecked
    let open' (isOpen: bool) = prop "open" isOpen
    let required' (isRequired: bool) = prop "required" isRequired
    let readonly' (isReadonly: bool) = prop "readonly" isReadonly
    let closable (isClosable: bool) = prop "closable" isClosable
    /// Expanded state (expander, app-bar).
    let expanded (isExpanded: bool) = prop "expanded" isExpanded
    /// On/off state of a `metroToggleSwitch`.
    let on' (isOn: bool) = prop "on" isOn
    let indeterminate (isIndeterminate: bool) = prop "indeterminate" isIndeterminate

    // =========================================================================
    // Common values
    // =========================================================================

    let value' (v: obj) = prop "value" v
    let label' (text: string) = prop "label" text
    let placeholder' (text: string) = prop "placeholder" text
    let name' (text: string) = prop "name" text
    /// Title / heading text (dialogs, hub, panorama, expander, info-bar, tiles, ...).
    let title' (text: string) = prop "title" text
    /// Header text (pivot-item, hub-section, panorama-item, tab-view-item, breadcrumb-item).
    let header' (text: string) = prop "header" text
    let subtitle (text: string) = prop "subtitle" text
    let href' (url: string) = prop "href" url
    /// Link target (hyperlink-button) or CSS selector of the target element (teaching-tip, context-menu).
    let target' (value: string) = prop "target" value
    let src' (url: string) = prop "src" url
    let alt' (text: string) = prop "alt" text
    let content' (text: string) = prop "content" text
    /// Tooltip text.
    let text' (text: string) = prop "text" text
    let min' (value: obj) = prop "min" value
    let max' (value: obj) = prop "max" value
    let step' (value: obj) = prop "step" value

    /// Places the element in a named slot of its parent.
    let slot' (name: string) = attr "slot" name

    // =========================================================================
    // Buttons
    // =========================================================================

    /// Uses the Metro accent color for a `metroButton` / `metroRepeatButton`.
    let accent = boolAttr "accent" true

    /// Button type: "submit" (default, like native buttons), "reset" or "button".
    let buttonType (value: string) = prop "type" value
    /// A button that performs no form action.
    let buttonTypeButton = prop "type" "button"
    let buttonTypeSubmit = prop "type" "submit"
    let buttonTypeReset = prop "type" "reset"

    // =========================================================================
    // Icons & sizes
    // =========================================================================

    /// Icon name (e.g. "home", "settings", "add", "mail").
    let icon (name: string) = prop "icon" name

    /// Generic size property. Values vary by component:
    /// icon: small | normal | medium | large | xlarge;
    /// tiles: small | medium | wide | large;
    /// progress-ring / person-picture: small | normal | large (| xlarge).
    let size (value: string) = prop "size" value
    let sizeSmall = prop "size" "small"
    let sizeNormal = prop "size" "normal"
    let sizeMedium = prop "size" "medium"
    let sizeWide = prop "size" "wide"
    let sizeLarge = prop "size" "large"
    let sizeXLarge = prop "size" "xlarge"

    // =========================================================================
    // Placement
    // =========================================================================

    /// Placement: "top" | "bottom" | "left" | "right" (flyout, tooltip, teaching-tip),
    /// "top" | "bottom" (dropdown-button, app-bar).
    let placement (value: string) = prop "placement" value
    let placementTop = prop "placement" "top"
    let placementBottom = prop "placement" "bottom"
    let placementLeft = prop "placement" "left"
    let placementRight = prop "placement" "right"

    // =========================================================================
    // Timing
    // =========================================================================

    /// Delay in milliseconds (repeat-button, context-menu).
    let delay (ms: int) = prop "delay" ms
    /// Interval in milliseconds (repeat-button, flip-view, cycle-tile, live-tile).
    let interval (ms: int) = prop "interval" ms

    // =========================================================================
    // Date & time
    // =========================================================================

    /// Minimum date (ISO "yyyy-MM-dd").
    let minDate (value: string) = prop "minDate" value
    /// Maximum date (ISO "yyyy-MM-dd").
    let maxDate (value: string) = prop "maxDate" value
    let selectedDate (value: string) = prop "selectedDate" value
    let displayDate (value: string) = prop "displayDate" value
    /// First day of the week (0 = Sunday).
    let firstDayOfWeek (day: int) = prop "firstDayOfWeek" day
    let minYear (year: int) = prop "minYear" year
    let maxYear (year: int) = prop "maxYear" year
    /// "12" or "24".
    let hourFormat (value: string) = prop "hourFormat" value
    let dateFormat (value: string) = prop "format" value

    // =========================================================================
    // Input
    // =========================================================================

    /// Shows the password in plain text (password-box).
    let revealed (isRevealed: bool) = prop "revealed" isRevealed
    /// Current query text (auto-suggest-box).
    let query (text: string) = prop "query" text

    // =========================================================================
    // Layout
    // =========================================================================

    /// "horizontal" | "vertical" (stack-panel, wrap-panel, variable-sized-wrap-grid).
    let orientation (value: string) = prop "orientation" value
    let orientationHorizontal = prop "orientation" "horizontal"
    let orientationVertical = prop "orientation" "vertical"
    /// CSS grid-template-rows for `metroGrid` (e.g. "auto 1fr").
    let gridRows (value: string) = prop "rows" value
    /// CSS grid-template-columns for `metroGrid` (e.g. "200px 1fr").
    let gridColumns (value: string) = prop "columns" value
    /// Number of columns (tile-grid, grid-view).
    let columns (count: int) = prop "columns" count
    /// "horizontal" | "vertical" | "both".
    let scrollOrientation (value: string) = prop "scrollOrientation" value
    /// "auto" | "visible" | "hidden".
    let scrollbarMode (value: string) = prop "scrollbarMode" value
    let touchPhysics (enabled: bool) = prop "touchPhysics" enabled
    let itemWidth (px: int) = prop "itemWidth" px
    let itemHeight (px: int) = prop "itemHeight" px
    let maximumRowsOrColumns (count: int) = prop "maximumRowsOrColumns" count
    /// "none" | "fill" | "uniform" | "uniformToFill" (viewbox, image).
    let stretch (value: string) = prop "stretch" value
    /// "upOnly" | "downOnly" | "both".
    let stretchDirection (value: string) = prop "stretchDirection" value

    // =========================================================================
    // Navigation
    // =========================================================================

    let selectedIndex (index: int) = prop "selectedIndex" index
    /// Snap scrolling to sections (hub).
    let snap (enabled: bool) = prop "snap" enabled
    /// Enables semantic zoom on the hub.
    let zoomable (enabled: bool) = prop "zoomable" enabled
    let backgroundImage (url: string) = prop "backgroundImage" url
    /// Wrap around at the ends (panorama) / wrap text (text-block).
    let wrap (enabled: bool) = prop "wrap" enabled
    /// "overlay" | "inline" | "compact" (split-view).
    let displayMode (value: string) = prop "displayMode" value
    /// "left" | "right" (split-view).
    let panePlacement (value: string) = prop "panePlacement" value
    let showAddButton (show: bool) = prop "showAddButton" show
    /// Shows the app-bar toggle button as a menu item.
    let menuItem (isMenuItem: bool) = prop "menuItem" isMenuItem
    let visible (isVisible: bool) = prop "visible" isVisible
    let collapsedCount (count: int) = prop "collapsedCount" count

    // =========================================================================
    // Dialogs
    // =========================================================================

    /// "narrow" | "wide" (settings-flyout).
    let flyoutWidth (value: string) = prop "width" value

    // =========================================================================
    // Primitives
    // =========================================================================

    let borderThickness (value: string) = prop "borderThickness" value
    let borderColor (value: string) = prop "borderColor" value
    let background (value: string) = prop "background" value
    let cornerRadius (px: int) = prop "cornerRadius" px
    let padding (value: string) = prop "padding" value
    /// "informational" | "success" | "warning" | "error" (info-bar).
    let severity (value: string) = prop "severity" value
    let severityInformational = prop "severity" "informational"
    let severitySuccess = prop "severity" "success"
    let severityWarning = prop "severity" "warning"
    let severityError = prop "severity" "error"
    /// Image placeholder URL.
    let imagePlaceholder (url: string) = prop "placeholder" url
    /// Image fallback URL when loading fails.
    let fallback (url: string) = prop "fallback" url
    let displayName (name: string) = prop "displayName" name
    let initials (text: string) = prop "initials" text
    /// "available" | "away" | "busy" | "offline" (person-picture).
    let presence (value: string) = prop "presence" value
    let textTrimming (value: string) = prop "textTrimming" value
    let maxLines (count: int) = prop "maxLines" count
    let bold (isBold: bool) = prop "bold" isBold
    let italic (isItalic: bool) = prop "italic" isItalic
    let underline (isUnderline: bool) = prop "underline" isUnderline
    let strikethrough (isStrikethrough: bool) = prop "strikethrough" isStrikethrough

    // Media element
    /// "audio" | "video".
    let mediaType (value: string) = prop "type" value
    let autoplay' (enabled: bool) = prop "autoplay" enabled
    let controls' (enabled: bool) = prop "controls" enabled
    let muted' (enabled: bool) = prop "muted" enabled
    let loop' (enabled: bool) = prop "loop" enabled
    let poster (url: string) = prop "poster" url

    // =========================================================================
    // Progress
    // =========================================================================

    let maximum (value: float) = prop "maximum" value
    let showLabel (show: bool) = prop "showLabel" show

    // =========================================================================
    // Selection
    // =========================================================================

    /// Data items (list-view, grid-view, flip-view, list-picker, long-list-selector, tree-view).
    let items (values: obj seq) = prop "items" (Array.ofSeq values)
    /// Current index (flip-view).
    let index (i: int) = prop "index" i
    let showNav (show: bool) = prop "showNav" show
    let showIndicators (show: bool) = prop "showIndicators" show
    /// "none" | "single" | "multiple" | "extended" (support varies by component).
    let selectionMode (value: string) = prop "selectionMode" value
    let selectionModeNone = prop "selectionMode" "none"
    let selectionModeSingle = prop "selectionMode" "single"
    let selectionModeMultiple = prop "selectionMode" "multiple"
    let selectionModeExtended = prop "selectionMode" "extended"
    /// Item property used to group items.
    let groupKey (key: string) = prop "groupKey" key
    /// Item property used as the display text.
    let displayMember (key: string) = prop "displayMember" key
    /// Item property used as the value.
    let valueMember (key: string) = prop "valueMember" key
    let selectedValue (value: obj) = prop "selectedValue" value
    let groupHeaderHeight (px: int) = prop "groupHeaderHeight" px
    let maxHeight (value: string) = prop "maxHeight" value
    let showJumpList (show: bool) = prop "showJumpList" show
    let jumpGrid (enabled: bool) = prop "jumpGrid" enabled
    /// Selected item id (tree-view).
    let selectedId (id: string) = prop "selected" id
    /// "in" | "out" (semantic-zoom).
    let zoomed (value: string) = prop "zoomed" value
    let transitionDuration (ms: int) = prop "transitionDuration" ms

    // =========================================================================
    // Tiles
    // =========================================================================

    let flipped (isFlipped: bool) = prop "flipped" isFlipped
    let count (value: int) = prop "count" value
    let badge (text: string) = prop "badge" text
