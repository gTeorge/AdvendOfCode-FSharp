open System
open System.IO

let source = File.ReadAllText(__SOURCE_DIRECTORY__ + "/2015-03-input.txt")
             |> Seq.toList

let updatePosition (pos: int * int) (dir: char) =
    match dir with
    | c when c = '<' -> (fst pos - 1, snd pos)
    | c when c = '>' -> (fst pos + 1, snd pos)
    | c when c = '^' -> (fst pos, snd pos + 1)
    | c when c = 'v' -> (fst pos, snd pos - 1)
    | _ -> pos

module partOne =
    let visits directions =
        let rec travel dir pos (ls: (int*int) list) =
            match dir with
            | [] -> ls
            | h::t -> let newPosition = updatePosition pos h
                      travel t newPosition (ls|> List.append [newPosition])
        travel directions (0,0) [(0,0)]

module partTwo = 
    let visits directions =
        let rec travel dir posSanta posRobo (ls: (int * int) list) =
            match dir with
            | [] -> ls
            | [s] -> let newSantaPosition = updatePosition posSanta s
                     travel [] newSantaPosition posRobo (ls |> List.append [newSantaPosition])
            | s::r::t -> let newSantaPosition = updatePosition posSanta s
                         let newRoboPosition = updatePosition posRobo r
                         travel t newSantaPosition newRoboPosition (ls |> List.append [newSantaPosition; newRoboPosition])
        travel directions (0,0) (0,0) [(0,0)]


partOne.visits source
|> List.distinct
|> List.length
|> printfn "%d"

partTwo.visits source
|> List.distinct
|> List.length
|> printfn "%d"