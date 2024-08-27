```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method          | N   |         Mean |     Error |    StdDev |       Median | Ratio |   Gen0 | Allocated | Alloc Ratio |
| --------------- | --- | -----------: | --------: | --------: | -----------: | ----: | -----: | --------: | ----------: |
| WithAsyncAwait  | 200 | 1,155.537 ms | 6.0527 ms | 5.3656 ms | 1,155.747 ms | 1.000 |      - |  52.78 KB |        1.00 |
| WithTaskWhenAll | 200 |     5.944 ms | 0.0311 ms | 0.0276 ms |     5.943 ms | 0.005 | 7.8125 |  56.02 KB |        1.06 |
| WithParallel    | 200 |   114.234 ms | 0.6321 ms | 0.5604 ms |   114.182 ms | 0.099 |      - |  77.63 KB |        1.47 |
