
using System.Linq;
using AutoFixture;
using BenchmarkDotNet.Attributes;
using LangBasics;

namespace PerformanceTests;

[MemoryDiagnoser]
public class ClosuresTests
{
    private readonly IFixture _fixture;
    private const int _amount = 10000000;

    public ClosuresTests()
    {

    }

    [Benchmark(Baseline = true)]
    public void TestTransformNumbersWithoutStatic()
    {
        var numbers = Enumerable.Range(0, _amount);
        var closures = new Closures();
        var _ = closures.TransformNumbersWithoutStatic(numbers).ToList();
    }

    [Benchmark()]
    public void TestTransformNumbersWithStatic()
    {
        var numbers = Enumerable.Range(0, _amount);
        var closures = new Closures();
        var _ = closures.TransformNumbersWithStatic(numbers).ToList();
    }
}