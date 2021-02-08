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
    public class EmpleadosController : ControllerBase
    {
        private readonly APIContext _context;

        public EmpleadosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetEmpleados(string id)
        {
            var empleados = await _context.Empleados.FindAsync(id);

            if (empleados == null)
            {
                return NotFound();
            }

            return empleados;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleados(string id, Empleados empleados)
        {
            if (id != empleados.DNI)
            {
                return BadRequest();
            }

            _context.Entry(empleados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
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

        // POST: api/Empleados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empleados>> PostEmpleados(Empleados empleados)
        {
            _context.Empleados.Add(empleados);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpleadosExists(empleados.DNI))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmpleados", new { id = empleados.DNI }, empleados);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empleados>> DeleteEmpleados(string id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();

            return empleados;
        }

        private bool EmpleadosExists(string id)
        {
            return _context.Empleados.Any(e => e.DNI == id);
        }
    }
}
