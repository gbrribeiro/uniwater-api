using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Compacts.Simple.Identity.EF
{
    public abstract class IdentityDatabase<TUser> : IdentityDbContext<TUser> where TUser : IdentityUser
    {
        public IdentityDatabase(DbContextOptions options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }
    }
}