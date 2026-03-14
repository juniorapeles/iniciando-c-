# Sistema de Pedidos - Console

Projeto simples desenvolvido em C# para praticar conceitos fundamentais de programação orientada a objetos e estrutura de aplicações em console.

## 📚 Objetivo

Criar um sistema de pedidos que permita:

- cadastrar produtos
- listar produtos
- adicionar itens a um pedido
- calcular o total do pedido

O projeto foi desenvolvido para aprendizado da linguagem C# e fundamentos de backend.

## 🧱 Estrutura do Projeto

PedidoConsole
│
├── Program.cs
├── Produto.cs
├── ItemPedido.cs
└── Pedido.cs


### Classes

**Produto**
- Nome
- Preço

**ItemPedido**
- Produto
- Quantidade
- Subtotal

**Pedido**
- Lista de itens
- Cálculo do total do pedido

## 🧠 Conceitos aplicados

- Programação orientada a objetos
- Classes e objetos
- Listas (`List<T>`)
- Métodos
- Encapsulamento
- LINQ
- Interação com usuário via console

## 🚀 Como executar

### Pré-requisitos

- .NET SDK instalado

Tecnologia utilizada:

- C#

Framework:

- ASP.NET Core (para futuras evoluções)

### Rodar o projeto

```bash
dotnet run