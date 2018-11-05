using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StackFiap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackFiap.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Resposta> Respostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pergunta>()
                .HasMany<Resposta>(s => s.Respostas)
                .WithOne()
                .HasForeignKey(g => g.PerguntaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Pergunta>()
                .HasOne<Resposta>(s => s.MelhorResposta)
                .WithOne(g => g.Pergunta)
                .HasForeignKey<Pergunta>(s => s.MelhorRespostaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Pergunta>()
                .HasOne<Autor>(a => a.Autor)
                .WithOne()
                .HasForeignKey<Pergunta>(p => p.AutorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resposta>()
                .HasOne<Autor>(r => r.Autor)
                .WithOne()
                .HasForeignKey<Resposta>(r => r.AutorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Autor>()
            .Property(b => b.DataCriacao)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Pergunta>()
            .Property(b => b.DataCriacao)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Resposta>()
            .Property(b => b.DataCriacao)
            .HasDefaultValueSql("getdate()");
        }
    }

    //public class SFContextFactory : IDesignTimeDbContextFactory<SFContext>
    //{
    //    public SFContext CreateDbContext(string[] args)
    //    {
    //        var connection = @"Server=(localdb)\mssqllocaldb;Database=StackDB;Trusted_Connection=True;ConnectRetryCount=0";
    //        var optionsBuilder = new DbContextOptionsBuilder<SFContext>();
    //        optionsBuilder.UseSqlServer(connection);

    //        return new SFContext(optionsBuilder.Options);
    //    }
    //}
}
