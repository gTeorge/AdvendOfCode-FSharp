open System
open System.IO

let source = File.ReadAllText(__SOURCE_DIRECTORY__ + "/2015-01-input.txt")

let rec countLvls (acc:int) (text:char list) =
    match text with
    | [] -> acc
    | h::t when h = ')' -> countLvls (acc - 1) t
    | h::t when h = '(' -> countLvls (acc + 1) t
    | h::t -> countLvls acc t

let result = countLvls 0 (source |> Seq.toList)
