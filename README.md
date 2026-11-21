# Fable.Lit.Dsl
[![Fable.Lit.Dsl](https://img.shields.io/nuget/v/Fable.Lit.Dsl.svg?label=Fable.Lit.Dsl)](https://www.nuget.org/packages/Fable.Lit.Dsl/)
[![Fable.Lit.Dsl.Shoelace](https://img.shields.io/nuget/v/Fable.Lit.Dsl.Shoelace.svg?label=Fable.Lit.Dsl.Shoelace)](https://www.nuget.org/packages/Fable.Lit.Dsl.Shoelace/)
[![Fable.Lit.Dsl.Metrino](https://img.shields.io/nuget/v/Fable.Lit.Dsl.Metrino.svg?label=Fable.Lit.Dsl.Metrino)](https://www.nuget.org/packages/Fable.Lit.Dsl.Metrino/)

A collection of expressive, type-safe DSLs for building UI with **Fable.Lit**.
This repo currently includes:

- **Fable.Lit.Dsl** - a clean, idiomatic way to write Lit templates in F#
- **Fable.Lit.Dsl.Shoelace** - typed components, attributes, and events for the Shoelace Web Component library
- **Fable.Lit.Dsl.Metrino** - typed components, properties, and events for [Metrino](https://github.com/AngelMunoz/metrino), a Windows Phone / Windows 8 Metro design system

More DSLs may be added over time.

### Related Projects
- **Fable.Lit** - core F# bindings for Lit: https://github.com/fable-hub/Fable.Lit
- **fable-lit-template** - Fable.Lit + Giraffe: https://github.com/JordanMarr/fable-lit-fullstack-template

---

## Installation

Add the packages to your project:

```bash
dotnet add package Fable.Lit.Dsl
dotnet add package Fable.Lit.Dsl.Shoelace   # optional
dotnet add package Fable.Lit.Dsl.Metrino    # optional
```

If using Shoelace, register its assets at app startup:

```fsharp
open Fable.Core.JsInterop
open Fable.Lit.Dsl.Shoelace

// Set the base path for Shoelace assets (icons, etc.)
Shoelace.setBasePath()

// Import the components you need
Shoelace.startImports [|
    importDynamic Shoelace.Asset.Button
    importDynamic Shoelace.Asset.Input
    importDynamic Shoelace.Asset.Dialog
    // ... add more as needed
|]
```

---

# HTML DSL

The HTML DSL provides a natural, structured way to write Lit templates in F# without stringly-typed markup.

### Example

```fsharp
open Fable.Lit.Dsl

view {
    h1 { "Hello, world!" }

    p { "This is the Fable.Lit HTML DSL." }

    button {
        disabled false
        onClick (fun _ -> dispatch Increment)
        "Click me"
    }
}
```

### Builders

- `view { }` - Use at the top level of components. Returns a `TemplateResult` for rendering.
- `template { }` - Use for nested fragments inside elements. Returns a `Node`.
- `el "tag-name" { }` - Create custom elements with any tag name.

### Custom Elements with `el`

Use `el` for one-off custom elements or web components:

```fsharp
view {
    el "my-custom-element" {
        attr "theme" "dark"
        prop "config" {| rows = 10; cols = 5 |}
        boolAttr "enabled" true
        on "custom-event" (fun e -> dispatch (CustomEvent e))
        "Child content"
    }
}
```

Available attribute helpers:
- `attr "name" value` - String attribute
- `boolAttr "name" true` - Boolean attribute (present when true, absent when false)
- `prop "name" value` - JavaScript property (for complex values or web component properties)
- `on "event-name" handler` - Event handler

### Fragments with `template`

Use `template` when you need to return multiple sibling elements *without* a wrapper element. This is similar to React fragments (`<>...</>`).

```fsharp
/// Returns multiple elements without a wrapper div
let userInfo (user: User) =
    template {
        dt { "Name" }
        dd { user.Name }
        dt { "Email" }
        dd { user.Email }
    }

let mainView model =
    view {
        h1 { "User Details" }
        dl {
            // Inserts dt/dd pairs directly into the dl, no wrapper element
            userInfo model.User
        }
    }
```

In most cases, wrapping content in a `div` is fine. Use `template` only when an extra wrapper element would break your HTML structure or CSS styling (like inside `<dl>`, `<table>`, `<ul>`, or flex/grid containers where extra elements affect layout).

### Highlights

- Strongly-typed attributes and events
- Natural F# computation expression syntax
- No raw HTML strings
- Works seamlessly with Lit components and custom elements

---

# Shoelace DSL

Typed, ergonomic bindings for the Shoelace Web Component library.

### Example

```fsharp
open Fable.Lit.Dsl
open Fable.Lit.Dsl.Shoelace

[<HookComponent>]
let Page() =
    let dialog = Dialog.createRef()

    view {
        slButton {
            variantPrimary
            onClick (fun _ -> Dialog.show dialog)
            slIcon { slot' "prefix"; iconName "box-arrow-up-right" }
            "Open Dialog"
        }
    
        slDialog {
            Dialog.bind dialog
            label' "Confirmation"

            p { "Are you sure you want to proceed with this action?" }

            div {
                slot' "footer"
                style "display: flex; gap: 10px; justify-content: flex-end;"

                slButton {
                    variantDefault
                    onClick (fun _ -> Dialog.hide dialog)
                    "Cancel"
                }
                slButton {
                    variantPrimary
                    onClick (fun _ ->
                        setConfirmCount (confirmCount + 1)
                        Dialog.hide dialog
                    )
                    "Confirm"
                }
            }
        }
    }
```

### Highlights

- All Shoelace components supported (`slButton`, `slInput`, `slDialog`, `slDrawer`, etc.)
- Typed properties (`variant`, `size`, `disabled'`, `open'`, `label'`, etc.)
- Typed events (`onSlChange`, `onSlInput`, `onSlShow`, `onSlHide`, etc.)
- Works alongside the HTML DSL

### Common Shoelace Properties

```fsharp
// Variants
variantPrimary      // or: variant "primary"
variantSuccess
variantDanger
variantWarning
variantNeutral

// Sizes
sizeSmall           // or: size "small"
sizeMedium
sizeLarge

// States
disabled' true
loading true
open' true
checked' true
clearable true

// Values
value' "text"
label' "Label"
placeholder' "Placeholder"
helpText "Help text"
```

### Common Shoelace Events

```fsharp
onSlChange handler      // Value changed (after interaction)
onSlInput handler       // Real-time input
onSlShow handler        // Element starting to show
onSlAfterShow handler   // Element shown, animations complete
onSlHide handler        // Element starting to hide
onSlAfterHide handler   // Element hidden, animations complete
onSlRequestClose handler // Close requested (dialogs/drawers)
onSlSelect handler      // Menu item selected
```

---

# Metrino DSL

Typed bindings for [Metrino](https://github.com/AngelMunoz/metrino) by Angel D. Munoz:
Lit web components implementing the Windows Phone / Windows 8 **Metro** design system
(pivots, panoramas, hubs, live tiles, app bars, and more).

### Setup

Metrino is published to GitHub Packages, so point the `@angelmunoz` scope at that registry
in your project's `.npmrc`, then install it with its peer dependencies:

```
@angelmunoz:registry=https://npm.pkg.github.com
```

```bash
npm install @angelmunoz/metrino lit @mdi/js
```

Metrino does not register elements as an import side effect. Register them once at startup:

```fsharp
open Fable.Lit.Dsl.Metrino

// Everything...
Metrino.registerAll()

// ...or by category
Metrino.registerInputs()
Metrino.registerNavigation()

// ...or individual components (dependencies are registered automatically)
Metrino.Register.button()
Metrino.Register.pivot()   // also registers metro-pivot-item
```

### Example

```fsharp
open Fable.Lit.Dsl
open Fable.Lit.Dsl.Metrino

let toasts = new ToastHost()

[<HookComponent>]
let Page() =
    let dialog = Hook.useMemo (fun () -> MetroRef.create())
    let agreed, setAgreed = Hook.useState false

    view {
        metroPivot {
            metroPivotItem {
                header' "settings"

                metroToggleSwitch { on' true; "Wi-Fi" }

                metroCheckBox {
                    checked' agreed
                    onMetroChange (fun e -> setAgreed (detail<{| ``checked``: bool |}> e).``checked``)
                    "I agree"
                }

                metroButton {
                    accent
                    buttonTypeButton
                    onClick (fun _ -> MetroRef.show dialog)
                    "Save"
                }
            }

            metroPivotItem {
                header' "tiles"
                metroTileGrid {
                    columns 4
                    metroIconicTile { sizeMedium; icon "mail"; title' "Mail"; count 3 }
                    metroFlipTile {
                        sizeWide
                        div { slot' "front"; "Front" }
                        div { slot' "back"; "Back" }
                    }
                }
            }
        }

        metroContentDialog {
            MetroRef.bind dialog
            title' "Save changes?"
            "Your settings will be applied."

            metroButton {
                slot' "buttons"
                accent
                onClick (fun _ ->
                    toasts.Show("Your settings were saved", title = "Saved", severity = ToastSeverity.Success) |> ignore
                    MetroRef.hide dialog)
                "Save"
            }
        }
    }
```

### Highlights

- All Metrino components (`metroButton`, `metroPivot`, `metroPanorama`, `metroHub`, `metroLiveTile`, `metroAppBar`, `metroListView`, etc.)
- Typed properties (`accent`, `header'`, `title'`, `on'`, `selectedIndex`, `orientation`, `selectionMode`, `items`, `sizeWide`, ...)
- Typed events that receive a `CustomEvent` (`onMetroChange`, `onSelectionChanged`, `onItemClick`, `onShow`, `onClose`, ...), plus `detail<'T>` to read the payload
- `MetroRef` for imperative calls (`show`, `showAt`, `hide`, `toggle`, `setOptions`, `setSuggestions`, `scrollToIndex`, or `invoke` for any method)
- `ToastHost` for global toast notifications

### Notes

- Like a native button, `metroButton` submits its form by default. Use `buttonTypeButton` for buttons that should not.
- Metrino events are unprefixed (`change`, `show`, `close`, ...). The core `onChange` / `onInput` still work, but `onMetroChange` / `onMetroInput` give you a `CustomEvent` with `detail`.
- `onSelectionChanged` (`selectionchanged`: combo-box, list-box, pivot, hub, tab-view) and `onSelectionChange` (`selectionchange`: list-view, grid-view, long-list-selector, tree-view) are different events; use the one your component fires.
- Theme with CSS custom properties (`--metro-accent`, ...), `data-theme="light"`, or `accent="red"` on `<html>`. See the [Metrino README](https://github.com/AngelMunoz/metrino#theming).

---

# Extensibility: Build Your Own DSL

The DSL system is intentionally modular.
You can create your own DSL for any Web Component library.

### Minimal Example

```fsharp
module MyComponents

open Fable.Lit.Dsl

// Define elements for your web components
let fancyCard = ElementBuilder("fancy-card")
let fancyButton = ElementBuilder("fancy-button")

// Define typed properties
let cardTitle (text: string) = prop "cardTitle" text
let elevation (level: int) = prop "elevation" level

// Define typed events
let onFancyClick (handler: obj -> unit) : Attr = Event("fancy-click", handler)
```

Usage:

```fsharp
open MyComponents

view {
    fancyCard {
        cardTitle "Welcome"
        elevation 2

        fancyButton {
            onFancyClick (fun _ -> dispatch Click)
            "Click me"
        }
    }
}
```

You can extend:

- Components (using `ElementBuilder`)
- Attributes (using `attr`)
- Properties (using `prop`)
- Events (using `Event`)
- Boolean attributes (using `boolAttr`)

This repo models the pattern used by the HTML and Shoelace DSLs.

---

# More Examples

### Conditional Rendering

```fsharp
view {
    h2 { "Dashboard" }

    if model.IsLoading then
        slSpinner { }
    else
        div {
            p { $"Welcome, {model.Username}!" }
        }
}
```

### Lists

```fsharp
view {
    ul {
        for item in model.Items do
            li { item.Name }
    }
}
```

A `for` loop renders as a single list that Lit updates by position, so the surrounding element (with its scroll position, focus, and running animations) is kept when items are added or removed.
When items are inserted, removed, or reordered in the middle of a list, use `forKeyed` so each item's DOM follows its key:

```fsharp
view {
    ul {
        forKeyed (fun (m: Message) -> m.Id) model.Messages (fun m ->
            li { m.Text })
    }
}
```

### Mixing HTML and Shoelace

```fsharp
view {
    header {
        class' "app-header"
        h1 { "My App" }
    }

    main {
        slCard {
            div {
                slot' "header"
                h3 { "Stats" }
            }
            p { $"Count: {model.Count}" }

            div {
                slot' "footer"
                slButton {
                    variantPrimary
                    onClick (fun _ -> dispatch Increment)
                    "Increment"
                }
            }
        }
    }
}
```

### Using Refs

```fsharp
let inputRef = ref Unchecked.defaultof<Browser.Types.HTMLInputElement>

view {
    slInput {
        bindRef (fun el -> inputRef.Value <- el :?> _)
        label' "Focus me"
    }

    slButton {
        onClick (fun _ -> inputRef.Value.focus())
        "Focus Input"
    }
}
```

### Embedding Raw Lit Templates

```fsharp
open Lit

view {
    h1 { "Mixed Content" }

    // Embed an existing Lit template
    lit (html $"<p>Raw Lit template</p>")

    // Or raw HTML (use sparingly)
    rawHtml "<p>Raw HTML string</p>"
}
```

---

## Roadmap

The DSL system is intentionally modular, and this repo may grow over time as more UI libraries adopt Web Components.

### Potential Future DSLs
- **FluentUI DSL** - Microsoft's Fluent Web Components
- **FAST DSL** - FAST's design tokens and component model
- **Material Web DSL** - Google's Material Web Components
- **Community DSLs** - Anyone can build a DSL package for their preferred component library

### Future Improvements
- Additional typed attributes and events
- Expanded examples and documentation
- Potential integration with design-token systems
