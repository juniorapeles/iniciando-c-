
using System;
using DotnetNovePreviewSete;

class Program
{
    private static List<Produto> produtos = new List<Produto>();
    private static Pedido pedidoAtual = new Pedido();
    static void Main(string[] args)
    {
        
        int opcao = 0;

        while (opcao != 6)
        {
            Console.WriteLine("\n========= SISTEMA DE PEDIDOS ===========");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Adicionar item ao pedido");
            Console.WriteLine("4 - remover item do pedido");
            Console.WriteLine("5 - ver total do pedido");
            Console.WriteLine("6 - sair");
            
            Console.WriteLine("Escolha: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarProduto();
                    break;   
                
                case 2:
                    ListarProdutos();
                    break;  
                
                case 3:
                    AdicionarItemPedido();
                    break;
                
                case 4:
                    RemoverItem();
                    break;   
                
                case 5:
                    Console.WriteLine("Total do pedido: " + pedidoAtual.Total());
                    break;
            }
        }
    }

    static void RemoverItem()
    {
        ListarProdutos();

        Console.Write("Escolha o índice do item: ");
        int index = int.Parse(Console.ReadLine());
        
        pedidoAtual.Items.RemoveAt(index);
        Console.WriteLine("Item removido com sucesso!");
    }

    static void CadastrarProduto()
    {      
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());
        
        produtos.Add(new Produto(nome, preco));
        Console.WriteLine("Produto cadastrado com sucesso!");
    }
    
    static void ListarProdutos()
    {
        Console.WriteLine("\nProdutos cadastrados:");
        for (int i = 0; i < produtos.Count; i++)
        {
            Console.WriteLine($"{i}  - {produtos[i].Nome} -  {produtos[i].Preco}");
        }
    }
    
    
    static void AdicionarItemPedido()
    {
        ListarProdutos();
        
        Console.Write("Escolha o produto: ");
        int index = int.Parse(Console.ReadLine());
        
        Console.Write("Quantidade: ");
        int qtd = int.Parse(Console.ReadLine());

        ItemPedido item = new ItemPedido()
        {
            Produto = produtos[index],
            Quantidade = qtd
        };
        
        pedidoAtual.AdcionarItem(item);
        Console.WriteLine("Item adicionado ao pedido!");
    }
}