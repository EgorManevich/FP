module QuickSortTests

open NUnit.Framework
open FsUnit

[<TestFixture>]
type Tests() =
    
    static member SplitBySource = TestSources.splitBySource
    
    static member SplitByPredicate = TestSources.splitByPredicate
    
    static member SortSource = TestSources.sortSource
    
    [<TestCaseSource("SortSource")>]
    static member QuickSortTest list =
        let result = QuickSort.quickSort list

        let expected = List.sort list
        result |> should equal expected

    [<TestCaseSource("SplitBySource")>]
    static member SplitByTest (tuple : 'a list * 'a list * 'a list) =
        let (source, expectedLeft, expectedRight) = tuple 
        let (left, right) = QuickSort.splitBy Tests.SplitByPredicate source
    
        left |> should  equal expectedLeft 
        right |> should equal expectedRight

