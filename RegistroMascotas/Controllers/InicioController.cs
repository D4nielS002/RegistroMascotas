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

        //crear la funcion para direcionar a la vista crear

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        //cargar el proceso de insertar 

        [HttpPost]//cargar las solicitudes por post
        [ValidateAntiForgeryToken]//seguridad anti token

        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contacto.FechaRegistro = DateTime.Now;
                _contexto.Contactos.Add(contacto);//insercion
                await _contexto.SaveChangesAsync();//guardando los cambios
                return RedirectToAction(nameof(Index));//redirigiendo a la vista
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto= _contexto.Contactos.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]//cargar las solicitudes por post
        [ValidateAntiForgeryToken]//seguridad anti token

        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contacto.FechaRegistro = DateTime.Now;
                _contexto.Contactos.Update(contacto);//insercion
                await _contexto.SaveChangesAsync();//guardando los cambios
                return RedirectToAction(nameof(Index));//redirigiendo a la vista
            }
            return View();
        }
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _contexto.Contactos.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto); // Devuelve una vista para confirmar la eliminación
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(Contacto contacto)
        {
            var contactoE = await _contexto.Contactos.FindAsync(contacto.Id);
            if (contactoE == null)
            {
                return NotFound();
            }

            _contexto.Contactos.Remove(contactoE); // Elimina el contacto de la base de datos
            await _contexto.SaveChangesAsync(); // Guarda los cambios en la base de datos

            return RedirectToAction(nameof(Index)); // Redirige a la lista de contactos
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Verificar las credenciales
            var usuario = _contexto.Usuarios
            .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (usuario != null)
            {
                TempData["Mensaje"] = "Login exitoso.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Credenciales incorrectas. Inténtalo nuevamente.";
                return View();
            }
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
