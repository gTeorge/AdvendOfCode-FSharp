open System
open System.IO

type box ={ W: int; L: int; H: int} 

let source = File.ReadAllLines(__SOURCE_DIRECTORY__ + "/2015-02-input.txt")
    

let surface (d: int array) =
    let sortedD = d|> Array.sort
    (2 * (
            d.[0] * d.[1] 
          + d.[1] * d.[2]
          + d.[0] * d.[2]
         ) 
     + (sortedD.[0] * sortedD.[1]))

let dimensions =
    source
    |> Array.map ( fun x -> x.Split ('x') 
                            |> Array.map (fun x -> x |> int)
                            |> surface )
    |> Array.sum

dimensions
|> printfn "%d"