namespace Advent2018

module Task1 =
    let getNumbers(file : System.IO.StreamReader) =
        let str = file.ReadToEnd()
        let numbers = str.Split('\n')
        Array.filter (fun (x : string) -> x.Length > 0) numbers
            |> Array.map (fun (x : string) -> (if x.[0].Equals('+') then x.Substring(1) else x) |> int)


    let task1 (file : System.IO.StreamReader) =
            getNumbers(file) |> Array.sum

    let task1and1 (file : System.IO.StreamReader) =
        let numbers = getNumbers(file)
        let history = new System.Collections.Generic.HashSet<int>()
        let result = new System.Collections.Generic.HashSet<int>()

        let rec fold (acc : int) = 
            let x = Array.fold (fun acc elem ->
                        if history.Contains(acc) then printfn "%A" acc; result.Add acc |> ignore
                        else history.Add(acc) |> ignore
                        acc + elem) acc numbers
            if(result.Count = 0) then fold(x) |> ignore

        fold(0)
