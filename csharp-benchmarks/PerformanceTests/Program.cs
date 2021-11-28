using BenchmarkDotNet.Running;
using PerformanceTests;

Console.WriteLine("test start");
var summary = BenchmarkRunner.Run<ClosuresTests>();
Console.WriteLine(summary);
