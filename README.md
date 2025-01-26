# cdb

## Visão Geral

Este projeto consiste em dois componentes principais: uma aplicação cliente Angular e um servidor ASP.NET Core Web API. A aplicação cliente permite que os usuários calculem o valor final de um investimento em CDB (Certificado de Depósito Bancário) durante um período especificado, enquanto o servidor fornece os serviços de backend necessários para realizar os cálculos.

## Requisitos

Para executar este projeto, você precisará dos seguintes frameworks e dependências:

### Cliente (Angular)
- Node.js (versão 14 ou superior)
- Angular CLI (versão 19.1.4)
- Dependências listadas em `cdbApp/cdbapp.client/package.json`

### Servidor (ASP.NET Core Web API)
- .NET 6.0 SDK ou superior
- Configurações em `cdbApp/cdbApp.Server/appsettings.json`

## Configuração e Execução

### Cliente (Angular)

1. Navegue até o diretório do projeto cliente:
   ```bash
   cd cdbApp/cdbapp.client
   ```

2. Instale as dependências:
   ```bash
   npm install
   ```

3. Inicie o servidor de desenvolvimento:
   ```bash
   npm start
   ```

4. Abra o seu navegador e navegue para `https://localhost:49587/`.

### Servidor (ASP.NET Core Web API)

1. Navegue até o diretório do projeto servidor:
   ```bash
   cd cdbApp/cdbApp.Server
   ```

2. Restaure as dependências do .NET:
   ```bash
   dotnet restore
   ```

3. Execute o servidor:
   ```bash
   dotnet run
   ```

## Construção e Testes

### Cliente (Angular)

Para construir o projeto cliente, execute:
```bash
ng build
```


### Servidor (ASP.NET Core Web API)

Para construir o projeto servidor, execute:
```bash
dotnet build
```

Para executar os testes unitários, execute:
```bash
dotnet test
```

## Informações Detalhadas

Para mais informações detalhadas sobre os projetos cliente e servidor, consulte os seguintes arquivos:
- [Client README](cdbApp/cdbapp.client/README.md)
- [Server CHANGELOG](cdbApp/cdbApp.Server/CHANGELOG.md)
