using Microsoft.AspNetCore.Mvc;

namespace Homework_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return Ok(StaticDb.UserNames);
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> GetById(int id)
        {
            if (id < 1 || id > StaticDb.UserNames.Count)
            {
                return NotFound();
            }
            return Ok(StaticDb.UserNames[id - 1]);
        }
    }
}
