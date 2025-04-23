# 🛍️ E-Commerce em ASP.NET MVC  

Um projeto de loja virtual desenvolvido com **ASP.NET MVC, Entity Framework Core, SQLite e OAuth2** para fins de aprendizado.  

---

## 📌 Visão Geral  
Simulação de um e-commerce funcional com:  
✔️ Catálogo de produtos  
✔️ Carrinho de compras  
✔️ Autenticação (OAuth2 + login tradicional)  
✔️ Painel administrativo  

---

## 🛠 Tecnologias  
| **Tecnologia**       | **Uso**                                                                 |
|----------------------|-------------------------------------------------------------------------|
| ![ASP.NET](https://img.shields.io/badge/ASP.NET_MVC-5C2D91?logo=.net) | Arquitetura MVC |
| ![EF Core](https://img.shields.io/badge/EF_Core-512BD4?logo=entity-framework) | ORM para banco de dados |
| ![SQLite](https://img.shields.io/badge/SQLite-003B57?logo=sqlite) | Banco de dados embutido |
| ![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?logo=bootstrap) | Front-end responsivo |
| ![OAuth2](https://img.shields.io/badge/OAuth2-EB5424?logo=auth0) | Autenticação social |

---

## ⚙️ Funcionalidades  
### 🏷️ Catálogo de Produtos  
- Listagem por categorias  
- Busca integrada  
- Páginas de detalhes  

### 🛒 Carrinho de Compras  
- Adição/remoção de itens  
- Cálculo de total  
- Persistência em sessão  

### 🔐 Autenticação  
- Login com Google (OAuth2)  
- Registro manual  
- Controle de acesso (Admin/Usuário)  

### ⚡ Painel Admin  
- CRUD de produtos  
- Gerenciamento de estoque  

---

## 🚀 Como Executar  
```bash
# 1. Clone o repositório
git clone https://github.com/seu-usuario/ecommerce-mvc.git

# 2. Restaure pacotes
dotnet restore

# 3. Execute as migrations
dotnet ef database update

# 4. Inicie o servidor
dotnet run

