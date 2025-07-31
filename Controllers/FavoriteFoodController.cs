using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteFoodController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public FavoriteFoodController(ApplicationDbContext db) => _db = db;

        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<FavoriteFood>>> Get(int? id)
        {
            if (id == null || id == 0)
                return await _db.FavoriteFoods.Take(5).ToListAsync();

            var food = await _db.FavoriteFoods.FindAsync(id);
            if (food == null) return NotFound();
            return new[] { food };
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteFood>> Create(FavoriteFood food)
        {
            _db.FavoriteFoods.Add(food);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = food.Id }, food);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FavoriteFood food)
        {
            if (id != food.Id) return BadRequest();
            _db.Entry(food).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var food = await _db.FavoriteFoods.FindAsync(id);
            if (food == null) return NotFound();
            _db.FavoriteFoods.Remove(food);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
