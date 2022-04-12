# GRA

Golden Raspberry Awards CSV Importer

# INSTRUÇÕES

## Banco de Dados

A aplicação utiliza um banco de dados SQLite imbutido e já configurado. Caso necessário, string de conexão pode ser configurada no arquivo Appsettings.json.

## Como rodar o projeto

O projeto pode ser rodado a partir de um terminal aberto na pasta src. Para fazê-lo, basta utilizar o comando:
	
	- dotnet run --project Textor.GRA.Service

O projeto também pode ser rodado com uma IDE (Visual Studio, Rider, etc.), desde que comporte o .NET 5.

## Como rodar os testes

Os testes de integração podem ser rodados a partir de um terminal aberto na pasta src. Para fazê-lo, basta utilizar o comando:

	- dotnet test

Os testes de integração também podem ser rodados com uma IDE (Visual Studio, Rider, etc.), desde que comporte o .NET 5.

## Como o projeto funciona

Ao iniciar, o projeto irá importar um arquivo CSV previamente configurado. O caminho do CSV pode ser configurado no arquivo Appsettings.json.
Caso não exista o arquivo, nada será importado. O projeto não irá duplicar as informações de Filme/Ano. Uma vez inserido no banco, caso seja importado novamente, o projeto irá apenas ignorar a informação do arquivo CSV.

O projeto não realiza limpeza de banco de dados. Se necessário, a limpeza do banco de dados deve ser feita com uma ferramenta para consulta em banco SQLite (Exemplo: Dbeaver).