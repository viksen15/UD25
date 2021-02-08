using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ej4.Models;

namespace API_ej4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly APIContext _context;

        public SalasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Salas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salas>>> GetSalas()
        {
            return await _context.Salas.ToListAsync();
        }

        // GET: api/Salas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salas>> GetSalas(int id)
        {
            var salas = await _context.Salas.FindAsync(id);

            if (salas == null)
            {
                return NotFound();
            }

            return salas;
        }

        // PUT: api/Salas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalas(int id, Salas salas)
        {
            if (id != salas.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(salas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalasExists(id))
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

        // POST: api/Salas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Salas>> PostSalas(Salas salas)
        {
            _context.Salas.Add(salas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalas", new { id = salas.Codigo }, salas);
        }

        // DELETE: api/Salas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Salas>> DeleteSalas(int id)
        {
            var salas = await _context.Salas.FindAsync(id);
            if (salas == null)
            {
                return NotFound();
            }

            _context.Salas.Remove(salas);
            await _context.SaveChangesAsync();

            return salas;
        }

        private bool SalasExists(int id)
        {
            return _context.Salas.Any(e => e.Codigo == id);
        }
    }
}
