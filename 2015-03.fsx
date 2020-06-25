open System
open System.IO

let source = File.ReadAllText(__SOURCE_DIRECTORY__ + "/2015-03-input.txt")


module partOne =
    let visits (directions: string) =
        let directions = directions |> Seq.toList
        let rec travel dir pos (ls: (int*int) list)=
            match dir with
            | [] -> ls
            | h::t when h = '<' -> travel t (fst pos - 1, snd pos) (ls|> List.append [(fst pos - 1, snd pos)])
            | h::t when h = '>' -> travel t (fst pos + 1, snd pos) (ls|> List.append [(fst pos + 1, snd pos)])
            | h::t when h = '^' -> travel t (fst pos, snd pos + 1) (ls|> List.append [(fst pos, snd pos + 1)])
            | h::t when h = 'v' -> travel t (fst pos, snd pos - 1) (ls|> List.append [(fst pos, snd pos - 1)])
            | h::t -> travel t pos ls
        travel directions (0,0) [(0,0)]

//module partTwo = 
    // Split directions to santa and robot

partOne.visits source
|> List.distinct
|> List.length
|> printfn "%d"
