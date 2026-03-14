using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PedidoDomain.Data;
using PedidoDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace PedidoApi.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly PedidoDbContext _context;

        public IndexModel(PedidoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente NovoCliente { get; set; } = new Cliente(); // construtor sem parâmetros

        public List<Cliente> Clientes { get; set; } = new();

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Clientes = await _context.Clientes.ToListAsync();
                return Page();
            }

            _context.Clientes.Add(NovoCliente);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}