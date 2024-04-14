using System.ComponentModel.DataAnnotations;

namespace BNI.Models.ViewModel
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }
    }
}
