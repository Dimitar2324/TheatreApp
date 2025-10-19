using System.ComponentModel.DataAnnotations;

namespace TheatreApp.Web.ViewModels.Admin.UserManagement
{
    public class RoleSelectionViewModel
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;
    }
}
