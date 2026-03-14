using PedidoApi.repositories;
using PedidoDomain.Models;

namespace PedidoApi.Services;

public class ClienteService
{
    private readonly ClienteRepository _repository;

    public ClienteService(ClienteRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Cliente>> ObterTodosAsync() => _repository.ListarTodosAsync();
    
    public Task<Cliente> CriarCliente(Cliente cliente) => _repository.AdicionarAsync(cliente);
}