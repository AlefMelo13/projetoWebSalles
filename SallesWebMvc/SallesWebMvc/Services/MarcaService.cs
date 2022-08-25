using SallesWebMvc.Data;
using SallesWebMvc.Models;

namespace SallesWebMvc.Services
{
    public class MarcaService
    {
        private readonly SallesWebMvcContext _context;

        public MarcaService(SallesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> FindAllAsync()
        {
            return _context.Marca.OrderBy(marca => marca.Descricao).ToList();
        }
    }
}
