namespace PedidoDomain.Models;

public class Pedido
{   
    public int Id { get; set; }
    public List<ItemPedido> Items { get; set; } = new List<ItemPedido>();
    public Cliente Cliente { get; set; }
    
    public void AdicionarItem(ItemPedido item)
    {
        Items.Add(item);
    }

    public decimal Total()
    {
        return Items.Sum(i => i.Subtotal());
    }
}