module MergeSortTests

open NUnit.Framework
open FsUnit

[<TestFixture>]
type Tests() =
    static member SortArraySource = TestSources.sortSource
    
    static member SortSeqSource = TestSources.sortSource
    
    static member MergeListSource = TestSources.mergeSource
    
    static member MergeSeqSource = TestSources.mergeSource
    
    [<TestCaseSource("SortArraySource")>]
    static member MergeSortArrayTest list =
        let array = List.toArray list         
        let result = MergeSort.mergeSort_v1List array

        let expected = Array.sort array
        result |> should equal expected

    [<TestCaseSource("SortSeqSource")>]
    static member MergeSortSeqTest list =
        let array = List.toArray list
        let result = MergeSort.mergeSort_v2Seq array |> Seq.toArray

        let expected = Array.sort array
        result |> should equal expected

    [<TestCaseSource("MergeListSource")>]
    static member MergeListTest (tuple : 'a list * 'a list * 'a list) =
        let (left, right, expected) = tuple 
        let actual = MergeSort.merge_v1List left right
        
        actual |> should equal expected

    [<TestCaseSource("MergeSeqSource")>]
    static member MergeSeqTest (tuple : 'a list * 'a list * 'a list) =
        let (left, right, expected) = tuple 
        let actual = MergeSort.merge_v2Seq left right
        
        actual |> should equal expected
    
        

