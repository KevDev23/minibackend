using backendpv.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backendpv.Data
{
    
    public class ResContext : DbContext
    { 
       public ResContext(DbContextOptions<ResContext> options) //allows configuration
        : base(options) { }

       // public DbSet<Res> Reservation { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //allows auto incrementing
        {
            modelBuilder.UseSerialColumns();
            //modelBuilder.Entity<Res>().ToTable("Reservation");
            modelBuilder.Entity<Manager>().ToTable("Managers");

            IdentityRole admin = new IdentityRole();
            admin.Name = "admin";
            admin.NormalizedName = "ADMIN";
            //builder.Entity<IdentityRole>().HasData(role); //tutorial says to use this to add it to the builder but Program.cs adds dbcontext so you might not need it

        }
        
        // = null! tells compiler to just let a null valuable to be assigned

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseNpgsql(@"ReservationDB");
        }*/


    }
}
