namespace Ishi.Form

open Ishi.Exo

module Lowering =
    let ifToMatch expr =
        let left = { Binding = Expr (Expr.Bool true); Body = [expr.Left] } in
        let right = { Binding = Expr (Expr.Bool false); Body = [expr.Right] } in
        let matchExpr = Expr.Match (expr.Cond, [left; right]) in
        matchExpr

    let lowerFunction functionDefinition =
        let lowerExpr (expr: Expr) =
            match expr with
            | Expr.If ifThenElse -> ifToMatch ifThenElse
            | Expr.Let letBinding ->
                match letBinding.Value with
                | Expr.If ifThenElse ->
                    Expr.Let
                        {
                            Binding = letBinding.Binding
                            Value = ifToMatch ifThenElse
                            Expression = letBinding.Expression
                        }
                | _ -> expr

            | _ -> expr

        let newBody = List.map lowerExpr functionDefinition.Body in
        let newFunction =
            {
                Name = functionDefinition.Name
                Parameters = functionDefinition.Parameters
                Body = newBody
            }
        in
        newFunction

    let lowerProgram program =
        let loweredBody = List.map lowerFunction program.Statements in
        let newProgram =
            {
                FileName = program.FileName
                Statements = loweredBody
            }
        in
        newProgram
