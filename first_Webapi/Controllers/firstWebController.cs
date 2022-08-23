using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace first_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class firstWebController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var newPersonList = new List<firstWeb>
            {
                new firstWeb
                {
                    id = 1,
                    name = "Janindu",
                    age = 18,
                    schoolName = "Rahula"
                }
            };

            return Ok(newPersonList);
        }
    }
}
