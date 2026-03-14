namespace PedidoDomain.Models;

public class Produto
{   
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    
    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}