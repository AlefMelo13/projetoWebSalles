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
            if (!dataInicial.HasValue)
            {
                dataInicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataFinal.HasValue)
            {
                dataFinal = DateTime.Now;
            }

            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");

            var resultado = await _sallesRecordService.FindByDateAsync(dataInicial, dataFinal);
            return View(resultado);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? dataInicial, DateTime? dataFinal)
        {
            if (!dataInicial.HasValue)
            {
                dataInicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataFinal.HasValue)
            {
                dataFinal = DateTime.Now;
            }

            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");

            var resultado = await _sallesRecordService.FindByDateGroupingAsync(dataInicial, dataFinal);
            return View(resultado);
        }
    }
}
