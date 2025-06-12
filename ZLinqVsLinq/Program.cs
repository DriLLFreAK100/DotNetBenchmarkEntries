using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Common;
using ZLinq;

namespace IfVsSwitch;

public class Program
{
    public static void Main(string[] args)
    {
        var config = Configs.BenchmarkSettings
            .AddJob(Job.Default.WithRuntime(CoreRuntime.Core80))
            .AddJob(Job.Default.WithRuntime(CoreRuntime.Core90));
            
        BenchmarkRunner.Run<TestEntry>(config);
    }
}

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory),
CategoriesColumn]
public class TestEntry
{

    private List<Student> _students = [];

    private List<int> _ints = [];

    private List<string> _strings = [];

    [Params(1000_000)]
    public int N;

    [GlobalSetup]
    public void Setup()
    {
        _students = [
            .. Enumerable.Range(0, N)
            .Select(i =>
                new Student
                {
                    Id = i,
                    Name = $"name {i}",
                    IsEnrolled = i % 2 == 0,
                })
        ];

        _ints = [.. Enumerable.Range(0, N)];

        _strings = [.. Enumerable.Range(0, N).Select(i => $"string {i}")];
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Non-materialized (Complex Type)")]
    public void LinqComplexType()
    {
        foreach (var item in _students
            .Where(s => s.IsEnrolled)
            .Select(s => new { s.Id, s.Name }))
        { 
            // Do nothing with item
        }
    }

    [Benchmark, BenchmarkCategory("Non-materialized (Complex Type)")]
    public void ZLinqComplexType()
    {
        foreach (var item in _students
            .AsValueEnumerable()
            .Where(s => s.IsEnrolled)
            .Select(s => new { s.Id, s.Name }))
        {
            // Do nothing with item
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Non-materialized (int)")]
    public void LinqWithInts()
    {
        foreach (var item in _ints
            .Where(i => i % 2 == 0)
            .Select(i => i * 2))
        {
            // Do nothing with item
        }
    }

    [Benchmark, BenchmarkCategory("Non-materialized (int)")]
    public void ZLinqWithInts()
    {
        foreach (var item in _ints
            .AsValueEnumerable()
            .Where(i => i % 2 == 0)
            .Select(i => i * 2))
        {
            // Do nothing with item
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Non-materialized (string)")]
    public void LinqWithStrings()
    {
        foreach (var item in _strings
            .Where(s => s.Length > 10)
            .Select(s => s.ToUpper()))
        {
            // Do nothing with item
        }
    }

    [Benchmark, BenchmarkCategory("Non-materialized (string)")]
    public void ZLinqWithStrings()
    {
        foreach (var item in _strings
            .AsValueEnumerable()
            .Where(s => s.Length > 10)
            .Select(s => s.ToUpper()))
        {
            // Do nothing with item
        }
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Materialized (Complex Type)")]
    public List<string> LinqComplexTypeMaterialized()
    {
        return _students
            .Where(s => s.IsEnrolled)
            .Select(s => s.Name )
            .ToList();
    }

    [Benchmark, BenchmarkCategory("Materialized (Complex Type)")]
    public List<string> ZLinqComplexTypeMaterialized()
    {
        return _students
            .AsValueEnumerable()
            .Where(s => s.IsEnrolled)
            .Select(s => s.Name)
            .ToList();
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Materialized (int)")]
    public List<int> LinqWithIntsMaterialized()
    {
        return _ints
            .Where(i => i % 2 == 0)
            .Select(i => i * 2)
            .ToList();
    }

    [Benchmark, BenchmarkCategory("Materialized (int)")]
    public List<int> ZLinqWithIntsMaterialized()
    {
        return _ints
            .AsValueEnumerable()
            .Where(i => i % 2 == 0)
            .Select(i => i * 2)
            .ToList();
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Materialized (string)")]
    public List<string> LinqWithStringsMaterialized()
    {
        return _strings
            .Where(s => s.Length > 10)
            .Select(s => s.ToUpper())
            .ToList();
    }

    [Benchmark, BenchmarkCategory("Materialized (string)")]
    public List<string> ZLinqWithStringsMaterialized()
    {
        return _strings
            .AsValueEnumerable()
            .Where(s => s.Length > 10)
            .Select(s => s.ToUpper())
            .ToList();
    }
}

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool IsEnrolled { get; set; }
}