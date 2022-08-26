using Microsoft.AspNetCore.Mvc;
using SallesWebMvc.Models;
using SallesWebMvc.Models.ViewModels;
using SallesWebMvc.Services;

namespace SallesWebMvc.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly MarcaService _marcaService;
        public ProdutosController(ProdutoService produtoService, MarcaService marcaService)
        {
            _produtoService = produtoService;
            _marcaService = marcaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _produtoService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> SearchById(int id)
        {
            var list = await _produtoService.FindById(id);
            return View(list);
        }

        //public async Task<IActionResult> SearchByDescricao(string descricao)
        //{

        //    if (string.IsNullOrEmpty(descricao))
        //    {
        //        return View("Error");
        //    }

        //    var list = await _produtoService.fi

        //    return View(list);
        //}

        public async Task<IActionResult> Create()
        {
            var marcas = await _marcaService.FindAllAsync();
            var viweModel = new ProdutoFormViewModel { Marcas = marcas };
            return View(viweModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto? produto)
        {
            if (!ModelState.IsValid)
            {
                var marcas = await _marcaService.FindAllAsync();
                var viweModel = new ProdutoFormViewModel { Produto = produto, Marcas = marcas };
                return View(viweModel);
            }

            await _produtoService.Insert(produto);
            return RedirectToAction(nameof(Index));
        }
    }
}
