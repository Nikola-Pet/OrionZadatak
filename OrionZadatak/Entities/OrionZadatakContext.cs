using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrionZadatak.Entities
{
    public partial class OrionZadatakContext : DbContext
    {
        public OrionZadatakContext()
        {
        }

        public OrionZadatakContext(DbContextOptions<OrionZadatakContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Paket> Paketi { get; set; }
        public virtual DbSet<Ugovor> Ugovori { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Data Source=NIKOLA-PC\\NIKOLASQL; Initial Catalog= OrionZadatak; Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Paket>(entity =>
            {
                entity.HasKey(e => e.PaketId);

                entity.ToTable("Paket");

                entity.Property(e => e.Kategorija).IsRequired();

                entity.Property(e => e.Naziv).IsRequired();

                entity.Property(e => e.Opis).IsRequired();
            });

            modelBuilder.Entity<Ugovor>(entity =>
            {
                entity.HasKey(e => e.BrojUgovora);

                entity.ToTable("Ugovor");

                entity.Property(e => e.KorisnickoIme).IsRequired();

                entity.Property(e => e.Paket).IsRequired();

                entity.Property(e => e.TrajanjeUgovorneObaveze).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
