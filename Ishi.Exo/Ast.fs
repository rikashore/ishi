namespace Ishi.Exo


type AnnotatedTy = string // todo change to actual types

type Ident = string

type Pattern =
    | Ident of Ident
    | Expr of Expr

and BinaryOp =
    | Add
    | Sub
    | Mul
    | Div
    | Pow
    | Equal
    | NotEqual
    | Less
    | LessEqual
    | Greater
    | GreaterEqual

and LetBinding =
    {
        Binding: Pattern
        Value: Expr
        Expression: Expr
    }

and MatchCase =
    {
        Binding: Pattern
        Body: Expr list
    }

and IfThenElse =
    {
        Cond: Expr
        Left: Expr
        Right: Expr
    }

and Expr =
    | String of string
    | Int of int
    | Float of float
    | Bool of bool
    | Unit
    | Ident of Ident
    | Binary of BinaryOp * Expr * Expr
    | Call of ident: Ident * arguments: Expr list
    | Let of LetBinding
    | If of IfThenElse
    | Match of Expr * MatchCase list

type FunctionParameter =
    {
        Name: string
        Annotation: AnnotatedTy option
    }

type FunctionDefinition =
    {
        Name: string
        Parameters: FunctionParameter list
        Body: Expr list
    }

type ProgramFile =
    {
        FileName: string
        Statements: FunctionDefinition list
    }
