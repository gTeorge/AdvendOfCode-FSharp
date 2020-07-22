open System
open System.IO

module String =
    let split (delimiter : char array) (text : string)= text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)

let source = File.ReadAllLines("./2016-03-input.txt")
             |> Seq.toList
             |> List.map (fun x -> x 
                                    |> String.split [|' '|]
                                    |> Seq.toList
                                    |> List.map int) 

let isTriangle (sides : int list) =
    sides.[0] + sides.[1] > sides.[2]
    && sides.[1] + sides.[2] > sides.[0]
    && sides.[0] + sides.[2] > sides.[1]

let part1 = 
    source 
    |> List.countBy isTriangle


let part2 = 
    let list = source |> List.reduce List.append
    let rec createTriangles (triangles : int list list) (ls : int list) =
        match ls with
        | [] -> triangles
        | a1::a2::a3::b1::b2::b3::c1::c2::c3::t -> createTriangles ([[a1;b1;c1];[a2;b2;c2];[a3;b3;c3]] |> List.append triangles) t
        | _::t -> createTriangles triangles t
    createTriangles [] list
    |> List.countBy isTriangle



