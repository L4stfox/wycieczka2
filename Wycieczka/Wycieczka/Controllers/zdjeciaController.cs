using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wycieczka.Context;
using Wycieczka.Models;

namespace Wycieczka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class zdjeciaController : ControllerBase
    {
        private readonly WycieczkaDbContext _context;

        public zdjeciaController(WycieczkaDbContext context)
        {
            _context = context;
        }

        // GET: api/zdjecia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<zdjecia>>> GetZdjecias()
        {
            return await _context.Zdjecias.ToListAsync();
        }

        // GET: api/zdjecia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<zdjecia>> Getzdjecia(int id)
        {
            var zdjecia = await _context.Zdjecias.FindAsync(id);

            if (zdjecia == null)
            {
                return NotFound();
            }

            return zdjecia;
        }

        // PUT: api/zdjecia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putzdjecia(int id, zdjecia zdjecia)
        {
            if (id != zdjecia.Id)
            {
                return BadRequest();
            }

            _context.Entry(zdjecia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!zdjeciaExists(id))
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

        // POST: api/zdjecia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<zdjecia>> Postzdjecia(zdjecia zdjecia)
        {
            _context.Zdjecias.Add(zdjecia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getzdjecia", new { id = zdjecia.Id }, zdjecia);
        }

        // DELETE: api/zdjecia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletezdjecia(int id)
        {
            var zdjecia = await _context.Zdjecias.FindAsync(id);
            if (zdjecia == null)
            {
                return NotFound();
            }

            _context.Zdjecias.Remove(zdjecia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool zdjeciaExists(int id)
        {
            return _context.Zdjecias.Any(e => e.Id == id);
        }
    }
}
