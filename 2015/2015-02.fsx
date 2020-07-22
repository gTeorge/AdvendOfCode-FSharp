open System
open System.IO

let source = File.ReadAllLines(__SOURCE_DIRECTORY__ + "/2015-02-input.txt")
             |> Array.map ( fun x -> x.Split ('x') |> Array.map (fun x -> x |> int))
    
module partOne =
    let surface (d: int array) =
        let sortedD = d|> Array.sort
        (2 * (
                d.[0] * d.[1] 
              + d.[1] * d.[2]
              + d.[0] * d.[2]
             ) 
         + (sortedD.[0] * sortedD.[1]))

    let dimensions (arr: (int array) array)=
        arr |> Array.sumBy (fun x -> x |> surface)

module partTwo =
    let length (d: int array) =
        let sortedD = d|> Array.sort
        (2 * (sortedD.[0] + sortedD.[1]) + sortedD.[0] * sortedD.[1] * sortedD.[2])
    let sumLenght (arr: (int array) array) =
        arr |> Array.sumBy (fun x -> x |> length)


partOne.dimensions source |> printfn "%d"

partTwo.sumLenght source |> printfn "%d"
