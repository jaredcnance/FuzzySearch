using System;

namespace API.Services
{
    public interface IStringSimilarityService
    {
        /// <summary>
        /// Gets a number that indicates how similar two stings are. The smaller the number, the more similar they are
        /// </summary>
        int ComputeSimilarity(string str1, string str2);
    }

    public class LevenshteinFuzzySearch : IStringSimilarityService
    {
        /// <inheritdoc />
        public int ComputeSimilarity(string str1, string str2) => GetLevenshteinDistance(str1, str2);

        /// <remarks>
        /// Adapted from the implementation by Lasse Johansen.
        /// See the original work at http://web.archive.org/web/20110720094521/http://www.merriampark.com/ldcsharp.htm
        /// </remarks>
        public int GetLevenshteinDistance(string str1, string str2)
        {
            str1 = str1.ToLowerInvariant();
            str2 = str2.ToLowerInvariant();

            var n = str1.Length;

            var m = str2.Length;

            var d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0) return m;
            if (m == 0) return n;

            // Step 2
            for (var i = 0; i <= n; d[i, 0] = i++) ;
            for (var j = 0; j <= m; d[0, j] = j++) ;

            // Step 3
            for (var i = 1; i <= n; i++)
            {
                //Step 4
                for (var j = 1; j <= m; j++)
                {
                    // Step 5
                    var cost = (str2.Substring(j - 1, 1) == str1.Substring(i - 1, 1) ? 0 : 1);

                    // Step 6
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            // Step 7
            return d[n, m];
        }
    }
}
