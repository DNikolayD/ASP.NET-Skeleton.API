using ASP.NET_Skeleton.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Skeleton.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var type in typeof(ApplicationDbContext).GetProperties().Where(p => p.Name.EndsWith("s")).Select(x => x.GetType()))
            {
                builder.SetKeys(type);
            }
            base.OnModelCreating(builder);
        }
    }
}