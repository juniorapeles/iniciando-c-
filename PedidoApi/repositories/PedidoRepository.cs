using PedidoDomain.Data;

namespace PedidoApi.repositories;

public class PedidoRepository
{
    private readonly PedidoDbContext _context;
    public PedidoRepository(PedidoDbContext context)
    {
        _context = context;
    }
}