<Query Kind="FSharpExpression" />

let print = printfn "%A" >> ignore

let rec merge_v1List left right = 
            match left with
            | [] -> right
            | leftHead::leftTail -> 
                match right with
                | [] -> left
                | rightHead::rightTail ->
                    if leftHead < rightHead then leftHead::(merge_v1List leftTail right) else rightHead::(merge_v1List left rightTail)

let rec merge_v2Seq left right = 
            match (left, right) with
            | (seq, _) when Seq.isEmpty seq -> right
            | (_, seq) when Seq.isEmpty seq -> left
            | (leftSeq, rightSeq) ->                 
                let leftHead = Seq.head leftSeq
                let leftTail = Seq.tail leftSeq
                let rightHead = Seq.head rightSeq
                let rightTail = Seq.tail rightSeq
                if leftHead < rightHead 
                    then Seq.append (Seq.singleton leftHead) (merge_v2Seq leftTail rightSeq)
                    else Seq.append (Seq.singleton rightHead) (merge_v2Seq left rightTail)
//
//merge [] [] |> print
//merge [1] [] |> print
//merge [1] [3] |> print
//merge [3] [1] |> print
//merge [1;2;3] [5] |> print
//merge [1;2;3] [-4] |> print
//merge [1;2;3;] [-4;5] |> print
//merge [-2;3;6] [1;2;7] |> print

let rec mergeSort_v1Arr (array: 'a array) = 
    match array with
    | [||] -> array
    | [|x|] -> array
    | _ -> 
        let splitSortToList = Array.splitInto 2 >> Array.map mergeSort_v1Arr >> Array.map Array.toList
        let [| left; right |] = splitSortToList array        
        merge_v1List left right |> Seq.toArray
   
let rec mergeSort_v2Seq (array: 'a array) = 
    match array with
    | [||] -> Seq.empty
    | [|x|] -> Seq.singleton x
    | _ -> 
        let splitSort = Array.splitInto 2 >> Array.map mergeSort_v2Seq
        let [| left; right |] = splitSort array        
        merge_v2Seq left right

let mergeSort = mergeSort_v2Seq;
             
mergeSort [||] |> print
mergeSort [|1|] |> print
mergeSort [|1;2|] |> print
mergeSort [|2;1|] |> print
mergeSort [|1;2;3|] |> print
mergeSort [|3;2;1|] |> print
mergeSort [|1;2;3;4|] |> print
mergeSort [|4;3;2;1|] |> print
mergeSort [|-2;1;4;0;-6;3|] |> print