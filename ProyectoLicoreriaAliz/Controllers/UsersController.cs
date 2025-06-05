using Examen_T1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLicoreriaAliz.Models;
using ProyectoLicoreriaAliz.ViewModel;
using System.Text.Json;

namespace ProyectoLicoreriaAliz.Controllers
{
    public class UsersController : Controller
    {
        public readonly AppDbContext _dbContext;

        public UsersController(AppDbContext contextOptions)
        {
            _dbContext = contextOptions;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Mensaje"] = null;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM userLogin) {

            ViewData["Mensaje"] = null;

            Users? usuario_encontrado = await _dbContext.Users.Where(u => u.email == userLogin.email && u.password == userLogin.password).FirstOrDefaultAsync();

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

            HttpContext.Session.SetString("user", JsonSerializer.Serialize(usuario_encontrado));

            return RedirectToAction("Admin", "Home");
        }
    }
}
