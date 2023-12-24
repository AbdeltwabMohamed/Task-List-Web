using Microsoft.AspNetCore.Identity;

namespace TaskMangement.Models
{
    public class SystemUser : IdentityUser
    {
       public List<DoList> DoList { get; set; }
    }
}
