using API.Services;
using Xunit;

namespace Tests
{
    public class LevenshteinFuzzySearch_Tests
    {
        [Theory]
        [InlineData("abcdef", "abcdef", 0)]
        [InlineData("abcdef", "abcfed", 2)]
        [InlineData("abcdef", "fedcba", 6)]
        public void Can_Compute_Levenshtein_Distance(string s1, string s2, int expectedDistance)
        {
            // arrange
            var service = new LevenshteinFuzzySearch();

            // act
            var actualDistance = service.ComputeSimilarity(s1, s2);

            // assert
            Assert.Equal(expectedDistance, actualDistance);
        }
    }
}
