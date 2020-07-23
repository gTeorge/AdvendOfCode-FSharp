open System.IO

let source = File.ReadAllLines("./2016-06-input.txt")
             |> Seq.toList
             |> List.map (fun x -> x |> Seq.toList |> List.map string)
             |> List.transpose
             
                        
let part1 =  source
             |> List.map (fun x -> fst(x |> List.countBy id |> List.maxBy snd))
             |> List.reduce (+)

let part2 =  source
             |> List.map (fun x -> fst(x |> List.countBy id |> List.minBy snd))
             |> List.reduce (+)
