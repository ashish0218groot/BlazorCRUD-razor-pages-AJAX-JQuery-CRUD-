
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic>
        {
         new Comic{ Id = 1, Name = "Marvel" },
         new Comic{ Id = 2, Name = "DC" }
        };

        public static List<SuperHero> heroes = new List<SuperHero>
        {
       new SuperHero
    {
        Id= 1,
        FirstName = "Peter",
        LastName = "Peter",
        HeroName = "Peter",
        Comic = comics[0]
    },

     new SuperHero
    {
        Id= 2,
        FirstName = "Bruce",
        LastName = "Wayne",
        HeroName = "Batman",
        Comic = comics[1]
    }
    };


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(heroes);
        }

        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHeroes(int id)
        {
            var hero = heroes.FirstOrDefault(a => a.Id == id);
            if (hero == null)
            {
                return NotFound("Id not found");
            }
            return Ok(hero);
        }
    }
}