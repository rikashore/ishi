namespace Ishi.Exo

type Token =
    // Delimiters
    | LBox
    | RBox
    | LParen
    | RParen
    | LCurl
    | RCurl
    // Punctuation
    | Dot
    | Eq
    | Colon
    | Quote
    | DoubleQuote
    | Hash
    | Bang
    | Question
    | Percent
    | Amp
    | At
    | Lt
    | Gt
    | Slash
    | BackSlash
    | Plus
    | Minus
    | Star
    | Caret
    | Pipe
    // Keywords
    | Let
    | Fun
    | End
    | Match
    | If
    | Then
    | Else
    | Sig
    | Mod
    | Functor
    | Anon
    // Literals
    | Ident of string
    | Int of int
    | Float of float
    | Bool of bool
    | String of raw: string
    | Unit
    // Others
    | Eof
