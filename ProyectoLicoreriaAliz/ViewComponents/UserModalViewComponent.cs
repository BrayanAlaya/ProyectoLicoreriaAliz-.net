using Microsoft.AspNetCore.Mvc;

namespace ProyectoLicoreriaAliz.ViewComponents
{
    public class UserModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("UserModal");
        }
    }
}