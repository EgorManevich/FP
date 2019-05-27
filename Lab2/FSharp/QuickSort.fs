module QuickSort

let public splitBy predicate seq = 
    Seq.fold 
        (fun state x ->
            if predicate(x) then
                let newFst = List.append (fst state) [x]
                (newFst, snd state)
            else 
                let newSnd = List.append (snd state) [x]
                (fst state, newSnd)) ([], []) seq
        
let rec quickSort (a: 'a seq) = 
    match a with
    | seq when Seq.isEmpty seq -> List.Empty
    | seq -> 
        let head = Seq.head seq
        let tail = Seq.tail seq
        let (less, greaterOrEqual) = splitBy (fun x -> x < head) tail
        let lessSorted = quickSort less
        let greaterOrEqualSorted = quickSort greaterOrEqual
        List.append (List.append lessSorted [head]) greaterOrEqualSorted



