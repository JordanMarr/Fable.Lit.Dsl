# Fable.Lit.Dsl

A collection of expressive, type‑safe DSLs for building UI with **Fable.Lit**.  
This repo currently includes:

- **HTML DSL** — a clean, idiomatic way to write Lit templates in F#  
- **Shoelace DSL** — typed components, attributes, and events for the Shoelace Web Component library  

More DSLs will be added over time.

### 🔗 Related Projects  
- **Fable.Lit** — core F# bindings for Lit: https://github.com/fable-compiler/Fable.Lit

---

## Installation

Add the packages to your project:

```bash
dotnet add package Fable.Lit.Dsl
dotnet add package Fable.Lit.Dsl.Shoelace
```

If using Shoelace, register its assets at app startup:

```fsharp
open Fable.Lit.Dsl.Shoelace

Shoelace.registerAll()
```

---

# HTML DSL

The HTML DSL provides a natural, structured way to write Lit templates in F# without stringly‑typed markup.

### Example

```fsharp
html {
    h1 { "Hello, world!" }

    p { "This is the Fable.Lit HTML DSL." }

    button {
        Attr.disabled false
        Ev.onClick (fun _ -> dispatch Increment)
        "Click me"
    }
}
```

### Highlights

- Strongly‑typed attributes and events  
- Natural F# structure  
- No raw HTML strings  
- Works seamlessly with Lit components and custom elements  

---

# Shoelace DSL

Typed, ergonomic bindings for the Shoelace Web Component library.

### Example

```fsharp
sl.button {
    Attr.variant "primary"
    Ev.onSlClick (fun _ -> dispatch Save)
    "Save"
}
```

### Highlights

- All Shoelace components supported  
- Typed attributes (`Attr.size`, `Attr.disabled`, `Attr.variant`, …)  
- Typed events (`Ev.onSlChange`, `Ev.onSlInput`, …)  
- Works alongside the HTML DSL  

---

# Extensibility: Build Your Own DSL

The DSL system is intentionally modular.  
You can create your own DSL for any Web Component library.

### Minimal Example

```fsharp
module MyLib =
    let fancyCard = LitElement.define "fancy-card"

    let card props children =
        el fancyCard props children
```

You can extend:

- Components  
- Attributes  
- Properties  
- Events  
- Entire DSL modules  

This repo models the pattern used by the HTML and Shoelace DSLs.

---

# Examples

### Simple Page

```fsharp
html {
    h2 { "Welcome" }
    sl.input {
        Attr.placeholder "Your name"
        Ev.onSlInput (fun e -> dispatch (NameChanged e.value))
    }
}
```

### Component Composition

```fsharp
let view model dispatch =
    html {
        myHeader { Attr.title "Dashboard" }

        sl.card {
            h3 { "Stats" }
            p { $"Count: {model.Count}" }
        }
    }
```

---

## Roadmap

The DSL system is intentionally modular, and this repo will grow over time as more UI libraries adopt Web Components or stable APIs suitable for typed DSLs.

### 📦 Planned / Potential DSLs
- **FluentUI DSL**  
  Microsoft’s Fluent Web Components are a natural fit for typed F# bindings and would provide a first‑party design system option.

- **FAST DSL**  
  FAST’s design tokens and component model map cleanly onto the DSL architecture and would make a strong addition for enterprise‑grade apps.

- **Material Web DSL**  
  Google’s Material Web Components are widely used and would give the ecosystem a familiar, cross‑platform design language.

- **Community DSLs**  
  The DSL architecture is intentionally open. Anyone can build a DSL package for their preferred component library, custom design system, or internal UI kit.

### 🧭 Future Improvements
- Additional typed attributes and events  
- More component libraries  
- Expanded examples and documentation  
- A small “DSL Cookbook” for building your own modules  
- Potential integration with design‑token systems  

---

