<Query Kind="FSharpExpression" />

let print = printfn "%A" >> ignore

let splitBy predicate seq = 
    Seq.fold 
        (fun state x ->
            if predicate(x) then
                let newFst = fst state |> List.append [x]
                (newFst, snd state)
            else 
                let newSnd = snd state |> List.append [x]
                (fst state, newSnd)) ([], []) seq

//splitBy (fun x -> x % 2 = 0) [] |> print
//splitBy (fun x -> x % 2 = 0) [1] |> print
//splitBy (fun x -> x % 2 = 0) [1;2] |> print
//splitBy (fun x -> x % 2 = 0) [5;2;7;2;8;8] |> print
//splitBy (fun x -> x % 2 = 0) [19;5;0;12] |> print


let rec quickSort a = 
    match a with
    | seq when Seq.isEmpty seq -> List.Empty
    | seq -> 
        let head = Seq.head seq
        let tail = Seq.tail seq
        let (less, greaterOrEqual) = splitBy (fun x -> x < head) tail
        let lessSorted = quickSort less
        let greaterOrEqualSorted = quickSort greaterOrEqual
        List.append (List.append lessSorted [head]) greaterOrEqualSorted
        
             
quickSort [] |> print
quickSort [1] |> print
quickSort [1;2] |> print
quickSort [2;1] |> print
quickSort [1;2;3] |> print
quickSort [3;2;1] |> print
quickSort [1;2;3;4] |> print
quickSort [4;3;2;1] |> print
quickSort [-2;1;4;0;-6;3] |> print