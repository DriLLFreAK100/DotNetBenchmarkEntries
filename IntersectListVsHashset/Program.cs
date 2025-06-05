using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common;

namespace IntersectListVsHashset;

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
  private readonly List<Student> _listA = [];
  private readonly List<int> _targetedIds = [
    0,
    125,
    250,
    375,
    500,
    625,
    750,
    875,
    999
  ];
  private HashSet<int> _targetedIdsHashSet = [];

  [Params(1_000)]
  public int N;

  [GlobalSetup]
  public void Setup()
  {
    var random = new Random();

    for (var i = 0; i < N; i++)
    {
      _listA.Add(new()
      {
        Id = i,
        Name = $"name {i}",
        Age = random.Next(12, 40),
        IsEnrolled = i % 2 == 0,
      });
    }

    _targetedIdsHashSet = _targetedIds.ToHashSet();
  }

  [Benchmark(Baseline = true)]
  public void ListIntersectListAny()
  {
    _listA
      .Select(x => x.Id)
      .Intersect(_targetedIds)
      .Any();
  }

  [Benchmark]
  public void ListIntersectHashSetAny()
  {
    _listA
      .Select(x => x.Id)
      .Intersect(_targetedIdsHashSet)
      .Any();
  }

  [Benchmark]
  public void ListAnyMatchHashSet()
  {
    _listA
      .Select(x => x.Id)
      .Any(x => _targetedIdsHashSet.Contains(x));
  }
}

public class Student
{
  public int Id { get; set; }

  public bool IsEnrolled { get; set; }

  public int Age { get; set; }

  public string Name { get; set; }
}