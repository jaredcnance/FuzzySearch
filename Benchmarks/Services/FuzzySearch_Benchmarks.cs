using System.Collections.Generic;
using API.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Code;
using Bogus;

namespace Benchmarks.Services
{
    [MemoryDiagnoser]
    public class FuzzySearch_Benchmarks
    {
        private readonly LevenshteinFuzzySearch _levenshteinFuzzySearch = new LevenshteinFuzzySearch();

        [ParamsSource(nameof(String1Values))]
        public RandomString String1 { get; set; }

        [ParamsSource(nameof(String2Values))]
        public RandomString String2 { get; set; }

        public static IEnumerable<IParam> String1Values()
        {
            yield return new RandomStringParam(new RandomString(10));
            yield return new RandomStringParam(new RandomString(100));
            yield return new RandomStringParam(new RandomString(1000));
            yield return new RandomStringParam(new RandomString(10000));
        }

        public static IEnumerable<IParam> String2Values()
        {
            yield return new RandomStringParam(new RandomString(100));
        }

        [Benchmark]
        public int LevenshteinDistance() => _levenshteinFuzzySearch.ComputeSimilarity(String1.Value, String2.Value);
    }

    /// <remarks>
    /// For details on non compile-time constant params, see https://github.com/dotnet/BenchmarkDotNet/issues/571
    /// </remarks>
    public class RandomStringParam : IParam
    {
        private readonly RandomString _value;

        public RandomStringParam(RandomString value) => this._value = value;

        public object Value => _value;

        public string DisplayText => $"{nameof(RandomString)}[{_value.Length}]";

        public string ToSourceCode() => $"new RandomString({_value.Length}, \"{_value.Value}\")";
    }

    public struct RandomString
    {
        private static readonly Faker _faker = new Faker();

        public string Value { get; set; }
        public int Length { get; set; }

        public RandomString(int length)
        {
            Value = _faker.Random.AlphaNumeric(length);
            Length = length;
        }

        public RandomString(int length, string value)
        {
            Value = value;
            Length = length;
        }
    }
}
