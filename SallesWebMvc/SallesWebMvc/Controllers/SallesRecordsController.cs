using Microsoft.AspNetCore.Mvc;
using SallesWebMvc.Services;

namespace SallesWebMvc.Controllers
{
    public class SallesRecordsController : Controller
    {
        private readonly SallesRecordService _sallesRecordService;
        public SallesRecordsController(SallesRecordService recordService)
        {
            _sallesRecordService = recordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? dataInicial, DateTime? dataFinal)
        {
            var resultado = await _sallesRecordService.FindByDateAsync(dataInicial, dataFinal);
            return View(resultado);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
