using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Common;

namespace IfVsSwitch;

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
  private Student _student = new()
  {
    Id = 1,
    Age = 10,
    Name = "Test",
  };

  [Benchmark(Baseline = true)]
  public void If()
  {
    if (_student.Age == 1)
    {
      return;
    }

    if (_student.Age == 2)
    {
      return;
    }

    if (_student.Age == 3)
    {
      return;
    }
    if (_student.Age == 4)
    {
      return;
    }

    if (_student.Age == 5)
    {
      return;
    }

    if (_student.Age == 6)
    {
      return;
    }

    if (_student.Age == 7)
    {
      return;
    }

    if (_student.Age == 8)
    {
      return;
    }

    if (_student.Age == 9)
    {
      return;
    }
  }

  [Benchmark]
  public void IfElseIf()
  {
    if (_student.Age == 1)
    {
    }
    else if (_student.Age == 2)
    {
    }
    else if (_student.Age == 3)
    {
    }
    else if (_student.Age == 4)
    {
    }
    else if (_student.Age == 5)
    {
    }
    else if (_student.Age == 6)
    {
    }
    else if (_student.Age == 7)
    {
    }
    else if (_student.Age == 8)
    {
    }
    else if (_student.Age == 9)
    {
    }
    else
    {
    }
  }

  [Benchmark]
  public void Switch()
  {
    switch (_student.Age)
    {
      case 1:
        break;
      case 2:
        break;
      case 3:
        break;
      case 4:
        break;
      case 5:
        break;
      case 6:
        break;
      case 7:
        break;
      case 8:
        break;
      case 9:
        break;
      default:
        break;
    }
  }
}

public class Student
{
  public int Id { get; set; }

  public int Age { get; set; }

  public string Name { get; set; }
}