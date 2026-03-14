namespace DotnetNovePreviewSete;

public class Pedido
{
    public List<ItemPedido> Items { get; set; } = new List<ItemPedido>();

    public void AdcionarItem(ItemPedido item)
    {
        Items.Add(item);
    }

    public decimal Total()
    {
        return Items.Sum(i => i.Subtotal());
    }
}