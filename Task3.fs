namespace Advent2018

open System.IO
open System.Text.RegularExpressions

module Task3 =
    let pattern = @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)"

    type Claim = {id:int; left: int; top: int; width: int; height: int}

    let getRequests(file: StreamReader) =
        file.ReadToEnd().Split('\n')
            |> Array.filter (fun str -> Regex.IsMatch(str, pattern))
            |> Array.map(fun str -> 
                let matches = Regex.Match(str, pattern).Groups
                assert (matches.Count = 6)
                {id = matches.[1].Value |> int; left = matches.[2].Value |> int; top = matches.[3].Value |> int; width = matches.[4].Value |> int; height = matches.[5].Value |> int})

    let task3 (file: StreamReader) =
        let reqs = getRequests file
        let fabric = Array2D.zeroCreate 1000 1000

        reqs
        |> Array.iter (fun claim ->
            for i in claim.left..(claim.left + claim.width - 1) do
                for j in claim.top..(claim.top + claim.height - 1) do
                    Array2D.set fabric i j (fabric.[i, j] + 1))

        let mutable res = 0

        fabric
            |> Array2D.iter (fun x -> if x > 1 then res <- res + 1)

        res

    let task3and1 (file: StreamReader) =
        let reqs = getRequests file

        let overlaps (a: Claim) (b: Claim) =
            a.id <> b.id &&
                not (b.left > a.left + a.width - 1 || a.left > b.left + b.width - 1 ||
                        b.top > a.top + a.height - 1 || a.top > b.top + b.height - 1)

        let res = reqs
                  |> Array.find (fun claim -> not (reqs |> Array.exists (overlaps claim)))

        res.id
