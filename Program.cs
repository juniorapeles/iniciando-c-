
using System;
using DotnetNovePreviewSete;
using DotnetNovePreviewSete.Services;

class Program
{
    private static List<Produto> produtos;
    static ProdutoRepository produtoRepository = new ProdutoRepository();
    private static PedidoService pedidoService;
    
    private static Pedido pedidoAtual;
    static PedidoRepository repository = new PedidoRepository();
    
    static void Main(string[] args)
    {
        produtos = produtoRepository.Carregar();
        
        MainFlux();
        
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
                    VerPedido();
                    break;
                
                case 6:
                    Console.WriteLine("Saindo...");
                    break;
            }
        }
    }

    private static void MainFlux()
    {
        pedidoAtual = repository.Carregar();
        
        Cliente cliente = CadastrarCliente();
        
        pedidoAtual = new Pedido
        {
            Cliente = cliente
        };

        pedidoService = new PedidoService(pedidoAtual,repository);
        
        Console.WriteLine("Pedido criado para: " + cliente.Nome);
    }

    static void VerPedido()
    {
        Console.WriteLine("\nCliente: " + pedidoAtual.Cliente.Nome);
        Console.WriteLine("\nEmail: " + pedidoAtual.Cliente.Email);
        
        Console.WriteLine("\nItens do Pedido: ");

        for (int i = 0; i < pedidoAtual.Items.Count; i++)
        {
            var  item = pedidoAtual.Items[i];
            Console.WriteLine($"{i} - {item.Produto.Nome} - {item.Quantidade} - {item.Subtotal()}");
        }
        
        Console.WriteLine("Total: " + pedidoAtual.Total());
    }

    static Cliente CadastrarCliente()
    {
        Console.WriteLine("Cadastro de cliente");
        Console.Write("Nome do cliente: ");
        string nome = Console.ReadLine();
        
        Console.Write("E-mail do cliente: ");
        string email = Console.ReadLine();
        
        return new Cliente(nome, email);
    }

    static void RemoverItem()
    {
        VerPedido();

        Console.Write("Escolha o índice do item: ");
        int index = int.Parse(Console.ReadLine());

        pedidoService.RemoverItem(index);
        
        Console.WriteLine("Item removido com sucesso!");
    }

    static void CadastrarProduto()
    {      
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());
        
        produtos.Add(new Produto(nome, preco));
        
        produtoRepository.Salvar(produtos);
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
        
        pedidoService.AdicionarItem(produtos[index], qtd);
        
        Console.WriteLine("Item adicionado ao pedido!");
    }
}