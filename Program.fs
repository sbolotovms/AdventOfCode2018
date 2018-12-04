// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace Advent2018

open Task1

module Main =

    [<EntryPoint>]
    let main argv = 
        let file = new System.IO.StreamReader("../../Tasks/input1.txt")
        printfn "%A" <| task1and1 file
        System.Console.ReadKey() |> ignore
        0 // return an integer exit code
