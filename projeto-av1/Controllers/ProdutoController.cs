using Microsoft.AspNetCore.Mvc;
using projeto_av1.Data;
using projeto_av1.Models;
using projeto_av1.Repositories;

namespace projeto_av1.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtos;

        public ProdutoController(AppDbContext db)
        {
            _produtos = new ProdutoRepository(db);
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _produtos.BuscarTodosAsync();
            return View(lista.OrderBy(p => p.Nome));
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtos.BuscarPorIdAsync(id);
            return produto == null ? NotFound() : View(produto);
        }

        public IActionResult Create()
        {
            return View("Form", new Produto());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (!ModelState.IsValid)
                return View("Form", produto);

            await _produtos.AdicionarAsync(produto);
            TempData["Aviso"] = $"{produto.Nome} foi cadastrado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _produtos.BuscarPorIdAsync(id);
            return produto == null ? NotFound() : View("Form", produto);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Produto produto)
        {
            if (!ModelState.IsValid)
                return View("Form", produto);

            await _produtos.AtualizarAsync(produto);
            TempData["Aviso"] = "Alterações salvas.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtos.BuscarPorIdAsync(id);
            if (produto != null)
            {
                await _produtos.RemoverAsync(produto);
                TempData["Aviso"] = $"{produto.Nome} foi removido.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
