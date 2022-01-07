using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Lambdas
{
    public struct ReferenceObject : IComparable<ReferenceObject>
    {
        public int Value { get; set; }

        public int CompareTo([AllowNull] ReferenceObject other)
        {
            if (other is ReferenceObject { Value: { } } && Value is { })
            {
                if (other.Value == Value)
                {
                    return 0;
                }
                return other.Value > Value ? -1 : 1;
            }
            return -1;
        }
    }

    public interface IPredicate<T>
    {
        bool Check(T val);
    }

    public class CustomFilterPredicate<T> : IPredicate<T> where T : IComparable<T>
    {
        private readonly T _valueToCompare;

        public CustomFilterPredicate(T valueToCompare)
        {
            _valueToCompare = valueToCompare;
        }

        public bool Check(T val)
        {
            return val.CompareTo(_valueToCompare) > 0;
        }
    }

    public static class CustomLinq
    {
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> values, IPredicate<T> predicate) where T : IComparable<T>
        {
            foreach (var val in values)
            {
                if (predicate.Check(val))
                {
                    yield return val;
                }
            }
        }
    }

    public class OperationsWithClosures
    {
        public static void WithPredicateAndCustomWhere<T>(IList<T> values, T closureVal) where T : IComparable<T>
        {
            var _ = values.CustomWhere(new CustomFilterPredicate<T>(closureVal)).ToList();
        }
        public static void WithStandardLinqTwoWhere<T>(IList<T> values, T closureValue) where T : IComparable<T>
        {
            var _ = values.Where(x => x.CompareTo(closureValue) > 0).Select(x =>
            {
                return x;
            }).ToList();
        }
        public static void WithStandardLinq<T>(IList<T> values, T closureValue) where T : IComparable<T>
        {
            var _ = values.Where(x => x.CompareTo(closureValue) > 0).ToList();
        }

        public static void WithPredicateOnly<T>(IList<T> values, T value) where T : IComparable<T>
        {
            var resultList = new List<T>(values.Count);
            var predicate = new CustomFilterPredicate<T>(value);
            foreach (var val in values)
            {
                if (predicate.Check(val))
                {
                    resultList.Add(val);
                }
            }
        }

        public static void WithManualCode<T>(IList<T> values, T closureValue) where T : IComparable<T>
        {
            var resultList = new List<T>(values.Count);
            foreach (var val in values)
            {
                if (val.CompareTo(closureValue) > 0)
                {
                    resultList.Add(val);
                }
            }
        }


        public static void WithStandardLinqWithoutClosure(IList<ReferenceObject> values)
        {
            var _ = values.Where(x => x.Value > 2).ToList();
        }
        public static void WithStandardLinqWithoutClosure(IList<int> values)
        {
            var _ = values.Where(x => x > 2).ToList();
        }
    }

    [MemoryDiagnoser]
    public class CustomClosureTest
    {
        private readonly List<int> list_100_000 = Enumerable.Range(0, 100000).ToList();
        private readonly List<ReferenceObject> reference_list_100_000 = Enumerable.Range(0, 100000)
            .Select(x => new ReferenceObject { Value = x }).ToList();
        private readonly int _closureValue = 2;
        private readonly ReferenceObject _closureValueREF = new ReferenceObject { Value = 2 };

        [Benchmark]
        public void Custom_1_000_000()
        {
            OperationsWithClosures.WithPredicateAndCustomWhere(list_100_000, _closureValue);
        }
        [Benchmark]
        public void Linq_1_000_000()
        {
            OperationsWithClosures.WithStandardLinq(list_100_000, _closureValue);
        }
        [Benchmark]
        public void OnlyPredicate_1_000_000()
        {
            OperationsWithClosures.WithPredicateOnly(list_100_000, _closureValue);
        }

        [Benchmark]
        public void Manual_1_000_000()
        {
            OperationsWithClosures.WithManualCode(list_100_000, _closureValue);
        }
        [Benchmark]
        public void NoClosure_1_000_000()
        {
            OperationsWithClosures.WithStandardLinqWithoutClosure(list_100_000);
        }
        [Benchmark]
        public void Custom_1_000_000_REF()
        {
            OperationsWithClosures.WithPredicateAndCustomWhere(reference_list_100_000, _closureValueREF);
        }
        [Benchmark]
        public void Linq_1_000_000_REF()
        {
            OperationsWithClosures.WithStandardLinq(reference_list_100_000, _closureValueREF);
        }
        [Benchmark]
        public void OnlyPredicate_1_000_000_REF()
        {
            OperationsWithClosures.WithPredicateOnly(reference_list_100_000, _closureValueREF);
        }

        [Benchmark]
        public void Manual_1_000_000_REF()
        {
            OperationsWithClosures.WithManualCode(reference_list_100_000, _closureValueREF);
        }
        [Benchmark]
        public void NoClosure_1_000_000_REF()
        {
            OperationsWithClosures.WithStandardLinqWithoutClosure(reference_list_100_000);
        }
        // [Benchmark]
        // public void TwoWhere()
        // {
        //     OperationsWithClosures.WithStandardLinqTwoWhere(list_100_000, 2);
        // }
        // [Benchmark]
        // public void OneWhere()
        // {
        //     OperationsWithClosures.WithStandardLinq(list_100_000, 2);
        // }
    }
}