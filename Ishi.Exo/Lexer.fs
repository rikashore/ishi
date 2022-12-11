namespace Ishi.Exo

open System
open System.Runtime.CompilerServices

module Lexer =
    [<Struct; IsByRefLike>]
    type private State =
        {
            Source: ReadOnlySpan<char>
            mutable Idx: int
        }
