using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskMangement.Models;

namespace TaskMangement.Data
{
    public class ApplicationDbContext : IdentityDbContext<SystemUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<DoList> doLists { set; get; }
    }
}
