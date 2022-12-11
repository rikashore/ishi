namespace Ishi.Monitor

open Ishi.Exo
open Ishi.Form

module App =

    [<EntryPoint>]
    let main _args =
        let program =
            { FileName = "test.ishi"
              Statements =
                  [ { Name = "if_test"
                      Parameters = List.empty
                      Body =
                          [ Expr.Let
                                { Binding = Pattern.Ident "name"
                                  Value =
                                      Expr.If
                                          { Cond = Expr.Binary(BinaryOp.LessEqual, Expr.Int 11, Expr.Int 12)
                                            Left = Expr.String "foo"
                                            Right = Expr.String "bar" }
                                  Expression = Expr.Ident "name" } ] } ] }

        printfn $"{program}"

        let newProgram = Lowering.lowerProgram program
        printfn $"{newProgram}"

        0
