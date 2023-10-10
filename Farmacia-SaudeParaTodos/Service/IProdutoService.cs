using Farmacia_SaudeParaTodos.Model;

namespace Farmacia_SaudeParaTodos.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>?> GetByName(string nome);

        Task<IEnumerable<Produto>> GetBetweenPrices(decimal min, decimal max);

        Task<Produto?> Create(Produto produto);

        Task<Produto?> Update(Produto produto);

        Task Delete(Produto produto);
    }
}
