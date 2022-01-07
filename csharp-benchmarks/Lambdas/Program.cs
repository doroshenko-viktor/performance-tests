using System;
using BenchmarkDotNet.Running;

namespace Lambdas
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("RUNNING BENCHMARK");
            // var summary = BenchmarkRunner.Run<ClosureTest>();
            var summary = BenchmarkRunner.Run<CustomClosureTest>();
        }
    }
}
