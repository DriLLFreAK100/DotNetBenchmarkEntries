# System.Text.Json Deserialization Benchmark: Full vs. Partial Model

This benchmark test evaluates the performance characteristics of `System.Text.Json` when deserializing the same JSON data into two different C# model classes:

1.  **`FullModel`**: A C# class that represents the complete structure of the JSON data, including all fields and nested objects.
2.  **`PartialModel`**: A C# class that represents a subset of the JSON data. It maintains the nested structure but only includes a limited number of properties (at most 3 per subclass) from the original JSON.

The primary goal is to compare the deserialization speed (mean execution time) and memory allocation (`Allocated` memory, `Gen0` collections) between these two approaches. This can help understand the overhead and benefits of deserializing only necessary data versus deserializing the entire payload.

The benchmark results below show these comparisons.

```

BenchmarkDotNet v0.14.0, macOS Sequoia 15.4.1 (24E263) [Darwin 24.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method                  |     Mean |   Error |  StdDev |   Median | Ratio |   Gen0 | Allocated | Alloc Ratio |
| ----------------------- | -------: | ------: | ------: | -------: | ----: | -----: | --------: | ----------: |
| DeserializeFullModel    | 131.5 μs | 0.52 μs | 0.49 μs | 131.4 μs |  1.00 | 0.7324 |   5.21 KB |        1.00 |
| DeserializePartialModel | 132.1 μs | 0.56 μs | 0.52 μs | 132.2 μs |  1.00 | 0.2441 |   2.46 KB |        0.47 |
