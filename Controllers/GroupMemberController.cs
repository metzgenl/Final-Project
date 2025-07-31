
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupMembersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public GroupMembersController(ApplicationDbContext db) => _db = db;

        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<GroupMember>>> Get(int? id)
        {
            if (id == null || id == 0)
                return await _db.GroupMembers.Take(5).ToListAsync();

            var member = await _db.GroupMembers.FindAsync(id);
            if (member == null) return NotFound();
            return new[] { member };
        }

        [HttpPost]
        public async Task<ActionResult<GroupMember>> Create(GroupMember tm)
        {
            _db.GroupMembers.Add(tm);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = tm.Id }, tm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GroupMember tm)
        {
            if (id != tm.Id) return BadRequest();
            _db.Entry(tm).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tm = await _db.GroupMembers.FindAsync(id);
            if (tm == null) return NotFound();
            _db.GroupMembers.Remove(tm);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
