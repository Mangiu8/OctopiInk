using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OctopInk.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prodotti>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);
        }
    }
}
