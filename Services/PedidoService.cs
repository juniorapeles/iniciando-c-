namespace DotnetNovePreviewSete.Services;

public class PedidoService
{
    private Pedido pedido { get; set; }
    private PedidoRepository repository { get; set; }

    public PedidoService(Pedido pedido, PedidoRepository repository)
    {
        this.pedido = pedido;
        this.repository = repository;
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        var item = new ItemPedido
        {
            Produto = produto,
            Quantidade = quantidade
        };
        
        pedido.AdicionarItem(item);
        repository.Salvar(pedido);
    }

    public void RemoverItem(int index)
    {
        pedido.Items.RemoveAt(index);
        repository.Salvar(pedido);
    }

    public decimal ObterTotal()
    {
        return pedido.Total();
    }

    public List<ItemPedido> ListarItems()
    {
        return pedido.Items;
    }

    public Cliente ObterCliente()
    {
        return pedido.Cliente;
    }
}