using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Audio_Junction.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<Genre> Genre { get; set; }

       public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}