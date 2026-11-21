namespace Fable.Lit.Dsl.Metrino

open Fable.Core
open Fable.Core.JsInterop
open Fable.Lit.Dsl

/// A reference to a rendered Metrino element, for calling its methods imperatively
/// (`show`, `hide`, `setOptions`, `scrollToIndex`, ...).
/// MetroRef is a class (reference type), so it persists across renders when created
/// once per component instance (e.g. with `Hook.useMemo` or at the top of a `HookComponent`).
type MetroRef() =
    member val Element: obj option = None with get, set

/// Functions for working with `MetroRef`s.
///
/// Usage:
///   let dialog = MetroRef.create ()
///
///   metroContentDialog {
///       MetroRef.bind dialog
///       title' "Hello"
///       "Dialog content"
///   }
///
///   metroButton {
///       onClick (fun _ -> MetroRef.show dialog)
///       "Open"
///   }
module MetroRef =

    [<Emit("$0[$1](...$2)")>]
    let private callMethod (el: obj) (methodName: string) (args: obj array) : obj = jsNative

    /// Creates a new element reference.
    let create () = MetroRef()

    /// Binds a Metrino element to a MetroRef.
    /// Ignores null/undefined values that Lit may pass when clearing the part.
    let bind (r: MetroRef) =
        bindRef (fun el ->
            if not (isNullOrUndefined el) then
                r.Element <- Some el
        )

    /// Calls any method on the bound element (no-op if unbound) and returns its result.
    let invoke (methodName: string) (args: obj array) (r: MetroRef) : obj option =
        r.Element |> Option.map (fun el -> callMethod el methodName args)

    let private run methodName args r = invoke methodName args r |> ignore

    /// Calls `show()` (dialogs, settings-flyout, dropdown-button, split-view, list-picker).
    let show (r: MetroRef) = run "show" [||] r

    /// Calls `show(target)` to open anchored to an element (flyout, teaching-tip, tooltip, menu-flyout).
    let showAt (target: Browser.Types.Element) (r: MetroRef) = run "show" [| box target |] r

    /// Calls `hide()`.
    let hide (r: MetroRef) = run "hide" [||] r

    /// Calls `toggle()` (split-view).
    let toggle (r: MetroRef) = run "toggle" [||] r

    /// Sets the options of a `metroComboBox`.
    let setOptions (options: string seq) (r: MetroRef) = run "setOptions" [| box (Array.ofSeq options) |] r

    /// Sets the suggestions of a `metroAutoSuggestBox`.
    let setSuggestions (suggestions: string seq) (r: MetroRef) = run "setSuggestions" [| box (Array.ofSeq suggestions) |] r

    /// Sets the items of a `metroLiveTile` or `metroLongListSelector`.
    let setItems (items: obj seq) (r: MetroRef) = run "setItems" [| box (Array.ofSeq items) |] r

    /// Scrolls to an item index (list-view, grid-view, long-list-selector).
    let scrollToIndex (index: int) (r: MetroRef) = run "scrollToIndex" [| box index |] r

    /// Clears the selection (list-box, list-view, grid-view, long-list-selector).
    let clearSelection (r: MetroRef) = run "clearSelection" [||] r

    /// Plays media (media-element).
    let play (r: MetroRef) = run "play" [||] r

    /// Pauses media (media-element).
    let pause (r: MetroRef) = run "pause" [||] r

/// Toast severity levels.
[<StringEnum>]
type ToastSeverity =
    | Informational
    | Success
    | Warning
    | Error

[<AllowNullLiteral>]
type private IToastHost =
    abstract show: options: obj -> string
    abstract hide: id: string -> unit
    abstract clearAll: unit -> unit
    abstract dispose: unit -> unit

/// Manages global toast notifications (wraps Metrino's `ToastHost`).
/// The `<metro-toast>` host element is created and registered lazily on the first `Show`.
///
/// Usage:
///   let toasts = ToastHost()
///   toasts.Show("Your changes are safe", title = "Saved", severity = ToastSeverity.Success) |> ignore
type ToastHost() =
    let host: IToastHost = createNew (import "ToastHost" Metrino.Package) () |> unbox

    /// Shows a toast and returns its id. `durationMs` = 0 keeps it until dismissed.
    member _.Show(message: string, ?title: string, ?severity: ToastSeverity, ?durationMs: int) : string =
        let options = createEmpty<obj>
        options?message <- message
        title |> Option.iter (fun v -> options?title <- v)
        severity |> Option.iter (fun v -> options?severity <- v)
        durationMs |> Option.iter (fun v -> options?duration <- v)
        host.show options

    /// Dismisses one toast by id.
    member _.Hide(id: string) = host.hide id

    /// Dismisses every visible toast.
    member _.ClearAll() = host.clearAll ()

    /// Removes the host element; the next `Show` recreates it.
    member _.Dispose() = host.dispose ()

    interface System.IDisposable with
        member this.Dispose() = this.Dispose()
