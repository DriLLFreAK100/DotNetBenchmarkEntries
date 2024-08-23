```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```
| Method   | Mean      | Error     | StdDev    | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------- |----------:|----------:|----------:|------:|--------:|----------:|------------:|
| If       | 0.7738 ns | 0.0098 ns | 0.0087 ns |  1.00 |    0.02 |         - |          NA |
| IfElseIf | 0.3141 ns | 0.0021 ns | 0.0018 ns |  0.41 |    0.00 |         - |          NA |
| Switch   | 0.3588 ns | 0.0004 ns | 0.0003 ns |  0.46 |    0.01 |         - |          NA |
