# Iniciando.md

## Requisitos

- .NET 6.0 SDK
- Visual Studio Code ou qualquer IDE compatível com .NET
- Conexão com a internet para baixar pacotes NuGet

## Passos para Iniciar o Projeto

### 1. Clonar o Repositório

Clone o repositório do projeto para sua máquina local:

```sh
git clone <URL_DO_REPOSITORIO>
cd <NOME_DO_DIRETORIO>
```

### 2. Restaurar Dependências

Restaure as dependências do projeto utilizando o comando `dotnet restore`:

```sh
dotnet restore
```

### 3. Compilar o Projeto

Compile o projeto para garantir que tudo está configurado corretamente:

```sh
dotnet build
```

### 4. Executar o Projeto

Execute o projeto para iniciar a aplicação:

```sh
dotnet run --project <NOME_DO_ARQUIVO>.csproj
```

### 5. Utilização da Aplicação

Ao executar o projeto, você verá um menu no console com várias opções para filtrar e buscar ofertas. Siga as instruções no console para interagir com a aplicação.

### Estrutura do Projeto

- **Program.cs**: Contém a lógica principal da aplicação, incluindo o menu de interação e a chamada ao serviço de ofertas.
- **BACKQUERO.CSPROJ**: Arquivo de configuração do projeto .NET, incluindo referências a pacotes NuGet.
- **BACKQUERO.DEPS.JSON**: Arquivo gerado automaticamente que lista as dependências do projeto.

### Dependências

O projeto utiliza o pacote `Newtonsoft.Json` para manipulação de dados JSON. A versão especificada é a `13.0.3`.

### Comandos Úteis

- **Restaurar Dependências**: `dotnet restore`
- **Compilar o Projeto**: `dotnet build`
- **Executar o Projeto**: `dotnet run --project <NOME_DO_ARQUIVO>.csproj`

### Contribuição

Para contribuir com o projeto, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma nova branch para suas alterações: `git checkout -b minha-feature`
3. Faça commit das suas alterações: `git commit -m 'Adiciona minha feature'`
4. Envie para o repositório remoto: `git push origin minha-feature`
5. Abra um Pull Request.

### Contato

Para dúvidas ou sugestões, entre em contato com o mantenedor do projeto.

---

Siga estas instruções para configurar e iniciar o projeto BackQuero. Se encontrar algum problema, consulte a documentação oficial do .NET ou entre em contato com o mantenedor do projeto.
