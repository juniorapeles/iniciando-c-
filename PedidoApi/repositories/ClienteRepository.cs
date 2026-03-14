using Microsoft.EntityFrameworkCore;
using PedidoDomain.Data;
using PedidoDomain.Models;

namespace PedidoApi.repositories;

public class ClienteRepository
{
    private readonly PedidoDbContext _context;
    public ClienteRepository(PedidoDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Cliente>> ListarTodosAsync() => _context.Clientes.ToList();

    public async Task<Cliente> AdicionarAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente?> ObterPorIdAsync(int id) =>
        await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
}