using BenchmarkDotNet.Running;
using Benchmarking.Collections;
using Benchmarking.LayersDtoConversion;
using Benchmarking.NameParser;
using Benchmarking.Strings;

namespace Benchmarking
{
	class Program
	{
		static void Main(string[] args)
		{
			// var summary = BenchmarkRunner.Run<NameParserBenchmarks>();
			// var summary = BenchmarkRunner.Run<StringFunctionalityBenchmark>();
			// var summary = BenchmarkRunner.Run<LayersFunctionalityBenchmark>();
			var summary = BenchmarkRunner.Run<ImmutableCollectionsBenchmark>();
		}
	}
}
