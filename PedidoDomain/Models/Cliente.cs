namespace PedidoDomain.Models;

public class Cliente
{   
    public int Id { get; set; }
    
    public string Nome { get; set; }    
    public String Email { get; set; }

    public Cliente()
    {
    }

    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}