using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ej1.Models;

namespace API_ej1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {
        private readonly APIContext _context;

        public FabricantesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Fabricantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fabricantes>>> GetFabricantes()
        {
            return await _context.Fabricantes.ToListAsync();
        }

        // GET: api/Fabricantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fabricantes>> GetFabricantes(int id)
        {
            var fabricantes = await _context.Fabricantes.FindAsync(id);

            if (fabricantes == null)
            {
                return NotFound();
            }

            return fabricantes;
        }

        // PUT: api/Fabricantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricantes(int id, Fabricantes fabricantes)
        {
            if (id != fabricantes.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(fabricantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricantesExists(id))
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

        // POST: api/Fabricantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fabricantes>> PostFabricantes(Fabricantes fabricantes)
        {
            _context.Fabricantes.Add(fabricantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFabricantes", new { id = fabricantes.Codigo }, fabricantes);
        }

        // DELETE: api/Fabricantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fabricantes>> DeleteFabricantes(int id)
        {
            var fabricantes = await _context.Fabricantes.FindAsync(id);
            if (fabricantes == null)
            {
                return NotFound();
            }

            _context.Fabricantes.Remove(fabricantes);
            await _context.SaveChangesAsync();

            return fabricantes;
        }

        private bool FabricantesExists(int id)
        {
            return _context.Fabricantes.Any(e => e.Codigo == id);
        }
    }
}
