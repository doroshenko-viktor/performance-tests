using System.Collections.Immutable;
using System.Linq;

namespace Benchmarking.LayersDtoConversion
{
	public class ImmutableCollections
	{
		public static void CreationOfImmutableCollection()
		{
			var col = Enumerable.Range(0, 10000)
			.Select(x => x * 2)
			.ToImmutableArray();
		}

		public static void CreationOfMutableCollection()
		{
			var col = Enumerable.Range(0, 10000)
			.Select(x => x * 2)
			.ToArray();
		}
	}
}