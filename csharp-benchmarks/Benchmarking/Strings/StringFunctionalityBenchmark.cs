using BenchmarkDotNet.Attributes;

namespace Benchmarking.Strings
{
    [MemoryDiagnoser]
    public class StringFunctionalityBenchmark
    {
        private readonly StringsFunctionality _func = new StringsFunctionality();

        [Benchmark(Baseline = true)]
        public void TestBuildString100()
        {
            _func.BuildString(100);
        }

        [Benchmark()]
        public void TestBuildString1000()
        {
            _func.BuildString(1000);
        }

        [Benchmark()]
        public void TestBuildStringBuilder100()
        {
            _func.BuildStringBuilder(100);
        }

        [Benchmark()]
        public void TestBuildStringBuilder1000()
        {
            _func.BuildStringBuilder(1000);
        }
    }
}