using Microsoft.EntityFrameworkCore;
using projeto_av1.Data;
using projeto_av1.Models;

namespace projeto_av1.Repositories
{
    public class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(AppDbContext db) : base(db) { }

        public Task<bool> EmailEmUsoAsync(string email, int idAtual = 0)
        {
            return _db.Clientes.AnyAsync(c => c.Email == email && c.Id != idAtual);
        }
    }
}
