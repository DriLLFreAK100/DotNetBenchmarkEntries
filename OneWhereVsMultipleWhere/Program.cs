using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace OneWhereVsMultipleWhere;

public class Program
{
  public static void Main(string[] args)
  {
    BenchmarkRunner.Run<TestEntry>(
      DefaultConfig.Instance
        .AddDiagnoser(
          MemoryDiagnoser.Default,
          EventPipeProfiler.Default)
    );
  }
}

[SimpleJob]
public class TestEntry
{
  private List<Student> _students = [];

  [Params(1_000_000)]
  public int N;

  [GlobalSetup]
  public void Setup()
  {
    var random = new Random();

    for (var i = 0; i < N; i++)
    {
      _students.Add(new()
      {
        Id = i,
        Name = $"name {i}",
        Age = random.Next(12, 40),
        IsEnrolled = i % 2 == 0,
      });
    }
  }

  [Benchmark(Baseline = true)]
  public void OneWhere()
  {
    _students
      .Where(x =>
        x.IsEnrolled
        && x.Age >= 21
        && x.Age < 30)
      .ToList();
  }

  [Benchmark]
  public void MultipleWhere()
  {
    _students
      .Where(x => x.IsEnrolled)
      .Where(x => x.Age >= 21)
      .Where(x => x.Age < 30)
      .ToList();
  }
}

public class Student
{
  public int Id { get; set; }

  public bool IsEnrolled { get; set; }

  public int Age { get; set; }

  public string Name { get; set; }
}