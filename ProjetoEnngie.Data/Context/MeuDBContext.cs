using Microsoft.EntityFrameworkCore;
using ProjetoEnngie.Business.Models;

namespace ProjetoEnngie.Data.Context
{
    public class MeuDBContext : DbContext
    {
        public MeuDBContext(DbContextOptions<MeuDBContext> options) : base(options) { }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Usina> Usinas { get; set; }
    }
}
