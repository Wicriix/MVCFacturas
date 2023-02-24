using IdentityModel;
using Microsoft.AspNetCore.Identity;
using ServerAuth.Data;
using ServerAuth.Models;
using System.Security.Claims;

namespace ServerAuthIdentity.IDBInitializer
{
    public class DBInitializer : IDBInitializer
    {
        private readonly ApplicationsDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DBInitializer(ApplicationsDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if (_roleManager.FindByIdAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();

            }
            else
            {
                return;
            }

            ApplicationUser adminUser = new()
            {
                UserName = "william.poveda@trip-arc.com",
                Email= "william.poveda@trip-arc.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111",
                Name= "William Poveda"
            };

            _userManager.CreateAsync(adminUser,"Admin123.").GetAwaiter().GetResult();   
            _userManager.AddToRoleAsync(adminUser,SD.Admin).GetAwaiter().GetResult();

            var temp = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.Name),
                new Claim(JwtClaimTypes.Role, SD.Admin)
            }).Result;

            ApplicationUser customerUser = new()
            {
                UserName = "test@trip-arc.com",
                Email = "test@trip-arc.com",
                EmailConfirmed = true,
                PhoneNumber = "11111111",
                Name = "Pilar Villamil"
            };

            _userManager.CreateAsync(customerUser, "Admin123.").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

            var temp2 = _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, customerUser.Name),
                new Claim(JwtClaimTypes.Role, SD.Customer)
            }).Result;
        }
    }
}
