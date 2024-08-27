```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method          | N     |     Mean |   Error |  StdDev |   Median | Ratio |    Gen0 |   Gen1 | Allocated | Alloc Ratio |
| --------------- | ----- | -------: | ------: | ------: | -------: | ----: | ------: | -----: | --------: | ----------: |
| WithIEnumerable | 10000 | 212.0 μs | 0.14 μs | 0.11 μs | 212.0 μs |  1.00 | 20.7520 |      - | 128.57 KB |        1.00 |
| WithList        | 10000 | 129.1 μs | 0.79 μs | 0.74 μs | 128.9 μs |  0.61 | 27.0996 | 3.6621 | 167.55 KB |        1.30 |
