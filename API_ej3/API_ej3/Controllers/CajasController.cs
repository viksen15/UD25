using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ej3.Models;

namespace API_ej3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajasController : ControllerBase
    {
        private readonly APIContext _context;

        public CajasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cajas>>> GetCajas()
        {
            return await _context.Cajas.ToListAsync();
        }

        // GET: api/Cajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cajas>> GetCajas(string id)
        {
            var cajas = await _context.Cajas.FindAsync(id);

            if (cajas == null)
            {
                return NotFound();
            }

            return cajas;
        }

        // PUT: api/Cajas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCajas(string id, Cajas cajas)
        {
            if (id != cajas.NumReferencia)
            {
                return BadRequest();
            }

            _context.Entry(cajas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajasExists(id))
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

        // POST: api/Cajas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cajas>> PostCajas(Cajas cajas)
        {
            _context.Cajas.Add(cajas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CajasExists(cajas.NumReferencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCajas", new { id = cajas.NumReferencia }, cajas);
        }

        // DELETE: api/Cajas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cajas>> DeleteCajas(string id)
        {
            var cajas = await _context.Cajas.FindAsync(id);
            if (cajas == null)
            {
                return NotFound();
            }

            _context.Cajas.Remove(cajas);
            await _context.SaveChangesAsync();

            return cajas;
        }

        private bool CajasExists(string id)
        {
            return _context.Cajas.Any(e => e.NumReferencia == id);
        }
    }
}
