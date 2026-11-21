namespace Fable.Lit.Dsl.Metrino

open Browser.Types

open Fable.Lit.Dsl

/// Event helpers for Metrino web components.
/// Metrino dispatches plain (unprefixed) `CustomEvent`s; read their payload
/// with `e.detail` or the `detail` helper, e.g. `detail<{| checked: bool |}> e`.
[<AutoOpen>]
module MetrinoEvents =

    /// Reads the typed `detail` payload of a Metrino `CustomEvent`.
    let inline detail<'T> (e: CustomEvent) : 'T = unbox<'T> e.detail

    let private custom (name: string) (handler: CustomEvent -> unit) : Attr = Attr.Event(name, handler)

    // =========================================================================
    // Value changes
    // =========================================================================

    /// `change` as a `CustomEvent` (inputs, pickers, sliders, check-box, toggle-switch, flip-view, list-picker...).
    /// Detail examples: text-box `{ value }`, check-box `{ checked }`.
    let onMetroChange (handler: CustomEvent -> unit) : Attr = custom "change" handler

    /// `input` as a `CustomEvent` (text-box, password-box, number-box). Detail: `{ value }`.
    let onMetroInput (handler: CustomEvent -> unit) : Attr = custom "input" handler

    /// `selectionchanged` (combo-box, list-box, pivot, hub, tab-view).
    /// combo-box detail: `{ selectedValue; selectedIndex }`; pivot: `{ selectedIndex }`.
    let onSelectionChanged (handler: CustomEvent -> unit) : Attr = custom "selectionchanged" handler

    /// `selectionchange` (list-view, grid-view, long-list-selector, tree-view).
    let onSelectionChange (handler: CustomEvent -> unit) : Attr = custom "selectionchange" handler

    /// `textchanged` (auto-suggest-box).
    let onTextChanged (handler: CustomEvent -> unit) : Attr = custom "textchanged" handler

    /// `suggestionchosen` (auto-suggest-box).
    let onSuggestionChosen (handler: CustomEvent -> unit) : Attr = custom "suggestionchosen" handler

    /// `dateselected` (calendar).
    let onDateSelected (handler: CustomEvent -> unit) : Attr = custom "dateselected" handler

    /// `displaymonthchanged` (calendar).
    let onDisplayMonthChanged (handler: CustomEvent -> unit) : Attr = custom "displaymonthchanged" handler

    // =========================================================================
    // Show / hide
    // =========================================================================

    /// `show` (dropdown-button, dialogs, flyout, context-menu, menu-flyout).
    let onShow (handler: CustomEvent -> unit) : Attr = custom "show" handler

    /// `hide` (dropdown-button, context-menu).
    let onHide (handler: CustomEvent -> unit) : Attr = custom "hide" handler

    /// `open` (settings-flyout, list-picker).
    let onOpen (handler: CustomEvent -> unit) : Attr = custom "open" handler

    /// `close` (dialogs, flyout, settings-flyout, menu-flyout, info-bar, list-picker).
    let onClose (handler: CustomEvent -> unit) : Attr = custom "close" handler

    /// `opened` (teaching-tip).
    let onOpened (handler: CustomEvent -> unit) : Attr = custom "opened" handler

    /// `closed` (teaching-tip).
    let onClosed (handler: CustomEvent -> unit) : Attr = custom "closed" handler

    /// `expanded` (expander, app-bar).
    let onExpanded (handler: CustomEvent -> unit) : Attr = custom "expanded" handler

    /// `collapsed` (app-bar).
    let onCollapsed (handler: CustomEvent -> unit) : Attr = custom "collapsed" handler

    /// `expand` (tree-view).
    let onExpand (handler: CustomEvent -> unit) : Attr = custom "expand" handler

    /// `collapse` (tree-view).
    let onCollapse (handler: CustomEvent -> unit) : Attr = custom "collapse" handler

    /// `paneopened` (split-view).
    let onPaneOpened (handler: CustomEvent -> unit) : Attr = custom "paneopened" handler

    /// `paneclosed` (split-view).
    let onPaneClosed (handler: CustomEvent -> unit) : Attr = custom "paneclosed" handler

    // =========================================================================
    // Items
    // =========================================================================

    /// `itemclick` (context-menu, list-view, grid-view, flip-view, long-list-selector).
    let onItemClick (handler: CustomEvent -> unit) : Attr = custom "itemclick" handler

    /// `iteminvoke` (list-view, grid-view).
    let onItemInvoke (handler: CustomEvent -> unit) : Attr = custom "iteminvoke" handler

    /// `itemclicked` (breadcrumb-bar).
    let onItemClicked (handler: CustomEvent -> unit) : Attr = custom "itemclicked" handler

    /// `tabclosed` (tab-view).
    let onTabClosed (handler: CustomEvent -> unit) : Attr = custom "tabclosed" handler

    /// `addbuttonclick` (tab-view).
    let onAddButtonClick (handler: CustomEvent -> unit) : Attr = custom "addbuttonclick" handler

    /// `groupchanged` (semantic-zoom).
    let onGroupChanged (handler: CustomEvent -> unit) : Attr = custom "groupchanged" handler

    /// `zoomchanged` (semantic-zoom).
    let onZoomChanged (handler: CustomEvent -> unit) : Attr = custom "zoomchanged" handler

    /// `flipped` (flip-tile).
    let onFlipped (handler: CustomEvent -> unit) : Attr = custom "flipped" handler

    // =========================================================================
    // Toast
    // =========================================================================

    /// `toastshown` (metro-toast).
    let onToastShown (handler: CustomEvent -> unit) : Attr = custom "toastshown" handler

    /// `toasthidden` (metro-toast).
    let onToastHidden (handler: CustomEvent -> unit) : Attr = custom "toasthidden" handler

    // =========================================================================
    // Media
    // =========================================================================

    /// `play` (media-element).
    let onPlay (handler: CustomEvent -> unit) : Attr = custom "play" handler

    /// `pause` (media-element).
    let onPause (handler: CustomEvent -> unit) : Attr = custom "pause" handler

    /// `ended` (media-element).
    let onEnded (handler: CustomEvent -> unit) : Attr = custom "ended" handler

    /// `timeupdate` (media-element).
    let onTimeUpdate (handler: CustomEvent -> unit) : Attr = custom "timeupdate" handler

    /// `volumechange` (media-element).
    let onVolumeChange (handler: CustomEvent -> unit) : Attr = custom "volumechange" handler

    /// `load` (image).
    let onLoad (handler: Event -> unit) : Attr = Attr.Event("load", handler)

    /// `error` (image).
    let onError (handler: Event -> unit) : Attr = Attr.Event("error", handler)
