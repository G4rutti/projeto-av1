using Microsoft.AspNetCore.Mvc;
using projeto_av1.Data;
using projeto_av1.Models;
using projeto_av1.Repositories;

namespace projeto_av1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteRepository _clientes;

        public ClienteController(AppDbContext db)
        {
            _clientes = new ClienteRepository(db);
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _clientes.BuscarTodosAsync();
            return View(lista.OrderBy(c => c.Nome));
        }

        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _clientes.BuscarPorIdAsync(id);
            return cliente == null ? NotFound() : View(cliente);
        }

        public IActionResult Create()
        {
            return View("Form", new Cliente());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (await _clientes.EmailEmUsoAsync(cliente.Email))
                ModelState.AddModelError("Email", "Esse e-mail já pertence a outro cliente");

            if (!ModelState.IsValid)
                return View("Form", cliente);

            await _clientes.AdicionarAsync(cliente);
            TempData["Aviso"] = $"{cliente.Nome} foi cadastrado.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _clientes.BuscarPorIdAsync(id);
            return cliente == null ? NotFound() : View("Form", cliente);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (await _clientes.EmailEmUsoAsync(cliente.Email, cliente.Id))
                ModelState.AddModelError("Email", "Esse e-mail já pertence a outro cliente");

            if (!ModelState.IsValid)
                return View("Form", cliente);

            await _clientes.AtualizarAsync(cliente);
            TempData["Aviso"] = "Alterações salvas.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clientes.BuscarPorIdAsync(id);
            if (cliente != null)
            {
                await _clientes.RemoverAsync(cliente);
                TempData["Aviso"] = $"{cliente.Nome} foi removido.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
