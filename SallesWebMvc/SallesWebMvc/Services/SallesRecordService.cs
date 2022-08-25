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

        public async Task<List<SellesRecord>> FindByDateAsync(DateTime? dataInicial, DateTime? dataFinal)
        {
            var resultado = from sallerRecord in _context.SellesRecord select sallerRecord;
            if (dataInicial.HasValue)
            {
                resultado = resultado.Where(x => x.Date >= dataInicial.Value);
            }
            if (dataFinal.HasValue)
            {
                resultado = resultado.Where(x => x.Date <= dataFinal.Value);
            }

            return await resultado.Include(x => x.Seller).Include(x => x.Seller.Department).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<List<IGrouping<Department,SellesRecord>>> FindByDateGroupingAsync(DateTime? dataInicial, DateTime? dataFinal)
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

            return await resultado.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).GroupBy(x => x.Seller.Department).ToListAsync();
        }
    }
}
