using BenchmarkDotNet.Running;
using Benchmarks.Services;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args) => BenchmarkRunner.Run<FuzzySearch_Benchmarks>();
    }
}
