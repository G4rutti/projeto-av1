using Microsoft.EntityFrameworkCore;
using projeto_av1.Data;
using projeto_av1.Interfaces;

namespace projeto_av1.Repositories
{
    // implementação genérica, cada entidade herda daqui
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public List<T> BuscarTodos() => _db.Set<T>().AsNoTracking().ToList();

        public T? BuscarPorId(int id) => _db.Set<T>().Find(id);

        public void Adicionar(T entidade)
        {
            _db.Add(entidade);
            _db.SaveChanges();
        }

        public void Atualizar(T entidade)
        {
            _db.Update(entidade);
            _db.SaveChanges();
        }

        public void Remover(T entidade)
        {
            _db.Remove(entidade);
            _db.SaveChanges();
        }

        public async Task<List<T>> BuscarTodosAsync() => await _db.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T?> BuscarPorIdAsync(int id) => await _db.Set<T>().FindAsync(id);

        public async Task AdicionarAsync(T entidade)
        {
            await _db.AddAsync(entidade);
            await _db.SaveChangesAsync();
        }

        public async Task AtualizarAsync(T entidade)
        {
            _db.Update(entidade);
            await _db.SaveChangesAsync();
        }

        public async Task RemoverAsync(T entidade)
        {
            _db.Remove(entidade);
            await _db.SaveChangesAsync();
        }
    }
}
