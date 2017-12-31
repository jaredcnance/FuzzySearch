using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Domain.People
{
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string name)
        {
            var people = await _personService.SearchAsync(name);
            return Ok(people);
        }
    }
}