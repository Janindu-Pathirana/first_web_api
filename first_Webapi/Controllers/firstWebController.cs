using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Person_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class firstWebController : ControllerBase
    {

        private static List<Person> personList = new List<Person>
            {
                new Person
                {
                    id = 1,
                    name = "Janindu",
                    age = 18,
                    schoolName = "Rahula"
                },

                new Person
                {
                    id = 2,
                    name = "chamodya",
                    age = 20,
                    schoolName = "IIT"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return Ok(personList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var person = personList.Find(p => p.id == id);
            if (person == null)
                return BadRequest("user not found");
            return Ok(person);

        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person newDetails)
        {
            var person = personList.Find(p => p.id == newDetails.id);
            if (person == null) return BadRequest("cant find the person");

            person.name = newDetails.name;
            person.age = newDetails.age;
            person.schoolName = newDetails.schoolName;


            return Ok(personList);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            personList.Add(person);
            return Ok(personList);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<Person>>> Delete(int id)
        {
            var person = personList.Find(p =>p.id == id);

            if (person == null) return NotFound("cant find the person"); 

            personList.Remove(person);

            return Ok(personList);
        }
    }
}
