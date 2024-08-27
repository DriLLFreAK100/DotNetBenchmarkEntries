using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace Common;

public static class Configs
{
  public readonly static ManualConfig BenchmarkSettings = DefaultConfig.Instance
    .AddDiagnoser(
      MemoryDiagnoser.Default,
      EventPipeProfiler.Default)
    .AddColumn(StatisticColumn.Median);
}
