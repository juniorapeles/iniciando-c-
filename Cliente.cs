namespace DotnetNovePreviewSete;

public class Cliente
{
    public string Nome { get; set; }    
    public String Email { get; set; }
    
    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}