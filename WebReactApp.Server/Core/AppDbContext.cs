using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebReactApp.Server.Models;

namespace WebReactApp.Server.Core
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
