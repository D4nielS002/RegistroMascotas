using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroMascotas.Datos;
using RegistroMascotas.Models;

namespace RegistroMascotas.Controllers
{
    public class InicioController : Controller
    {
       private readonly ApplicationDbContext _contexto;
            public InicioController(ApplicationDbContext context)
        {
            _contexto = context;
        }
        

        public async Task <IActionResult> Index()
        {
            return View(await _contexto.Contactos.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
