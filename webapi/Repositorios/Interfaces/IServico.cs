namespace webapi.Repositorios.Interfaces
{
    public interface IServico<T>
    {
        Task<List<T>> Todos();
        Task Incluir(T t);
        Task<T> Atualizar(T t);
        Task Apagar(T t);
    }
}
