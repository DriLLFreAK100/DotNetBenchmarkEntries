# LINQ Intersection Performance: List vs. HashSet for Existence Check

This benchmark test compares the performance of different LINQ-based approaches to determine if any elements from one collection (`_listA` of `Student` objects) have an `Id` that exists in a target collection of `Id`s. The primary focus is on checking for the _existence_ of at least one common `Id`.

Three methods are benchmarked:

1.  **`ListIntersectListAny`**: Converts the target `Id`s to a `List<int>` and then uses `_listA.Select(x => x.Id).Intersect(targetList).Any()`.
2.  **`ListIntersectHashSetAny`**: Converts the target `Id`s to a `HashSet<int>` and then uses `_listA.Select(x => x.Id).Intersect(targetHashSet).Any()`.
3.  **`ListAnyMatchHashSet`**: Converts the target `Id`s to a `HashSet<int>` and then uses `_listA.Any(id => targetHashSet.Contains(id))`.

The goal is to evaluate the speed (mean execution time) and memory allocation for these common scenarios of checking for overlapping elements, particularly highlighting the benefits of using a `HashSet` for lookups.

The benchmark results below show these comparisons.

BenchmarkDotNet v0.14.0, macOS Sequoia 15.5 (24F74) [Darwin 24.5.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
[Host] : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD

```

| Method                  | N    |      Mean |    Error |   StdDev |    Median | Ratio |   Gen0 | Allocated | Alloc Ratio |
| ----------------------- | ---- | --------: | -------: | -------: | --------: | ----: | -----: | --------: | ----------: |
| ListIntersectListAny    | 1000 | 161.51 ns | 0.229 ns | 0.191 ns | 161.54 ns |  1.00 | 0.0801 |     504 B |        1.00 |
| ListIntersectHashSetAny | 1000 | 157.34 ns | 0.303 ns | 0.269 ns | 157.34 ns |  0.97 | 0.0739 |     464 B |        0.92 |
| ListAnyMatchHashSet     | 1000 |  51.90 ns | 0.075 ns | 0.066 ns |  51.91 ns |  0.32 | 0.0216 |     136 B |        0.27 |
```
