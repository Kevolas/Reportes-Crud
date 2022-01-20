using CRUD1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Reporte2Controller : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public Reporte2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<Reporte2Controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var listReportes = await _context.Reportes.ToListAsync();
                return Ok(listReportes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<Reporte2Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Reporte2Controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReporteModel reportes)

        {
            try
            {
                _context.Add(reportes);
                await _context.SaveChangesAsync();
                return Ok(reportes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Reporte2Controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ReporteModel reportes)
        {
            try
            {
               if(id > reportes.id)
                {
                    return NotFound();
                    
                }

                _context.Update(reportes);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El reporte ha sido actualizado!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<Reporte2Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            try
            {
                var reportes = await _context.Reportes.FindAsync(id);
                if(reportes == null)
                {
                    return NotFound();
                }
                _context.Reportes.Remove(reportes);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El reporte ha sido eliminado!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
