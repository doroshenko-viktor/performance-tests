using BenchmarkDotNet.Attributes;
using Benchmarking.LayersDtoConversion;

namespace Benchmarking.Collections
{
	[MemoryDiagnoser]
	public class ImmutableCollectionsBenchmark
	{
		[Benchmark(Baseline = true)]
		public void Immutable()
		{
			ImmutableCollections.CreationOfImmutableCollection();
		}

		[Benchmark]
		public void Mutable()
		{
			ImmutableCollections.CreationOfMutableCollection();
		}
	}
}