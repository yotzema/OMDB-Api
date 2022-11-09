using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicios_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly FilmContext _context;

        public FilmsController()
        {
            _context = new FilmContext();   
        }

        
        
        [HttpGet]
        public ActionResult<IEnumerable<Film>> Get()
        {
            var listaPeliculas = _context.Set<Film>().ToList();

            if (listaPeliculas == null)
            {
                return NotFound();
            }

            return Ok(listaPeliculas);
        }
    }
}
