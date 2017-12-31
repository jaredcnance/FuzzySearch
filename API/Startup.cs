using API.Data;
using API.Domain.People;
using API.Services;
using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Person = API.Domain.People.Person;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            services.AddSingleton<FuzzyComparerFactory>();
            services.AddScoped<IStringSimilarityService, LevenshteinFuzzySearch>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
        }

        public void Configure(
            IApplicationBuilder app,
            ILoggerFactory loggerFactory,
            IPersonRepository personRepository,
            AppDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
            app.UseMvc();

            SeedPeople(personRepository);
        }

        private static void SeedPeople(IPersonRepository personRepository)
        {
            const int numberOfPeople = 5000;

            var faker = new Faker<Person>();
            faker.RuleFor(a => a.Name, f => f.Person.FullName);

            for (var i = 0; i < numberOfPeople; i++)
                personRepository.CreateAsync(faker.Generate()).Wait();
        }
    }
}
