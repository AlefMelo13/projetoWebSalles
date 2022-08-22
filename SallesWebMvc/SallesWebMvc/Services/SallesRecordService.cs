using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Models;

namespace SallesWebMvc.Services
{
    public class SallesRecordService
    {
        private readonly SallesWebMvcContext _context;

        public SallesRecordService(SallesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SellesRecord>> FindByDateAsync(DateTime ? dataInicial, DateTime? dataFinal)
        {
            var resultado = from obj in _context.SellesRecord select obj;
            if (dataInicial.HasValue)
            {
                resultado = resultado.Where(x => x.Date >= dataInicial.Value);
            }
            if (dataFinal.HasValue)
            {
                resultado = resultado.Where(x => x.Date <= dataFinal.Value);
            }

            return await resultado.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).ToListAsync();
        }
    }
}
