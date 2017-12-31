using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Domain.People
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAsync();
        Task<int> CreateAsync(Person person);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _dbContext;

        public PersonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person>> GetAsync() => await _dbContext.People.ToListAsync();

        public async Task<int> CreateAsync(Person person)
        {
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();
            return person.Id;
        }
    }
}
