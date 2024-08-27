```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method   |      Mean |     Error |    StdDev | Ratio | Allocated | Alloc Ratio |
| -------- | --------: | --------: | --------: | ----: | --------: | ----------: |
| If       | 0.7543 ns | 0.0024 ns | 0.0022 ns |  1.00 |         - |          NA |
| IfElseIf | 0.3155 ns | 0.0040 ns | 0.0038 ns |  0.42 |         - |          NA |
| Switch   | 0.3572 ns | 0.0018 ns | 0.0014 ns |  0.47 |         - |          NA |
