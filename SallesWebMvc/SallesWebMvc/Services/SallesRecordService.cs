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
                resultado = resultado.Where(sellerRecord => sellerRecord.Date >= dataInicial.Value);
            }
            if (dataFinal.HasValue)
            {
                resultado = resultado.Where(sellerRecord => sellerRecord.Date <= dataFinal.Value);
            }

            return await resultado.Include(sellerRecord => sellerRecord.Seller).Include(sellerRecord => sellerRecord.Seller.Department).OrderByDescending(sellerRecord => sellerRecord.Date).ToListAsync();
        }

        public async Task<List<IGrouping<Department,SellesRecord>>> FindByDateGroupingAsync(DateTime? dataInicial, DateTime? dataFinal)
        {
            var resultado = from sallerRecord in _context.SellesRecord select sallerRecord;
            if (dataInicial.HasValue)
            {
                resultado = resultado.Where(sellerRecord => sellerRecord.Date >= dataInicial.Value);
            }
            if (dataFinal.HasValue)
            {
                resultado = resultado.Where(sellerRecord => sellerRecord.Date <= dataFinal.Value);
            }

            return await resultado
                .Include(sellerRecord => sellerRecord.Seller)
                .Include(sellerRecord => sellerRecord.Seller.Department)
                .OrderByDescending(sellerRecord => sellerRecord.Date)
                .GroupBy(sellerRecord => sellerRecord.Seller.Department)
                .ToListAsync();
        }
    }
}
