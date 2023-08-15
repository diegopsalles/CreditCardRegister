# CreditCardRegister
Repositório para hyperativaChallange

#Introdução
API para cadastro de Cartões de Crédito de Clientes. Contendo, autenticação e autorização implementando a autenticação JWT.

#Pré-requisitos
- .NET 6
- Visual Studio Code (VS Code)
- SQl Server Express 2019 (LocalDB) [Microsoft Docs](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15/)

#Clonando o Projeto
Só realizar o git clone do projeto

```git clone https://github.com/diegopsalles/CreditCardRegister.git```

##appsettings.json

Precisamos de algumas configurações como conexão de banco de dados e detalhes para autenticação JWT.

appseting.json

#Migration
Com o comando ```dotnet ef add migration Initial``` vamos criar a estrutura inicial no banco de dados

ApplicationContext (Autehtication)
```dotnet ef migrations add Initial --context ApplicationContext```


CreditCardContext (Autehtication)
```dotnet ef migrations add Initial --context CreditCardContext```

Logo após podemos utilizar o comando ```dotnet ef database update``` para aplicar a migração.

ApplicationContext (Autehtication)
```dotnet ef database update --context ApplicationContext```


CreditCardContext (Autehtication)
```dotnet ef database update --context CreditCardContext```
