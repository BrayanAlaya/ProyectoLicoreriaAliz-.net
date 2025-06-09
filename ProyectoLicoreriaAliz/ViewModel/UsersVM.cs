using ProyectoLicoreriaAliz.Models;

namespace ProyectoLicoreriaAliz.ViewModel
{
    public class UsersVM
    {
        public string searchName { get; set; } = ""; // Search term for filtering users
        public string searchEmail { get; set; } = ""; // Search term for filtering users
        public int pageSize { get; set; } = 10; // Default page size
        public int pageNumber { get; set; } = 1; // Default page number
        public int totalCount { get; set; } = 0; // Total number of users

        public Users[] users { get; set; } = []; // Array of users


        public Role[] roles { get; set; } = []; // Array of roles

        public int? userSelectedId { get; set; } = null; // Current user selected ID
        public Users user { get; set; } = new Users(); // Current user
    
        public List<string> errors { get; set; } = new List<string>(); // List of validation errors
        public List<string> updateErrors { get; set; } = new List<string>(); // List of validation errors
        public ConfirmationModalVM confirmationModal { get; set; } = new ConfirmationModalVM(); // Confirmation modal view model
    }
}
