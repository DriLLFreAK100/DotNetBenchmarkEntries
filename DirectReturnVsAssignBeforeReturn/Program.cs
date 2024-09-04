using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common;

namespace DirectReturnVsAssignBeforeReturn;

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
  [Params(10000)]
  public int N;

  [Benchmark(Baseline = true)]
  public List<Student> DirectReturn()
  {
    return CreateStudents();
  }

  [Benchmark]
  public List<Student> AssignBeforeReturn()
  {
    var result = CreateStudents();
    return result;
  }

  private List<Student> CreateStudents() => Enumerable
    .Range(0, N)
    .Select((_, index) => new Student() { Id = index })
    .ToList();
}

public class Student
{
  public int Id { get; set; }

  public bool IsEnrolled { get; set; }

  public string Name { get; set; }
}