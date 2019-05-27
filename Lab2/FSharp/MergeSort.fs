module MergeSort

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

let rec mergeSort_v1List (array: 'a array) = 
    match array with
    | [||] -> Array.toList array
    | [|x|] -> Array.toList array
    | _ -> 
        let splitSortToList = Array.splitInto 2 >> Array.map mergeSort_v1List >> Array.map Seq.toList
        let [| left; right |] = splitSortToList array        
        merge_v1List left right
   
let rec mergeSort_v2Seq (array: 'a array) = 
    match array with
    | [||] -> Seq.empty
    | [|x|] -> Seq.singleton x
    | _ -> 
        let splitSort = Array.splitInto 2 >> Array.map mergeSort_v2Seq
        let [| left; right |] = splitSort array        
        merge_v2Seq left right