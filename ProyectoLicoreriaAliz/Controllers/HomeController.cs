using Examen_T1.Data;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoLicoreriaAliz.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Admin()
        {
            var rol = HttpContext.Session.GetString("user");
            _logger.LogInformation("Valor de rol en sesión: {Rol}", rol);
            return View();
        }
    }
}
