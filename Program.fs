// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace Advent2018

open Task2

module Main =

    [<EntryPoint>]
    let main argv = 
        let file = new System.IO.StreamReader("../../Tasks/input2.txt")
        printfn "%A" <| task2 file
        System.Console.ReadKey() |> ignore
        0 // return an integer exit code
