namespace Advent2018

module Task2 =
    let getStrings(file : System.IO.StreamReader) =
        file.ReadToEnd().Split('\n')
            |> Array.filter (fun x -> x.Length > 0)

    let hasNOccurenceChars n arr =
        arr
            |> Array.map (fun map -> Map.filter (fun _ v -> v = n) map)
            |> Array.filter (fun map -> not map.IsEmpty)

    let task2(file : System.IO.StreamReader) =
        let strings = getStrings file
        let counts = strings
                        |> Array.map (fun str -> str.ToCharArray())
                        |> Array.map (fun str -> Array.fold (fun (acc : Map<char, int>) x -> if acc.ContainsKey(x) then acc.Add(x, acc.[x] + 1) else acc.Add(x, 1)) Map.empty str)

        let two = hasNOccurenceChars 2 counts
        let three = hasNOccurenceChars 3 counts

        two.Length * three.Length