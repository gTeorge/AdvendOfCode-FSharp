open System
open System.IO

let source = File.ReadAllLines(__SOURCE_DIRECTORY__ + "/2016-07-input.txt") |> Seq.toList

//Part 1
let hasTslString (text : string) =
    let rec check (text : char list) =
        match text with
        | [] -> false
        | first::second::third::fourth::_ when (first = fourth
                                  && second = third
                                  && first <> second) -> true
        | _::t -> check t
    text
    |> Seq.toList
    |> check

let split (text : string) =
    text.Split ('[',']')

let checkIP (text : string array) =
    let text = text |> Seq.toList
    let rec check state outsider (text : string list) =
        match text with
        | [] -> state
        | h::t when outsider && ( h|> hasTslString ) -> check true false t
        | h::_ when not outsider && ( h|> hasTslString ) -> false
        | _::t -> check state (not outsider) t
    check false true text

let boolToInt n =
    if n then 1 else 0

let TSLcheck = split >> checkIP

let resultPart1 = source
                 |> List.map (fun x -> x |> TSLcheck |> boolToInt)
                 |> List.sum

//Part 2

let sslCheck (text : string) =
    let rec check (text : char list) =
        match text with
        | [] -> false
        | first::second::third::_ when first = third && first <> second -> true
        | _::t -> check t
    text
    |> Seq.toList
    |> check
