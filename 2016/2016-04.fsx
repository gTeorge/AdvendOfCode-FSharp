open System
open System.IO

module String =
    let split (delimiter : char array) (text : string)= text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)

type Room = {
    Code : string
    Checksum : string
}

let alphabet = ['a' .. 'z']

let isAlphabetChar x = alphabet |> List.contains x

let source = File.ReadAllLines("./2016-04-input.txt")
             |> Seq.toList
             |> List.map (fun x -> let sp = x |> String.split [|'[';']'|]
                                   {Code = sp.[0]; Checksum = sp.[1]})

let check ( room : Room ) = 
    let checksum = room.Checksum |> Seq.toList
    let counts = room.Code
                 |> Seq.toList 
                 |> List.filter isAlphabetChar
                 |> List.filter ( fun x -> List.contains x checksum )
                 |> List.countBy id
    let rec check (result : bool) (last : int) (chksum : char list) =
        match chksum with
        | [] -> result
        | h::t -> let r = counts 
                          |> List.tryFind (fun x -> fst x = h)
                  match r with
                  | Some x -> let value = snd r.Value
                              if value > last then check false value t
                              else check result value t
                  | None -> check false last t
    check true 999 checksum
    
let part1 = source
            |> List.filter check
            |> List.length

let x = check {Code = "not-a-real-room-404"; Checksum = "oarel"}