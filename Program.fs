// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
namespace Advent2018

module Main =
    [<EntryPoint>]
    let main argv = 
        let name = "../../Tasks/input3.txt"
        let file = new System.IO.StreamReader(name)
        printfn "%A" <| Task3.task3 file
        let file = new System.IO.StreamReader(name)
        printfn "%A" <| Task3.task3and1 file
        System.Console.ReadKey() |> ignore
        0 // return an integer exit code
