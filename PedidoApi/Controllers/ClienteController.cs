using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidoDomain.Data;
using PedidoDomain.Models;

namespace PedidoApi.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class ClienteController : ControllerBase
{
    
    private readonly PedidoDbContext _context;
    
    public ClienteController(PedidoDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> CriarCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
    }
}