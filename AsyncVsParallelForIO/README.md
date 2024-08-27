```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method          | N   |       Mean |   Error |  StdDev |     Median | Ratio | Allocated | Alloc Ratio |
| --------------- | --- | ---------: | ------: | ------: | ---------: | ----: | --------: | ----------: |
| WithAsyncAwait  | 5   | 2,505.8 ms | 0.97 ms | 0.91 ms | 2,505.9 ms |  1.00 |   2.51 KB |        1.00 |
| WithTaskWhenAll | 5   |   501.6 ms | 0.45 ms | 0.42 ms |   501.5 ms |  0.20 |   2.75 KB |        1.10 |
| WithParallel    | 5   |   501.6 ms | 0.25 ms | 0.23 ms |   501.6 ms |  0.20 |   3.95 KB |        1.57 |
