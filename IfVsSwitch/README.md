```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.2 (8.0.224.6711), Arm64 RyuJIT AdvSIMD


```

| Method   |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD | Allocated | Alloc Ratio |
| -------- | --------: | --------: | --------: | --------: | ----: | ------: | --------: | ----------: |
| If       | 0.7711 ns | 0.0200 ns | 0.0177 ns | 0.7635 ns |  1.00 |    0.03 |         - |          NA |
| IfElseIf | 0.3147 ns | 0.0027 ns | 0.0025 ns | 0.3145 ns |  0.41 |    0.01 |         - |          NA |
| Switch   | 0.3586 ns | 0.0005 ns | 0.0005 ns | 0.3587 ns |  0.47 |    0.01 |         - |          NA |
