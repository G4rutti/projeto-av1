# projeto-av1

Sistema ASP.NET Core MVC (.NET 8) com 3 CRUDs (Clientes, Produtos e Fornecedores), banco SQLite e padrão Repository.

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (ou mais recente, com o runtime do .NET 8 instalado)

Não é preciso instalar o SQLite nem rodar migrations: o arquivo `app.db` e as tabelas são criados sozinhos na primeira execução.

## Como rodar

### Pelo Visual Studio

1. Abra o arquivo `projeto-av1.sln`.
2. Aperte **F5** (ou clique em ▶ Executar).
3. O navegador abre na página inicial. Use o menu para acessar **Clientes**, **Produtos** e **Fornecedores**.

### Pelo terminal

Na pasta raiz do repositório:

```bash
cd projeto-av1
dotnet run
```

Abra no navegador o endereço que aparecer no terminal (ex.: `http://localhost:5xxx`).

## Observações

- No campo **Preço**, use ponto como separador decimal (ex.: `10.50`).
- Para zerar os dados, pare a aplicação e apague o arquivo `projeto-av1/app.db`. Ele é recriado na próxima execução.

## Estrutura

| Pasta | Conteúdo |
|---|---|
| `Models/` | `Cliente`, `Produto`, `Fornecedor` |
| `Data/` | `AppDbContext` (EF Core + SQLite) |
| `Interfaces/` | `IRepository<T>` (contrato do repositório) |
| `Repositories/` | `Repository<T>` (genérico) + `ClienteRepository`, `ProdutoRepository`, `FornecedorRepository` |
| `Controllers/` | Um controller por entidade, que recebe o repositório por injeção de dependência |
| `Views/` | Telas `Index` (lista + excluir), `Details` e `Form` (cadastro/edição) de cada entidade |
