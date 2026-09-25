namespace projeto_av1.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // síncronos
        List<T> BuscarTodos();
        T? BuscarPorId(int id);
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Remover(T entidade);

        // assíncronos
        Task<List<T>> BuscarTodosAsync();
        Task<T?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(T entidade);
    }
}
