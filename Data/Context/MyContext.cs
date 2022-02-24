using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prestador>()
                .HasIndex(u => u.CPF)
                .IsUnique();

            modelBuilder.Entity<Contrato>()
                .HasIndex(u => u.CNPJ)
                .IsUnique();
        }

        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Prestador> Prestador { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<OrdemServico> OrdemServico { get; set; }
        public DbSet<LogFalhas> LogFalhas { get; set; }


    }
}
