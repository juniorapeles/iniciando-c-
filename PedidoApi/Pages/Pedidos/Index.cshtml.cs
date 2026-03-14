using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PedidoDomain.Data;
using PedidoDomain.Models;

namespace PedidoApi.Pages.Pedidos;

public class IndexModel : PageModel
{
    private readonly PedidoDbContext _context;
    public IList<Pedido> Pedidos { get; set; } = default!;

    public IndexModel(PedidoDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Pedidos = await _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Items)
            .ThenInclude(i => i.Produto)
            .ToListAsync();
    }
}