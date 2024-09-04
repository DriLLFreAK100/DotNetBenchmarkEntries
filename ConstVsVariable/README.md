```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method   |     Mean |     Error |    StdDev |   Median | Ratio |   Gen0 | Allocated | Alloc Ratio |
| -------- | -------: | --------: | --------: | -------: | ----: | -----: | --------: | ----------: |
| Const    | 3.655 ns | 0.0084 ns | 0.0074 ns | 3.655 ns |  1.00 | 0.0038 |      24 B |        1.00 |
| Variable | 3.662 ns | 0.0251 ns | 0.0234 ns | 3.660 ns |  1.00 | 0.0038 |      24 B |        1.00 |
