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

        public virtual DbSet<Istorija> Istorije { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

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

                entity.Property(e => e.PaketId).IsRequired();

                entity.Property(e => e.TrajanjeUgovorneObaveze).IsRequired();
            });

           modelBuilder.Entity<Istorija>(entity =>
           {
               entity.HasKey(e => e.Id);

               entity.ToTable("Istorija");

               entity.Property(e => e.BrojUgovora).IsRequired();

               entity.Property(e => e.Datum).IsRequired();

               entity.Property(e => e.Status).IsRequired();

               entity.Property(e => e.Suma).IsRequired();
           });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
