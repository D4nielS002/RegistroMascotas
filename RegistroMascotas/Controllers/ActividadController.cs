using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using RegistroMascotas.Datos;
using RegistroMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RegistroMascotas.Controllers
{
    public class ActividadController : Controller
    {
        private readonly ApplicationDbContext _contexto;
        public ActividadController(ApplicationDbContext context)
        {
            _contexto = context;
        }
        public async Task<IActionResult> Index()
        {
            var Actividades= await _contexto.Actividad //mediante la variable accede a algo
                .Include(a => a.Contacto)//acceda al elemento de contaco debido a la relacion
                .ToListAsync();//lista  
            return View(Actividades);///return actividad
        }
    }
}
