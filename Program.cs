
using System;
using DotnetNovePreviewSete;

class Program
{
    static void Main(string[] args)
    {
        Produto cafe = new  Produto("Café", 10);
        Produto pao = new  Produto("Pão", 5);
        
        Pedido pedido = new  Pedido();
        
        pedido.AdcionarItem(new ItemPedido
        {
            Produto = cafe,
            Quantidade =    2
        });
        
        pedido.AdcionarItem(new ItemPedido
        {
            Produto = pao,
            Quantidade =    3
        });
        
        Console.WriteLine("Total do pedido: " + pedido.Total());
    }
}