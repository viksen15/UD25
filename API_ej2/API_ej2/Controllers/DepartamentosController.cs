using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ej2.Models;

namespace API_ej2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly APIContext _context;

        public DepartamentosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Departamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamentos>>> GetDepartamentos()
        {
            return await _context.Departamentos.ToListAsync();
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamentos>> GetDepartamentos(int id)
        {
            var departamentos = await _context.Departamentos.FindAsync(id);

            if (departamentos == null)
            {
                return NotFound();
            }

            return departamentos;
        }

        // PUT: api/Departamentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamentos(int id, Departamentos departamentos)
        {
            if (id != departamentos.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(departamentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentosExists(id))
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

        // POST: api/Departamentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Departamentos>> PostDepartamentos(Departamentos departamentos)
        {
            _context.Departamentos.Add(departamentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamentos", new { id = departamentos.Codigo }, departamentos);
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Departamentos>> DeleteDepartamentos(int id)
        {
            var departamentos = await _context.Departamentos.FindAsync(id);
            if (departamentos == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(departamentos);
            await _context.SaveChangesAsync();

            return departamentos;
        }

        private bool DepartamentosExists(int id)
        {
            return _context.Departamentos.Any(e => e.Codigo == id);
        }
    }
}
