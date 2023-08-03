
using BlazorCRUD.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ListInfoDbContext _dbContext;
        public SuperHeroController(ListInfoDbContext listInfoDbContext)
        {
            _dbContext = listInfoDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes = await _dbContext.SuperHeroes.Include(sh => sh.Comic).ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var heroes = await _dbContext.Comics.ToListAsync();
            return Ok(heroes);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _dbContext.SuperHeroes.Include(a=>a.Comic).FirstOrDefaultAsync(a => a.Id == id);
            if (hero == null)
            {
                return NotFound("Id not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async  Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero superHero)
        {
            superHero.Comic = null;
            _dbContext.SuperHeroes.Add(superHero);
            await _dbContext.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero superHero, int id)
        {
            var hero = await _dbContext.SuperHeroes.Include(sh => sh.Comic).FirstOrDefaultAsync(sh => sh.Id == id);
            if (hero == null)
            {
                return NotFound("Invalid data");
            }
            hero.FirstName = superHero.FirstName;
            hero.LastName = superHero.LastName;
            hero.HeroName = superHero.HeroName;
            hero.ComicId = superHero.ComicId;
            await _dbContext.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var hero = await _dbContext.SuperHeroes.Include(sh => sh.Comic).FirstOrDefaultAsync(sh => sh.Id == id);
            if (hero == null)
            {
                return NotFound("Invalid data");
            }
            _dbContext.SuperHeroes.Remove(hero);
 
            await _dbContext.SaveChangesAsync();
            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await _dbContext.SuperHeroes.Include(a => a.Comic).ToListAsync();
        }

    }
}