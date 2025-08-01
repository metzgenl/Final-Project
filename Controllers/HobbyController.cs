using Microsoft.AspNetCore.Mvc;
using Final_Project.Data;
using Final_Project.Models;
 
namespace Final_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
 
        public HobbyController(ApplicationDbContext context)
        {
            _context = context;
        }
 
 
        // GET: api/Hobby/5
        [HttpGet("{id}")]
        public IActionResult GetHobby(int id)
        {
            var hobby = _context.Hobbies.Find(id);
            if (hobby == null) return NotFound();
            return Ok(hobby);
        }
 
        // POST: api/Hobby
        [HttpPost]
        public IActionResult CreateHobby([FromBody] Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetHobby), new { ID = hobby.ID }, hobby);
        }
 
        // PUT: api/Hobby/5
        [HttpPut("{ID}")]
        public IActionResult UpdateHobby(int id, [FromBody] Hobby updatedHobby)
        {
            var hobby = _context.Hobbies.Find(id);
            if (hobby == null) return NotFound();
 
            hobby.HobbyName = updatedHobby.HobbyName;
            hobby.Description = updatedHobby.Description;
            hobby.SkillLevel = updatedHobby.SkillLevel;
 
            _context.SaveChanges();
            return NoContent();
        }
 
        // DELETE: api/Hobby/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHobby(int id)
        {
            var hobby = _context.Hobbies.Find(id);
            if (hobby == null) return NotFound();
 
            _context.Hobbies.Remove(hobby);
            _context.SaveChanges();
            return NoContent();
        }
    }
}