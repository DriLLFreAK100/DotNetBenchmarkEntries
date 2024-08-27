using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common;

namespace IEnumerableVsList;

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
  private IEnumerable<Student> _enrolledStudents = [];

  [Params(10000)]
  public int N;

  [GlobalSetup]
  public void Setup()
  {
    List<Student> students = [];

    for (var i = 0; i < N; i++)
    {
      students.Add(new()
      {
        Id = i,
        Name = $"name {i}",
        IsEnrolled = i % 2 == 0,
      });
    }

    _enrolledStudents = students.Where(x => x.IsEnrolled);
  }

  [Benchmark(Baseline = true)]
  public void WithIEnumerable()
  {
    var input = _enrolledStudents;
    Loop(input);
  }

  [Benchmark]
  public void WithList()
  {
    var input = _enrolledStudents.ToList();
    Loop(input);
  }

  private static List<string> Loop(IEnumerable<Student> data)
  {
    data.Any(x => x.IsEnrolled);
    data.First();
    data.Count();
    data.Sum(x => x.Id);
    return data.Select(d => d.Name).ToList();
  }
}

public class Student
{
  public int Id { get; set; }

  public bool IsEnrolled { get; set; }

  public string Name { get; set; }
}