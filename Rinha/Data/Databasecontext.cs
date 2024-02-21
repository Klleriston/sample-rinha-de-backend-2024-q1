using Microsoft.EntityFrameworkCore;
using RINHABACKEND.Model;

namespace RINHABACKEND.Data
{
    public class Databasecontext : DbContext
    {
        public Databasecontext(DbContextOptions<Databasecontext> options) : base(options) { }
        public DbSet<Saldo> Saldos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saldo>().HasData(
                new Saldo { Id = 1, Limite = 100000, Total = -9098 },
                new Saldo { Id = 2, Limite = 80000, Total = 1000 },
                new Saldo { Id = 3, Limite = 1000000, Total = 2000 },
                new Saldo { Id = 4, Limite = 10000000, Total = 120 },
                new Saldo { Id = 5, Limite = 200, Total = 3 }


            );
           
        }
    }
}
