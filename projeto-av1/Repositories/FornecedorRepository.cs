using Microsoft.EntityFrameworkCore;
using projeto_av1.Data;
using projeto_av1.Models;

namespace projeto_av1.Repositories
{
    public class FornecedorRepository : Repository<Fornecedor>
    {
        public FornecedorRepository(AppDbContext db) : base(db) { }

        public Task<bool> CnpjEmUsoAsync(string cnpj, int idAtual = 0)
        {
            return _db.Fornecedores.AnyAsync(f => f.Cnpj == cnpj && f.Id != idAtual);
        }
    }
}
