namespace Fable.Lit.Dsl

open Lit

// =============================================================================
// AST Types (renderer-agnostic)
// =============================================================================

/// Represents an HTML attribute.
type Attr =
    | Attr of name: string * value: obj
    | BoolAttr of name: string * enabled: bool
    | Prop of name: string * value: obj
    | Event of name: string * handler: obj
    | Ref of setter: (obj -> unit)

/// Represents a node in the HTML tree.
type Node =
    | Element of tag: string * attrs: Attr list * children: Node list
    | Text of string
    /// A dynamic list of nodes (e.g. from a `for` loop), rendered as a single template slot.
    | Fragment of Node list
    /// The sequential statements of a builder body, each rendered in its own template slot.
    /// Produced by the builders' Combine so that a parent's template stays stable across renders.
    | Sequence of Node list
    | RawHtml of string
    | Template of TemplateResult
    | AttrNode of Attr
    | Nothing
