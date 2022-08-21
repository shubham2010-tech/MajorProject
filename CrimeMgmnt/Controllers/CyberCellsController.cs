using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrimeMgmnt.Data;
using CrimeMgmnt.Models;

namespace CrimeMgmnt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CyberCellsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CyberCellsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CyberCells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CyberCell>>> GetcyberCells()
        {
            return await _context.cyberCells.ToListAsync();
        }

        // GET: api/CyberCells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CyberCell>> GetCyberCell(int id)
        {
            var cyberCell = await _context.cyberCells.FindAsync(id);

            if (cyberCell == null)
            {
                return NotFound();
            }

            return cyberCell;
        }

        // PUT: api/CyberCells/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCyberCell(int id, CyberCell cyberCell)
        {
            if (id != cyberCell.ControlRoomId)
            {
                return BadRequest();
            }

            _context.Entry(cyberCell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CyberCellExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CyberCells
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CyberCell>> PostCyberCell(CyberCell cyberCell)
        {
            _context.cyberCells.Add(cyberCell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCyberCell", new { id = cyberCell.ControlRoomId }, cyberCell);
        }

        // DELETE: api/CyberCells/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CyberCell>> DeleteCyberCell(int id)
        {
            var cyberCell = await _context.cyberCells.FindAsync(id);
            if (cyberCell == null)
            {
                return NotFound();
            }

            _context.cyberCells.Remove(cyberCell);
            await _context.SaveChangesAsync();

            return cyberCell;
        }

        private bool CyberCellExists(int id)
        {
            return _context.cyberCells.Any(e => e.ControlRoomId == id);
        }
    }
}
