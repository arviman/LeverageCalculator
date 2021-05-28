// Learn more about F# at http://fsharp.org

open System

let calculateLong ( price: float, lev: float) = price * (1. - (1./lev))
let calculateShort ( price: float, lev: float) = price * (1. + 1. /lev)
let parseFloat s = try Some (float s) with | _ -> None

[<EntryPoint>]
let main argv =
    printfn("Enter the price to calculate liquidation levels: ")
    let price = parseFloat (Console.ReadLine());
    let leverages = [ 1.2; 1.5; 2. ; 3.; 5.; 10. ] 
    match price with
    | Some p ->
        for lev in leverages do
            printfn $"Long {lev}x {calculateLong(p, lev)}"            
        for lev in leverages do
            printfn $"Short {lev}x {calculateShort(p, lev)}"
    | None -> printfn "Enter a float"
    
    0 // return an integer exit code
