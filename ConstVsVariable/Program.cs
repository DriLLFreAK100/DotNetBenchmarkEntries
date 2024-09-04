using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common;

namespace ConstVsVariable;

public class Program
{
  public static void Main(string[] args)
  {
    BenchmarkRunner.Run<TestEntry>(Configs.BenchmarkSettings);
  }
}

[SimpleJob]
public class TestEntry
{
  [Benchmark(Baseline = true)]
  public void Const()
  {
    const string text = "Hello World";
    text.Substring(0, 1);
  }

  [Benchmark]
  public void Variable()
  {
    string text = "Hello World";
    text.Substring(0, 1);
  }
}
