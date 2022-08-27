using Microsoft.AspNetCore.Mvc;
using SallesWebMvc.Models;
using SallesWebMvc.Models.ViewModels;
using SallesWebMvc.Services;
using SallesWebMvc.Services.Exceptions;
using System.Diagnostics;

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

        public async Task<IActionResult> Create()
        {
            var marcas = await _marcaService.FindAllAsync();
            var viweModel = new ProdutoFormViewModel { Marcas = marcas };
            return View(viweModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
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

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id not provided"});
            }

            var produto = await _produtoService.FindById(id.Value);
            if(produto == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id not found" });
            }

            List<Marca> marca = await _marcaService.FindAllAsync();
            ProdutoFormViewModel viewModel = new ProdutoFormViewModel { Produto = produto, Marcas = marca };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                var marca = await _marcaService.FindAllAsync();
                var viewModel = new ProdutoFormViewModel { Produto = produto, Marcas = marca };
                return View(viewModel);
            }

            if (id != produto.Id)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id mismatch" });
            }

            try
            {
                await _produtoService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Erro), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Erro), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id not provided!" });
            }

            var produto = await _produtoService.FindById(id.Value);
            if(produto == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id not found!" });
            }

            return View(produto);
        }

        public async Task<IActionResult> Erro(string message)
        {
            var viewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
