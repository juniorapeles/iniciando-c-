using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidoDomain.Data;
using PedidoDomain.Models;

namespace PedidoApi.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class PedidoController : ControllerBase
{
    
    private readonly PedidoDbContext _context;
    
    public PedidoController(PedidoDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> CriarPedido(Pedido Pedido)
    {
        _context.Pedidos.Add(Pedido);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPedidos), new { id = Pedido.Id }, Pedido);
    }
}