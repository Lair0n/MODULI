using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Tur_Agentstvo.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Agenstvo")
        {
        }

        public virtual DbSet<Avtorizacia> Avtorizacia { get; set; }
        public virtual DbSet<Bronirovanie> Bronirovanie { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Doljnost> Doljnost { get; set; }
        public virtual DbSet<Otzivy> Otzivy { get; set; }
        public virtual DbSet<Sotrudnik> Sotrudnik { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tur> Tur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avtorizacia>()
                .HasMany(e => e.Sotrudnik)
                .WithRequired(e => e.Avtorizacia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Avtorizacia>()
                .HasMany(e => e.Tur)
                .WithRequired(e => e.Avtorizacia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Contactniy_telephone)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Bronirovanie)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doljnost>()
                .HasMany(e => e.Sotrudnik)
                .WithRequired(e => e.Doljnost)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Otzivy>()
                .HasMany(e => e.Tur)
                .WithMany(e => e.Otzivy)
                .Map(m => m.ToTable("Tur-Otziv").MapLeftKey("ID_Otziva").MapRightKey("ID_Tura"));

            modelBuilder.Entity<Sotrudnik>()
                .Property(e => e.Contactniy_telephone)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sotrudnik>()
                .HasMany(e => e.Tur)
                .WithMany(e => e.Sotrudnik)
                .Map(m => m.ToTable("Tur-Sotrudnik").MapLeftKey("ID_Sotrudnika").MapRightKey("ID_Tura"));

            modelBuilder.Entity<Tur>()
                .HasMany(e => e.Bronirovanie)
                .WithRequired(e => e.Tur)
                .WillCascadeOnDelete(false);
        }
    }
}
