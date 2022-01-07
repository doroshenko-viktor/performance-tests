using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Lambdas
{


    public class Closures
    {
        private const int COLLECTION_SIZE = 1000000;
        public static void EnumerateWithClosure()
        {
            var multiplier = 2;
            var _ = Enumerable.Range(0, COLLECTION_SIZE).Select(x => x * multiplier).ToList();
        }

        public static void EnumerateWithoutClosure()
        {
            var _ = Enumerable.Range(0, COLLECTION_SIZE).Select(x => x * 2).ToList();
        }

        public static List<string> Filter(List<string> source, Func<string, bool> condition)
        {
            var result = new List<string>();

            foreach (var item in source)
            {
                if (condition(item))
                    result.Add(item);
            }

            return result;
        }

        public static List<string> Filter<T>(List<string> source, T context,
                                            Func<string, T, bool> condition)
        {
            var result = new List<string>();

            foreach (var item in source)
            {
                if (condition(item, context))
                    result.Add(item);
            }

            return result;
        }
    }

    [MemoryDiagnoser]
    public class ClosureTest
    {
        // [Benchmark(Baseline = true)]
        // public void EnumerateWithClosure()
        // {
        //     Closures.EnumerateWithClosure();
        // }

        // [Benchmark]
        // public void EnumerateWithoutClosure()
        // {
        //     Closures.EnumerateWithoutClosure();
        // }
        private readonly List<string> list_10 = Enumerable.Range(0, 10).Select(x => x.ToString()).ToList();
        private readonly List<string> list_100 = Enumerable.Range(0, 100).Select(x => x.ToString()).ToList();
        private readonly List<string> list_1_000 = Enumerable.Range(0, 1000).Select(x => x.ToString()).ToList();
        private readonly List<string> list_10_000 = Enumerable.Range(0, 10000).Select(x => x.ToString()).ToList();
        private readonly List<string> list_100_000 = Enumerable.Range(0, 100000).Select(x => x.ToString()).ToList();
        private readonly List<string> list_1_000_000 = Enumerable.Range(0, 1000000).Select(x => x.ToString()).ToList();

        [Benchmark]
        public void FilterLongStringClosure_10()
        {
            var length = 3;
            var result = Closures.Filter(list_10, s => s.Length > length);
        }

        [Benchmark]
        public void FilterLongStringClosureFixed_10()
        {
            var length = 3;
            var result = Closures.Filter(list_10, length, (s, lng) => s.Length > lng);
        }

        // [Benchmark]
        // public void FilterLongStringClosure_100()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_100, s => s.Length > length);
        // }

        // [Benchmark]
        // public void FilterLongStringClosureFixed_100()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_100, length, (s, lng) => s.Length > lng);
        // }

        // [Benchmark]
        // public void FilterLongStringClosure_1_000()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_1_000, s => s.Length > length);
        // }

        // [Benchmark]
        // public void FilterLongStringClosureFixed_1_000()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_1_000, length, (s, lng) => s.Length > lng);
        // }

        // [Benchmark]
        // public void FilterLongStringClosure_10_000()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_10_000, s => s.Length > length);
        // }

        // [Benchmark]
        // public void FilterLongStringClosureFixed_10_000()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_10_000, length, (s, lng) => s.Length > lng);
        // }

        // [Benchmark]
        // public void FilterLongStringClosure_100_000()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_100_000, s => s.Length > length);
        // }

        // [Benchmark]
        // public void FilterLongStringClosureFixed_100_000()
        // {
        //     var length = 3;
        //     var result = Closures.Filter(list_100_000, length, (s, lng) => s.Length > lng);
        // }

        [Benchmark]
        public void FilterLongStringClosure_1_000_000()
        {
            var length = 3;
            var result = Closures.Filter(list_1_000_000, s => s.Length > length);
        }

        [Benchmark]
        public void FilterLongStringClosureFixed_1_000_000()
        {
            var length = 3;
            var result = Closures.Filter(list_1_000_000, length, (s, lng) => s.Length > lng);
        }
    }
}