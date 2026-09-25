using Microsoft.AspNetCore.Mvc;
using projeto_av1.Data;
using projeto_av1.Models;
using projeto_av1.Repositories;

namespace projeto_av1.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedorRepository _fornecedores;

        public FornecedorController(AppDbContext db)
        {
            _fornecedores = new FornecedorRepository(db);
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _fornecedores.BuscarTodosAsync();
            return View(lista.OrderBy(f => f.RazaoSocial));
        }

        public async Task<IActionResult> Details(int id)
        {
            var fornecedor = await _fornecedores.BuscarPorIdAsync(id);
            return fornecedor == null ? NotFound() : View(fornecedor);
        }

        public IActionResult Create()
        {
            return View("Form", new Fornecedor());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            if (await _fornecedores.CnpjEmUsoAsync(fornecedor.Cnpj))
                ModelState.AddModelError("Cnpj", "Já tem um fornecedor com esse CNPJ");

            if (!ModelState.IsValid)
                return View("Form", fornecedor);

            await _fornecedores.AdicionarAsync(fornecedor);
            TempData["Aviso"] = $"{fornecedor.RazaoSocial} foi cadastrado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _fornecedores.BuscarPorIdAsync(id);
            return fornecedor == null ? NotFound() : View("Form", fornecedor);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Fornecedor fornecedor)
        {
            if (await _fornecedores.CnpjEmUsoAsync(fornecedor.Cnpj, fornecedor.Id))
                ModelState.AddModelError("Cnpj", "Já tem um fornecedor com esse CNPJ");

            if (!ModelState.IsValid)
                return View("Form", fornecedor);

            await _fornecedores.AtualizarAsync(fornecedor);
            TempData["Aviso"] = "Alterações salvas.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var fornecedor = await _fornecedores.BuscarPorIdAsync(id);
            if (fornecedor != null)
            {
                await _fornecedores.RemoverAsync(fornecedor);
                TempData["Aviso"] = $"{fornecedor.RazaoSocial} foi removido.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
