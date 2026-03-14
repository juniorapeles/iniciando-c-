using System.Text.Json;

namespace DotnetNovePreviewSete;

public class PedidoRepository
{
    private const string arquivo = "pedido.json";

    public void Salvar(Pedido pedido)
    {
        var json = JsonSerializer.Serialize(pedido, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(arquivo, json);
    }

    public Pedido Carregar()
    {
        if (!File.Exists(arquivo))
            return new Pedido();
        var json = File.ReadAllText(arquivo);
        return JsonSerializer.Deserialize<Pedido>(json);
    }
}