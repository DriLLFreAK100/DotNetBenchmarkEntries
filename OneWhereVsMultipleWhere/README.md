```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method        | N       | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0    | Gen1    | Gen2    | Allocated | Alloc Ratio |
|-------------- |-------- |----------:|----------:|----------:|------:|--------:|--------:|--------:|--------:|----------:|------------:|
| OneWhere      | 1000000 |  8.586 ms | 0.1569 ms | 0.1611 ms |  1.00 |    0.03 | 31.2500 | 31.2500 | 31.2500 |      4 MB |        1.00 |
| MultipleWhere | 1000000 | 13.093 ms | 0.1730 ms | 0.1618 ms |  1.53 |    0.03 | 31.2500 | 31.2500 | 31.2500 |      4 MB |        1.00 |
