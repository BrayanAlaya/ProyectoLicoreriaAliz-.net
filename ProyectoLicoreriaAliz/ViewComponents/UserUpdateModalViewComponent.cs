using Microsoft.AspNetCore.Mvc;

namespace ProyectoLicoreriaAliz.ViewComponents
{
    public class UserUpdateModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("UserUpdateModal");
        }
    }
}