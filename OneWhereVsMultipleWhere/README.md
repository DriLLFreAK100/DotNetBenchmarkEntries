```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method        | N       |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |     Gen0 |     Gen1 |     Gen2 | Allocated | Alloc Ratio |
| ------------- | ------- | -------: | -------: | -------: | -------: | ----: | ------: | -------: | -------: | -------: | --------: | ----------: |
| OneWhere      | 1000000 | 14.44 ms | 1.400 ms | 4.128 ms | 16.08 ms |  1.10 |    0.49 | 375.0000 | 375.0000 | 375.0000 |      4 MB |        1.00 |
| MultipleWhere | 1000000 | 16.81 ms | 1.201 ms | 3.206 ms | 18.82 ms |  1.28 |    0.49 | 375.0000 | 375.0000 | 375.0000 |      4 MB |        1.00 |
