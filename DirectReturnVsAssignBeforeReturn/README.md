```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method             | N     |     Mean |   Error |  StdDev |   Median | Ratio |    Gen0 |    Gen1 |    Gen2 | Allocated | Alloc Ratio |
| ------------------ | ----- | -------: | ------: | ------: | -------: | ----: | ------: | ------: | ------: | --------: | ----------: |
| DirectReturn       | 10000 | 424.1 μs | 0.36 μs | 0.32 μs | 424.1 μs |  1.00 | 83.0078 | 41.5039 | 41.5039 | 568.95 KB |        1.00 |
| AssignBeforeReturn | 10000 | 425.1 μs | 1.77 μs | 1.57 μs | 424.6 μs |  1.00 | 83.0078 | 41.5039 | 41.5039 | 568.95 KB |        1.00 |
