using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common;
using System.Text.Json;

namespace FullVsPartialModelClassForJsonDeserialize;

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
  private string _jsonData;

  [GlobalSetup]
  public void Setup()
  {
    _jsonData = File.ReadAllText("data.json");
  }

  [Benchmark(Baseline = true)]
  public List<FullModel> DeserializeFullModel()
  {
    return JsonSerializer.Deserialize<List<FullModel>>(_jsonData);
  }

  [Benchmark]
  public List<PartialModel> DeserializePartialModel()
  {
    return JsonSerializer.Deserialize<List<PartialModel>>(_jsonData);
  }
}
