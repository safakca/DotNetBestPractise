using BenchmarkDotNet.Running;

namespace Benchmark;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        BenchmarkRunner.Run<BenchmarkService>();
    }
}