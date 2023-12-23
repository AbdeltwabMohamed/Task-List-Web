using System.ComponentModel.DataAnnotations;

namespace TaskMangement.ViewModels
{
    public class loginViewModel
    {
        [EmailAddress]
        public string Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password{ get; set; }
    }
}
