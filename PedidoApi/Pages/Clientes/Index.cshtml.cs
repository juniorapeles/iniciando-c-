using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PedidoDomain.Data;
using PedidoDomain.Models;

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
        public Cliente Cliente { get; set; } = new Cliente("", "");

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

        public string Mensagem { get; set; } = string.Empty;

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

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            Mensagem = $"Cliente '{Cliente.Nome}' criado com sucesso!";
            Cliente = new Cliente("", ""); // limpa o formulário
            Clientes = await _context.Clientes.ToListAsync();

            return Page();
        }
    }
}