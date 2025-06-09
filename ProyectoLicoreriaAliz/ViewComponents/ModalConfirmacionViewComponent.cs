using Microsoft.AspNetCore.Mvc;
using ProyectoLicoreriaAliz.ViewModel;

namespace ProyectoLicoreriaAliz.ViewComponents
{
    public class ModalConfirmacionViewComponent : ViewComponent
    {
        public ConfirmationModalVM ConfirmationModalVM { get; set; } = new ConfirmationModalVM(); // ViewModel for the confirmation modal

        public IViewComponentResult Invoke(ConfirmationModalVM confirmationModalVM)
        {
            return View("ModalConfirmacion", confirmationModalVM);
        }
        
    }
}