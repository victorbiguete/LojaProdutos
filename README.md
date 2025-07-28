# 🛒 Loja Virtual ASP.NET MVC

Projeto prático de e-commerce construído com **ASP.NET MVC**, simulando uma loja virtual completa com catálogo, carrinho, autenticação (social e tradicional) e painel administrativo.

---

## ✨ Visão Geral

Este projeto tem como objetivo demonstrar a construção de um sistema de loja virtual funcional, integrando recursos essenciais com foco em boas práticas, arquitetura em camadas e usabilidade.

**Funcionalidades principais:**

- ✅ Catálogo de produtos por categorias  
- ✅ Carrinho de compras com persistência em sessão  
- ✅ Autenticação com login tradicional e OAuth2  
- ✅ Painel administrativo completo para gestão de produtos  

---

## ⚙️ Tecnologias Utilizadas

| Tecnologia              | Finalidade                                      |
|------------------------|--------------------------------------------------|
| **ASP.NET MVC**         | Arquitetura web organizada por camadas          |
| **Entity Framework Core**| ORM para integração com banco de dados         |
| **SQLite**              | Banco de dados leve, embutido no projeto        |
| **Bootstrap**           | Estilização e responsividade do front-end       |
| **OAuth2**              | Login social (Google, Facebook, etc.)           |

---

## 🔧 Funcionalidades

### 🏷️ Catálogo de Produtos
- Exibição por categorias
- Busca de produtos
- Página de detalhes com informações completas

### 🛒 Carrinho de Compras
- Adição e remoção de itens
- Cálculo de subtotal e total
- Persistência do carrinho por sessão

### 🔐 Autenticação e Autorização
- Registro e login com senha
- Login com provedores externos (OAuth2)
- Perfis de acesso (Usuário e Administrador)

### ⚡ Painel Administrativo
- CRUD de produtos
- Gestão de estoque e categorias
- Acesso restrito a usuários administradores

---

## 📂 Estrutura do Projeto

```plaintext
LojaVirtual/
│
├── Controllers/
│   ├── ProdutoController.cs
│   ├── CarrinhoController.cs
│   └── ContaController.cs
│
├── Models/
│   ├── Produto.cs
│   ├── Categoria.cs
│   └── Usuario.cs
│
├── Views/
│   ├── Produto/
│   ├── Carrinho/
│   └── Conta/
│
├── Data/
│   ├── ApplicationDbContext.cs
│   └── Migrations/
│
├── wwwroot/
│   └── css, js, imagens etc.
│
└── Startup.cs / Program.cs
```

---

## 🚀 Como Executar

1. Clone este repositório:
   ```bash
   git clone https://github.com/victorbiguete/LojaProdutos
   ```

2. Abra a solução no Visual Studio

3. Execute as migrações:
   ```bash
   dotnet ef database update
   ```

4. Inicie a aplicação:
   ```bash
   dotnet run
   ```
   ou apenas pressione `F5` no Visual Studio

---

## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir **issues**, enviar **pull requests** ou sugerir melhorias.

---

## 📄 Licença

Este projeto está sob a licença **MIT**.  
Consulte o arquivo [`LICENSE`](LICENSE) para mais informações.

