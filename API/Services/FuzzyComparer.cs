using System;
using System.Collections.Generic;

namespace API.Services
{
    public class FuzzyComparer : IComparer<string>
    {
        private readonly string _comparisonTarget;
        private readonly IStringSimilarityService _stringSimilarityService;

        public FuzzyComparer(string comparisonTarget, IStringSimilarityService stringSimilarityService)
        {
            _comparisonTarget = comparisonTarget;
            _stringSimilarityService = stringSimilarityService;
        }

        /// <inheritdoc />
        /// 
        /// <exception cref="ArgumentNullException" />
        public int Compare(string str1, string str2)
        {
            if (str1 == null)
                throw new ArgumentNullException(nameof(str1), "Cannot perform similarty comparison on null string");

            if (str2 == null)
                throw new ArgumentNullException(nameof(str2), "Cannot perform similarty comparison on null string");

            var distance1 = _stringSimilarityService.ComputeSimilarity(_comparisonTarget, str1);
            var distance2 = _stringSimilarityService.ComputeSimilarity(_comparisonTarget, str2);

            return (distance1 > distance2) ? 1
                : (distance1 < distance2)
                    ? -1
                    : 0;
        }
    }
}
