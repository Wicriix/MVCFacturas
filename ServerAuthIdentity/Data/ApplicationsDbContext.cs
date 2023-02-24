using ServerAuth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ServerAuth.Data
{
    public class ApplicationsDbContext: IdentityDbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options):base(options) 
        {
            
        }

        public DbSet<ApplicationUser> applicationUsers {  get; set; }
    }
}
