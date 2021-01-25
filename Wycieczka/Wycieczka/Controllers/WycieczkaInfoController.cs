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
    public class WycieczkaInfoController : ControllerBase
    {
        private readonly WycieczkaDbContext _context;

        public WycieczkaInfoController(WycieczkaDbContext context)
        {
            _context = context;
        }

        // GET: api/WycieczkaInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WycieczkaInfo>>> GetWycieczkaInfos()
        {
            return await _context.WycieczkaInfos.ToListAsync();
        }
        // POST: api/WycieczkaInfo
        [HttpPost]
        public async Task<ActionResult<WycieczkaInfo>> PostWycieczkaInfo(WycieczkaInfo wycieczkaInfo)
        {
            _context.WycieczkaInfos.Add(wycieczkaInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWycieczkaInfo", new { id = wycieczkaInfo.ID }, wycieczkaInfo);
        }
    }
}
