using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Application.QueryStack.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [StringLength(6, MinimumLength = 6)]
        public string PassWord { get; set; }
    }
}
