using Farmacia_SaudeParaTodos.Data;
using Farmacia_SaudeParaTodos.Model;
using Microsoft.EntityFrameworkCore;

namespace Farmacia_SaudeParaTodos.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                .Include(c => c.Produto)
                .ToListAsync();
        }

        public async Task<Categoria?> GetById(long id)
        {
            try
            {
                var Categoria = await _context.Categorias
                    .Include(c => c.Produto)
                    .Where(c => c.Id == id)
                    .FirstAsync();

                return Categoria;
            }
            catch { return null; }
        }

        public async Task<IEnumerable<Categoria>?> GetByTitulo(string titulo)
        {
            var Categorias = await _context.Categorias
                .Include(c => c.Produto)
                .Where(c => c.Titulo.Contains(titulo))
                .ToListAsync();

            return Categorias;
        }

        public async Task<Categoria?> Create(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> Update(Categoria categoria)
        {
            var CategoriaUpdate = await _context.Categorias.FindAsync(categoria.Id);

            if (CategoriaUpdate is null)
                return null;

            _context.Entry(CategoriaUpdate).State = EntityState.Detached;
            _context.Entry(categoria).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task Delete(Categoria categoria)
        {
            _context.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
