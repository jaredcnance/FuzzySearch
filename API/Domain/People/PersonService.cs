using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;

namespace API.Domain.People
{
    public interface IPersonService
    {
        /// <summary>
        /// Search for People matching the provided term.
        /// Returns a list of People orderd by similarity.
        /// </summary>
        Task<IEnumerable<Person>> SearchAsync(string term);
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _people;
        private readonly FuzzyComparerFactory _comparerFactory;

        public PersonService(
            IPersonRepository people,
            FuzzyComparerFactory comparerFactory)
        {
            _people = people;
            _comparerFactory = comparerFactory;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Person>> SearchAsync(string term)
        {
            var people = await _people.GetAsync();
            var comparer = _comparerFactory.GetComparer(term);
            var results = people.OrderBy(a => a.Name, comparer).ToList();
            return results;
        }
    }
}
