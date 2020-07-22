open System
open System.IO

let source = File.ReadAllText(__SOURCE_DIRECTORY__ + "/2015-01-input.txt")

module partOne =
    let rec countLvls (acc:int) (text:char list) =
        match text with
        | [] -> acc
        | h::t when h = ')' -> countLvls (acc - 1) t
        | h::t when h = '(' -> countLvls (acc + 1) t
        | h::t -> countLvls acc t

module partTwo =
    let rec countLvls acc text step =
        match acc with
        | x when x = -1 -> step
        | _ -> match text with
               | [] -> step
               | h::t when h = ')' -> countLvls (acc - 1) t (step + 1)
               | h::t when h = '(' -> countLvls (acc + 1) t (step + 1)
               | h::t -> countLvls acc t (step + 1)

partOne.countLvls 0 (source |> Seq.toList)
|> printfn "%d"

partTwo.countLvls 0 (source |> Seq.toList) 0
|> printfn "%d"