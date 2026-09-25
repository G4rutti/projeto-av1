using Microsoft.EntityFrameworkCore;
using projeto_av1.Models;

namespace projeto_av1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Fornecedor> Fornecedores => Set<Fornecedor>();
    }
}
