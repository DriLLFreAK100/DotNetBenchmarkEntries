# LINQ vs ZLinq Performance Benchmark

Run with the following command to target the multiframeworks

```bash
dotnet run -c Release -f net9.0 --runtimes net8.0 net9.0
```


This benchmark evaluates the performance differences between standard LINQ and ZLinq, a value-type based LINQ alternative that aims to reduce memory allocations and improve performance for common collection operations.

## Benchmark Overview

The benchmark compares these two LINQ implementations across multiple dimensions:

1. **Data Types**:
   - **Complex Types**: A custom `Student` class with Id, Name, and IsEnrolled properties
   - **Primitive Types**: Integer collections
   - **Reference Types**: String collections

2. **Operation Modes**:
   - **Non-materialized**: Iterating through query results without creating a new collection
   - **Materialized**: Creating a new collection using `.ToList()` after query execution

3. **LINQ Operations**:
   - Filtering data with `.Where()`
   - Transforming data with `.Select()`
   - Chained operations combining filtering and projection

4. **Runtime Comparison**:
   - .NET 8.0
   - .NET 9.0

The primary goal is to compare execution time (Mean), memory allocation (Allocated memory), and garbage collection impact (Gen0/Gen1/Gen2) between standard LINQ and ZLinq's value-based implementation. This helps understand when and where value-type based LINQ operations might offer performance advantages over reference-based LINQ operations.


```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.5335/22H2/2022Update/SunValley2)
Intel Core Ultra 9 185H, 1 CPU, 22 logical and 16 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  Job-LYVUME : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX2
  Job-ROJCPE : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2


```
| Method                       | Runtime  | Categories                      | N       | Mean        | Error       | StdDev      | Median      | Ratio | RatioSD | Gen0      | Gen1      | Gen2     | Allocated  | Alloc Ratio |
|----------------------------- |--------- |-------------------------------- |-------- |------------:|------------:|------------:|------------:|------:|--------:|----------:|----------:|---------:|-----------:|------------:|
| LinqComplexTypeMaterialized  | .NET 8.0 | Materialized (Complex Type)     | 1000000 |  9,449.3 μs |   155.95 μs |   145.88 μs |  9,469.5 μs |  1.00 |    0.02 |   62.5000 |   62.5000 |  62.5000 |  8389226 B |        1.00 |
| ZLinqComplexTypeMaterialized | .NET 8.0 | Materialized (Complex Type)     | 1000000 |  7,929.3 μs |   118.42 μs |   104.97 μs |  7,903.0 μs |  0.84 |    0.02 |   31.2500 |   31.2500 |  31.2500 |  4000088 B |        0.48 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqComplexTypeMaterialized  | .NET 9.0 | Materialized (Complex Type)     | 1000000 |  6,489.2 μs |   126.37 μs |   112.02 μs |  6,490.2 μs |  1.00 |    0.02 |   31.2500 |   31.2500 |  31.2500 |  4000231 B |        1.00 |
| ZLinqComplexTypeMaterialized | .NET 9.0 | Materialized (Complex Type)     | 1000000 |  7,433.8 μs |   145.44 μs |   203.88 μs |  7,413.3 μs |  1.15 |    0.04 |   31.2500 |   31.2500 |  31.2500 |  4000078 B |        1.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithIntsMaterialized     | .NET 8.0 | Materialized (int)              | 1000000 |  3,256.5 μs |    30.95 μs |    24.17 μs |  3,252.7 μs |  1.00 |    0.01 |   46.8750 |   39.0625 |  39.0625 |  4194919 B |        1.00 |
| ZLinqWithIntsMaterialized    | .NET 8.0 | Materialized (int)              | 1000000 |  1,854.9 μs |    18.40 μs |    16.31 μs |  1,851.7 μs |  0.57 |    0.01 |   17.5781 |   17.5781 |  17.5781 |  2000069 B |        0.48 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithIntsMaterialized     | .NET 9.0 | Materialized (int)              | 1000000 |  1,405.1 μs |    27.41 μs |    41.03 μs |  1,388.8 μs |  1.00 |    0.04 |   17.5781 |   17.5781 |  17.5781 |  2000220 B |        1.00 |
| ZLinqWithIntsMaterialized    | .NET 9.0 | Materialized (int)              | 1000000 |  1,716.0 μs |    17.87 μs |    15.84 μs |  1,713.5 μs |  1.22 |    0.04 |   17.5781 |   17.5781 |  17.5781 |  2000069 B |        1.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithStringsMaterialized  | .NET 8.0 | Materialized (string)           | 1000000 | 80,468.9 μs | 1,509.53 μs | 1,412.02 μs | 80,535.1 μs |  1.00 |    0.02 | 4000.0000 | 3833.3333 | 333.3333 | 64730003 B |        1.00 |
| ZLinqWithStringsMaterialized | .NET 8.0 | Materialized (string)           | 1000000 | 78,592.2 μs | 1,503.00 μs | 1,476.15 μs | 78,834.9 μs |  0.98 |    0.02 | 4000.0000 | 3857.1429 | 285.7143 | 55944355 B |        0.86 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithStringsMaterialized  | .NET 9.0 | Materialized (string)           | 1000000 | 75,185.8 μs | 1,492.38 μs | 2,613.78 μs | 75,074.4 μs |  1.00 |    0.05 | 4000.0000 | 3857.1429 | 285.7143 | 55944509 B |        1.00 |
| ZLinqWithStringsMaterialized | .NET 9.0 | Materialized (string)           | 1000000 | 74,261.8 μs | 1,436.35 μs | 2,662.37 μs | 75,174.6 μs |  0.99 |    0.05 | 4000.0000 | 3857.1429 | 285.7143 | 55944262 B |        1.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqComplexType              | .NET 8.0 | Non-materialized (Complex Type) | 1000000 |  6,203.5 μs |    50.82 μs |    42.44 μs |  6,203.2 μs |  1.00 |    0.01 | 1273.4375 |         - |        - | 16000155 B |        1.00 |
| ZLinqComplexType             | .NET 8.0 | Non-materialized (Complex Type) | 1000000 |  5,579.5 μs |   104.41 μs |   102.55 μs |  5,590.1 μs |  0.90 |    0.02 | 1273.4375 |         - |        - | 16000003 B |        1.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqComplexType              | .NET 9.0 | Non-materialized (Complex Type) | 1000000 |  5,901.1 μs |    76.75 μs |    71.80 μs |  5,915.7 μs |  1.00 |    0.02 | 1273.4375 |         - |        - | 16000152 B |        1.00 |
| ZLinqComplexType             | .NET 9.0 | Non-materialized (Complex Type) | 1000000 |  5,161.0 μs |    84.28 μs |    74.71 μs |  5,125.8 μs |  0.87 |    0.02 | 1273.4375 |         - |        - | 16000000 B |        1.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithInts                 | .NET 8.0 | Non-materialized (int)          | 1000000 |  1,324.3 μs |    19.83 μs |    18.54 μs |  1,326.0 μs |  1.00 |    0.02 |         - |         - |        - |      153 B |        1.00 |
| ZLinqWithInts                | .NET 8.0 | Non-materialized (int)          | 1000000 |    675.8 μs |     8.66 μs |     7.23 μs |    677.1 μs |  0.51 |    0.01 |         - |         - |        - |          - |        0.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithInts                 | .NET 9.0 | Non-materialized (int)          | 1000000 |  1,326.1 μs |    16.15 μs |    15.11 μs |  1,328.4 μs |  1.00 |    0.02 |         - |         - |        - |      152 B |        1.00 |
| ZLinqWithInts                | .NET 9.0 | Non-materialized (int)          | 1000000 |    470.3 μs |     6.99 μs |     6.19 μs |    472.1 μs |  0.35 |    0.01 |         - |         - |        - |          - |        0.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithStrings              | .NET 8.0 | Non-materialized (string)       | 1000000 | 17,310.9 μs |   294.03 μs |   260.65 μs | 17,315.0 μs |  1.00 |    0.02 | 3812.5000 |         - |        - | 47952164 B |        1.00 |
| ZLinqWithStrings             | .NET 8.0 | Non-materialized (string)       | 1000000 | 13,994.2 μs |   273.00 μs |   364.45 μs | 13,935.7 μs |  0.81 |    0.02 | 3812.5000 |         - |        - | 47952006 B |        1.00 |
|                              |          |                                 |         |             |             |             |             |       |         |           |           |          |            |             |
| LinqWithStrings              | .NET 9.0 | Non-materialized (string)       | 1000000 | 15,787.9 μs |   306.82 μs |   376.81 μs | 15,866.8 μs |  1.00 |    0.03 | 3812.5000 |         - |        - | 47952154 B |        1.00 |
| ZLinqWithStrings             | .NET 9.0 | Non-materialized (string)       | 1000000 | 13,310.0 μs |   248.09 μs |   254.77 μs | 13,259.4 μs |  0.84 |    0.03 | 3812.5000 |         - |        - | 47952001 B |        1.00 |
