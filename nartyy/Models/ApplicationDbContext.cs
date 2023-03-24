using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Entity;

namespace nartyy.Models
{
    

    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Narty> Narty { get; set; }
        public System.Data.Entity.DbSet<ButyNarciarskie> ButyNarciarskiee { get; set; }
        public System.Data.Entity.DbSet<Rezerwacja> Rezerwacje { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
    
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Narty>().ToTable("Narty");
            modelBuilder.Entity<ButyNarciarskie>().ToTable("ButyNarciarskie");
            modelBuilder.Entity<Rezerwacja>().ToTable("Rezerwacje");
        }
    }
}
