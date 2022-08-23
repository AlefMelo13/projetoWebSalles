using Microsoft.AspNetCore.Mvc;

namespace SallesWebMvc.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
