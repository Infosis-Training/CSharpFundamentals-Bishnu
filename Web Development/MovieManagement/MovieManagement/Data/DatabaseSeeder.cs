using Microsoft.AspNetCore.Identity;

namespace MovieManagement.Data
{
    public class DatabaseSeeder
    {
        private readonly MovieManagementDb _db;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public DatabaseSeeder(MovieManagementDb db, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager)
        {
            _db = db;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void PopulateTables()
        {
            _db.Database.EnsureCreated();

            IdentityRole role = new IdentityRole()
            {
                Name = "Admin"
            };

            string[] roleNames = { "Admin", "User" };

            if (!roleManager.Roles.Any())
            {
                foreach (var roleName in roleNames)
                {
                    var roleExist = roleManager.RoleExistsAsync(roleName).Result;
                    if (!roleExist)
                    {
                        roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
            }



            _db.SaveChanges();
        }
    }
}
