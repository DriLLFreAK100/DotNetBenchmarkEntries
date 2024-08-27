using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common;

namespace AsyncVsParallelForIO;

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
  [Params(200)]
  public int N;

  private IEnumerable<Task> networkCallTasks = [];

  [GlobalSetup]
  public void Setup()
  {
    networkCallTasks = Enumerable
      .Range(0, N)
      .Select(_ => MockNetworkCall());
  }


  [Benchmark(Baseline = true)]
  public async Task WithAsyncAwait()
  {
    foreach (var task in networkCallTasks)
    {
      await task;
    }
  }

  [Benchmark]
  public async Task WithTaskWhenAll()
  {
    await Task.WhenAll(networkCallTasks);
  }

  [Benchmark]
  public async Task WithParallel()
  {
    await Parallel.ForEachAsync(
      networkCallTasks,
      async (task, token) =>
      {
        await task;
      });

  }

  private static async Task MockNetworkCall()
  {
    await Task.Delay(5);
  }
}
