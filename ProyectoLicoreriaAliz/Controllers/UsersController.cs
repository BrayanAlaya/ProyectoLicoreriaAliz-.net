using Examen_T1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProyectoLicoreriaAliz.Models;
using ProyectoLicoreriaAliz.ViewModel;
using System.Data;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoLicoreriaAliz.Controllers
{
    public class UsersController : Controller
    {
        public readonly AppDbContext _dbContext;

        public UsersVM UsersVM { get; set; } = new UsersVM(); // ViewModel for Users

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
        public async Task<IActionResult> Login(LoginVM userLogin)
        {

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


        [HttpGet]
        public async Task<IActionResult> Users()
        {
            Role[] roles = await _dbContext.Role.ToArrayAsync();
            UsersVM.roles = roles;

            if (TempData["updateErrors"] != null)
            {
                UsersVM.updateErrors = JsonSerializer.Deserialize<List<string>>(TempData["updateErrors"].ToString());
            }
            else
            {
                UsersVM.updateErrors = new List<string>();
            }

            if (TempData["createErrors"] != null)
            {
                UsersVM.errors = JsonSerializer.Deserialize<List<string>>(TempData["createErrors"].ToString());
            }
            else
            {
                UsersVM.errors = new List<string>();
            }

            if (TempData["User"] != null)
            {
                UsersVM.user = JsonSerializer.Deserialize<Users>(TempData["User"].ToString());
            }
            else
            {
                UsersVM.user = new Users();
            }

            if (int.TryParse(Request.Query["page"].ToString(), out int pageNumber) && pageNumber > 0)
            {
                UsersVM.pageNumber = pageNumber;
            }
            else
            {
                UsersVM.pageNumber = 1;
            }

            if (!string.IsNullOrWhiteSpace(Request.Query["name"].ToString()))
            {
                UsersVM.searchName = Request.Query["name"].ToString();
            }
            else
            {
                UsersVM.searchName = string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(Request.Query["email"].ToString()))
            {
                UsersVM.searchEmail = Request.Query["email"].ToString();
            }
            else
            {
                UsersVM.searchEmail = string.Empty;
            }

            // Dynamic search logic
            var query = _dbContext.Users.Include(u => u.Role).AsQueryable();

            if (!string.IsNullOrWhiteSpace(UsersVM.searchName))
            {
                string nameFilter = UsersVM.searchName.ToLower();
                query = query.Where(u => u.name.ToLower().Contains(nameFilter));
            }

            if (!string.IsNullOrWhiteSpace(UsersVM.searchEmail))
            {
                string emailFilter = UsersVM.searchEmail.ToLower();
                query = query.Where(u => u.email.ToLower().Contains(emailFilter));
            }

            Users[] users = await query
                .Take(UsersVM.pageSize * UsersVM.pageNumber)
                .ToArrayAsync();

            UsersVM.users = users;
            UsersVM.totalCount = await query.CountAsync();

            UsersVM.confirmationModal = new ConfirmationModalVM
            {
                ModalTitle = "Estas seguro de que quieres eliminar este usuario",
                FormAction = "DeleteUser",
                FormController = "Users",
                Id = -1
            };

            return View("Users", UsersVM);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(UsersVM usersVM)
        {

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(usersVM.user.name))
                errors.Add("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(usersVM.user.email))
                errors.Add("El correo electrónico es obligatorio.");

            if (usersVM.user.id <= 0)
            {
                if (string.IsNullOrWhiteSpace(usersVM.user.password))
                    errors.Add("La contraseña es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(usersVM.user.address))
                errors.Add("La dirección es obligatoria.");
            if (usersVM.user.dni.Length != 8)
                errors.Add("El DNI debe tener 8 caracteres.");
            if (usersVM.user.phone.Length != 9)
                errors.Add("El teléfono debe tener 9 caracteres.");
            if (usersVM.user.roleId == -1)
                errors.Add("El rol es obligatorio.");
            if (usersVM.user.birthdate == DateTime.MinValue)
                errors.Add("La fecha de nacimiento es obligatoria.");
            else
            {
                var today = DateTime.Today;
                var age = today.Year - usersVM.user.birthdate.Year;
                if (usersVM.user.birthdate.Date > today.AddYears(-age)) age--;
                if (age < 18)
                    errors.Add("El usuario debe tener al menos 18 años.");
            }

            if (errors.Count > 0)
            {
                if (usersVM.user.id <= 0)
                {

                    TempData["createErrors"] = JsonSerializer.Serialize(errors); // Store errors in TempData for later retrieval
                }
                else
                {
                    TempData["updateErrors"] = JsonSerializer.Serialize(errors); // Store errors in TempData for later retrieval
                }

                TempData["User"] = JsonSerializer.Serialize(usersVM.user); // Store errors in TempData for later retrieval


                return RedirectToAction("Users");
            }

            var userInDb = await _dbContext.Users.FindAsync(usersVM.user.id);

            if (userInDb != null)
            {
                userInDb.name = usersVM.user.name;
                userInDb.email = usersVM.user.email;
                userInDb.address = usersVM.user.address;
                userInDb.dni = usersVM.user.dni;
                userInDb.phone = usersVM.user.phone;
                userInDb.roleId = usersVM.user.roleId;
                userInDb.birthdate = usersVM.user.birthdate;
                _dbContext.Users.Update(userInDb);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                _dbContext.Users.Add(usersVM.user);
                await _dbContext.SaveChangesAsync();
            }

            TempData["Errors"] = JsonSerializer.Serialize(new List<string> { }); // Store success message in TempData
            TempData["User"] = JsonSerializer.Serialize(new Users());

            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(ConfirmationModalVM item)
        {
            _dbContext.Users.Remove(new Users { id = item.Id });
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UsersVM usersVM)
        {
            var errors = new List<string>();


            if (string.IsNullOrWhiteSpace(usersVM.user.password))
                errors.Add("La contraseña es obligatoria.");

            if (errors.Count > 0)
            {

                TempData["Errors"] = JsonSerializer.Serialize(errors); // Store errors in TempData for later retrieval

                return RedirectToAction("Users");
            }

            var userInDb = await _dbContext.Users.FindAsync(usersVM.user.id);

            if (userInDb != null)
            {
                userInDb.password = usersVM.user.password;
                _dbContext.Users.Update(userInDb);
                await _dbContext.SaveChangesAsync();
            }

            TempData["Errors"] = JsonSerializer.Serialize(new List<string> { }); // Store success message in TempData
            TempData["User"] = JsonSerializer.Serialize(new Users());

            return RedirectToAction("Users");
        }

    }

}
