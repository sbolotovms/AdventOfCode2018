// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace Advent2018

module Main =
    [<EntryPoint>]
    let main argv = 
        let file = new System.IO.StreamReader("../../Tasks/input3.txt")
        printfn "%A" <| Task3.task3 file
        System.Console.ReadKey() |> ignore
        0 // return an integer exit code
