using System.Text.Json;
using PedidoDomain.Models;

namespace PedidoConsole.repositories;

public class ProdutoRepository
{
    private const string arquivo = "produtos.json";

    public void Salvar(List<Produto> produtos)
    {
        var json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(arquivo, json);
    }

    public List<Produto> Carregar()
    {
        if (!File.Exists(arquivo))
            return new List<Produto>();
        
        var json = File.ReadAllText(arquivo);
        return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
    }
}