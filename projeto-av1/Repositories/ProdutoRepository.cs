using projeto_av1.Data;
using projeto_av1.Models;

namespace projeto_av1.Repositories
{
    public class ProdutoRepository : Repository<Produto>
    {
        public ProdutoRepository(AppDbContext db) : base(db) { }
    }
}
