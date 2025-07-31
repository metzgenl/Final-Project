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
    public class FavoriteMoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public FavoriteMoviesController(ApplicationDbContext db) => _db = db;

        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<FavoriteMovie>>> Get(int? id)
        {
            if (id == null || id == 0)
                return await _db.FavoriteMovies.Take(5).ToListAsync();

            var movie = await _db.FavoriteMovies.FindAsync(id);
            if (movie == null) return NotFound();
            return new[] { movie };
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteMovie>> Create(FavoriteMovie movie)
        {
            _db.FavoriteMovies.Add(movie);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FavoriteMovie movie)
        {
            if (id != movie.Id) return BadRequest();
            _db.Entry(movie).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _db.FavoriteMovies.FindAsync(id);
            if (movie == null) return NotFound();
            _db.FavoriteMovies.Remove(movie);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}