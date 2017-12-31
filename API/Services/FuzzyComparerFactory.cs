using System.Collections.Generic;

namespace API.Services
{
    public class FuzzyComparerFactory
    {
        private readonly IStringSimilarityService _similarityService;

        public FuzzyComparerFactory(IStringSimilarityService similarityService)
        {
            _similarityService = similarityService;
        }

        public IComparer<string> GetComparer(string comparisonTarget)
            => new FuzzyComparer(comparisonTarget, _similarityService);
    }
}
