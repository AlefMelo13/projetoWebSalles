using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;
using SallesWebMvc.Services.Exceptions;

namespace SallesWebMvc.Services
{
    public class ProdutoService
    {
        private readonly SallesWebMvcContext _context;

        public ProdutoService(SallesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task Insert(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> FindById(int id)
        {
            return await _context.Produto.Include(produto => produto.Marca).FirstOrDefaultAsync(produto => produto.Id == id);
        }

        public async Task Remove(int id)
        {
            try
            {
                var produto = await _context.Produto.FindAsync(id);
                _context.Produto.Remove(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }
    }
}
