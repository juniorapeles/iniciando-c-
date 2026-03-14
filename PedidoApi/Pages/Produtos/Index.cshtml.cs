using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PedidoDomain.Data;
using PedidoDomain.Models;

namespace PedidoApi.Pages.Produtos;

public class IndexModel : PageModel
{
    private readonly PedidoDbContext _context;
    public IList<Produto> Produtos { get; set; } = default!;

    public IndexModel(PedidoDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Produtos = await _context.Produtos.ToListAsync();
    }
}