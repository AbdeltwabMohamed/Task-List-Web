using System.ComponentModel.DataAnnotations;

namespace TaskMangement.ViewModels
{
    public class SignUpViewModel
    {
        [EmailAddress]
        [Required]
        public string Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirmed Password Worng ")]
        public string ConfirmedPassword{ get; set; }
    }
}
