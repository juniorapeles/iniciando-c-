```markdown
# Sistema de Pedidos - Histórico e Documentação Completa

Este documento descreve toda a trajetória do desenvolvimento do **Sistema de Pedidos**, desde a configuração inicial do projeto até a implementação de Razor Pages e front-end com Bootstrap. Ele detalha arquitetura, decisões de design, problemas enfrentados e soluções aplicadas.

---

## 📝 Objetivo do Projeto

Criar um sistema de pedidos funcional em **C#**, com integração de **Entity Framework Core**, permitindo:

- Cadastrar **clientes** e **produtos**
- Criar **pedidos** com múltiplos itens
- Visualizar pedidos, clientes e produtos
- Praticar boas práticas de desenvolvimento com **Razor Pages**, **MVC** e **repository pattern**

O projeto também serve como base para futuras evoluções, incluindo front-end moderno e abstração de dados.

---

## 🧩 Estrutura Inicial

Projetos criados:

```

DotnetNovePreviewSete/
│
├── PedidoDomain        (entidades e DbContext)
├── PedidoApi           (API + Razor Pages)
└── PedidoConsole       (Console App para teste e aprendizado)

```

### Principais diretórios e arquivos

```

PedidoDomain/
├── Data/
│   └── PedidoDbContext.cs
├── Models/
│   ├── Cliente.cs
│   ├── Produto.cs
│   ├── Pedido.cs
│   └── ItemPedido.cs
└── PedidoDomain.csproj

PedidoApi/
├── Pages/
│   ├── Index.cshtml
│   ├── Clientes/
│   │   ├── Index.cshtml
│   │   └── Create.cshtml
│   ├── Produtos/
│   │   ├── Index.cshtml
│   │   └── Create.cshtml
│   └── Pedidos/
│       ├── Index.cshtml
│       └── Create.cshtml
├── Controllers/
│   ├── ClienteController.cs
│   ├── ProdutoController.cs
│   └── PedidoController.cs
├── wwwroot/
│   └── favicon.ico
├── Program.cs
└── PedidoApi.csproj

PedidoConsole/
├── Program.cs
├── Produto.cs
├── ItemPedido.cs
├── Pedido.cs
└── PedidoConsole.csproj

````

---

## 🔧 Tecnologias e Frameworks

- **C# 11**
- **.NET 9 Preview 7**
- **Entity Framework Core 10**
- **SQLite** (banco local)
- **Razor Pages** (front-end básico)
- **Bootstrap 5** (interface responsiva)
- **ASP.NET Core MVC** (controllers para API)
- **Repository Pattern** (abstração de acesso a dados)

---

## 🚀 Evolução do Projeto

### 1️⃣ Configuração do projeto

- Criação de soluções com múltiplos projetos
- Configuração inicial do EF Core
- Primeiro `dotnet ef migrations add InitialCreate`
- `dotnet ef database update` para criar o banco SQLite

### 2️⃣ Entidades e relacionamento

```csharp
public class Cliente { public int Id { get; set; } public string Nome { get; set; } public string Email { get; set; } }
public class Produto { public int Id { get; set; } public string Nome { get; set; } public decimal Preco { get; set; } }
public class Pedido { public int Id { get; set; } public int ClienteId { get; set; } public Cliente Cliente { get; set; } public List<ItemPedido> Itens { get; set; } }
public class ItemPedido { public int Id { get; set; } public int ProdutoId { get; set; } public Produto Produto { get; set; } public int Quantidade { get; set; } public int PedidoId { get; set; } public Pedido Pedido { get; set; } }
````

* Relações:

  * Pedido → Cliente (1:N)
  * Pedido → ItemPedido (1:N)
  * ItemPedido → Produto (N:1)

### 3️⃣ API e Controllers

* **ClienteController**, **ProdutoController**, **PedidoController**
* Uso de `ControllerBase` e `DbContext` injetado
* Métodos CRUD implementados (`Get`, `Post`)
* Resolução de problemas de **CreatedAtAction**
* Abstração futura com DTOs e Repository Pattern

### 4️⃣ Razor Pages

* Criadas páginas para:

  * `Home/Index`
  * `Clientes/Index` e `Clientes/Create`
  * `Produtos/Index` e `Produtos/Create`
  * `Pedidos/Index` e `Pedidos/Create`
* Layout compartilhado `_Layout.cshtml` para padronizar header, navbar e footer
* Adição de **Bootstrap** via CDN
* Favicon incluído na pasta `wwwroot` e referenciado no layout

### 5️⃣ Front-end funcional

* Home com links para clientes, produtos e pedidos
* Tabelas de listagem com Razor
* Formulários básicos para criação de clientes, produtos e pedidos
* Estrutura pensada para futura evolução com componentes e validação de formulário

### 6️⃣ Console App

* Implementação paralela para aprendizado e testes de lógica
* Possui CRUD básico via terminal
* Calcula total do pedido
* Facilita teste sem front-end

---

## 🧠 Boas práticas aplicadas

* Separação de camadas: `Domain`, `API`, `Console`
* Injeção de dependências (`DbContext`)
* Migrations EF Core para versionamento do banco
* Layout padrão para Razor Pages
* Estrutura de pastas consistente (`Pages/Clientes`, `Pages/Produtos`, `Pages/Pedidos`)
* Uso de `IActionResult` e padrões REST na API
* Preparado para DTOs e Repository Pattern

---

## ⚡ Próximos passos sugeridos

* Implementar **Repository Pattern** completo para abstrair `DbContext` da API
* Criar DTOs e ViewModels para formulários
* Adicionar **validação** de entrada de dados
* Melhorar **front-end** com Bootstrap avançado ou Blazor
* Criar autenticação e autorização básica (login)
* Adicionar testes unitários e de integração

---

## 🖥 Como executar

### Pré-requisitos

* .NET SDK 9 Preview 7
* Visual Studio, Rider ou VS Code
* SQLite ou outro banco compatível

### Rodar a API com Razor Pages

```bash
cd PedidoApi
dotnet run
```

* Acesse a home em: [http://localhost:5187](http://localhost:5187)
* Navegação: Home → Clientes / Produtos / Pedidos

### Rodar o Console App

```bash
cd PedidoConsole
dotnet run
```

---

## 🔗 Referências

* [Entity Framework Core Documentation](https://docs.microsoft.com/ef/core/)
* [Razor Pages Documentation](https://docs.microsoft.com/aspnet/core/razor-pages/)
* [Bootstrap Documentation](https://getbootstrap.com/docs/5.3/getting-started/introduction/)
* [Repository Pattern in .NET](https://docs.microsoft.com/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)

---

## ✅ Observações finais

* O projeto está funcional para **CRUD completo** de clientes, produtos e pedidos.
* Razor Pages já implementadas com layout e navegação padrão.
* Banco SQLite inicial criado e migrado via EF Core.
* Estrutura modular para futuras melhorias, como autenticação e front-end avançado.

```
```
