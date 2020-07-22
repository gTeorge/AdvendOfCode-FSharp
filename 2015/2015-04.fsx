open System.Security.Cryptography
open System.Text

let md5 (data : byte array) : string =
    use md5 = MD5.Create()
    (StringBuilder(), md5.ComputeHash(data))
    ||> Array.fold (fun sb b -> sb.Append(b.ToString("x2")))
    |> string

let hash = md5 "abcdef609043"B

let rec findNumber text (iterator : int) (startsWith : string) =
    let t = text + (iterator |> string)
    let h = Encoding.ASCII.GetBytes t |> md5
    match h with 
    | h when h.StartsWith startsWith -> iterator
    | _ -> findNumber text (iterator + 1) startsWith

//part 1
findNumber "bgvyzdsv" 1 "00000"
|> printfn "%d"

//part 2
findNumber "bgvyzdsv" 1 "000000"
|> printfn "%d"