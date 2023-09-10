# Dotnet + Docker + Dapper + PostgreSQL 

Este é um exemplo de projeto .NET que utiliza o Dapper para acesso a dados e Docker para gerenciar um banco de dados PostgreSQL.
A finalidade dele é demonstrar como importar dados de investimentos para uma base de dados.


## Configurando o Banco de Dados PostgreSQL

Antes de executar o projeto, você precisará configurar um banco de dados PostgreSQL usando Docker. Você pode fazer isso com o seguinte comando:

```shell
docker run --name db-local -e POSTGRES_PASSWORD=102030 -d -p 5432:5432 postgres
```

Isso iniciará um contêiner Docker com o PostgreSQL e define a senha do PostgreSQL como "102030". Você pode ajustar a senha e outras configurações conforme necessário.

### Criando uma Carga Inicial de Dados

Para criar uma carga inicial de dados na tabela "quotes", você pode executar o seguinte comando SQL após o PostgreSQL estar em execução:

```shell
INSERT INTO quotes (symbol, exchange, regularMarketPrice)
VALUES
    ('AAPL', 'NASDAQ', 150.25),
    ('GOOGL', 'NASDAQ', 2700.50),
    ('MSFT', 'NASDAQ', 300.75),
    ('AMZN', 'NASDAQ', 3500.00),
    ('TSLA', 'NASDAQ', 750.60);
```

Este comando SQL insere registros fictícios na tabela "quotes". Certifique-se de que o banco de dados esteja em execução e acessível antes de executar este comando.

## Executando o Projeto

Agora que o banco de dados está configurado e contém dados iniciais, você pode executar o projeto .NET. Certifique-se de ajustar as configurações de conexão com o banco de dados no arquivo de configuração do projeto, como o appsettings.json, para refletir as configurações do seu banco de dados PostgreSQL.

Para executar o projeto, use o Visual Studio, o Visual Studio Code ou o comando `dotnet run`.

