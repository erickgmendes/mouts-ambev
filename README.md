Passo a passo para executar a aplicação
=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

1. Requisitos, 
 1.1. Ter instalado a versão 8 do .Net;
 1.2. Ter instalado o docker (no meu caso, usei a versão 27.3.1, build 2.fc41);

2. Pelo console, navegar até a pasta raiz do projeto e executar o comando: 
   $ docker compose up -d

3. Pelo console (bash ou powershell), navegar até a pasta onde está o projeto Ambev.DeveloperEvaluation.ORM "/src/Ambev.DeveloperEvaluation.ORM";
  3.1. Executar as migrations com o comando:
  $ dotnet ef database update  --startup-project ../Ambev.DeveloperEvaluation.WebApi --connection "Host=localhost;Port=5432;Database=developer_evaluation;Username=developer;Password=ev@luAt10n"

4. Abrir a solution Ambev.DeveloperEvaluation.sln que está na pasta raiz do projeto e marcar o projeto Ambev.DeveloperEvaluation.WebApi como startup project;

5. O projeto irá abrir com a interface do Swagger;

Utilizando a aplicação
=-=-=-=-=-=-=-=-=-=-=-

6. O projeto foi dividido em 5 apis (além das Apis de Auth e Users já existentes), com os devidos endpoints para:
  6.1. Branches: Api para o CRUD de Filiais;
    6.1.1. POST /api/Branches             Cria uma nova filial
    6.1.2. GET /api/Branches/{id}         Obtém uma filial pelo identificador
    6.1.3. DELETE /api/Branches/{id}      Remove uma filial pelo identificador
    6.1.4. PUT /api/Branches/{id}         Modifica uma filial pelo identificador
   
  6.2. Customers: Api para o CRUD de Clientes;
    6.2.1. POST /api/Customers            Cria um novo cliente
    6.2.2. GET /api/Customers/{id}        Obtém um cliente pelo identificador
    6.2.3. DELETE /api/Customers/{id}     Remove um cliente pelo identificador
    6.2.4. PUT /api/Customers/{id}        Modifica um cliente pelo identificador

  6.3. Products: Api para o CRUD de Produtos;
    6.3.1. POST /api/Products             Cria um novo produto
    6.3.2. GET /api/Products/{id}         Obtém um produto pelo identificador
    6.3.3. DELETE /api/Products/{id}      Remove um produto pelo identificador
    6.3.4. PUT /api/Products/{id}         Modifica um produto pelo identificador

  6.4. Sales: Api para o CRUD de Vendas;
    6.3.1. POST /api/Sales                Cria uma nova venda
    6.3.2. GET /api/Sales/{id}            Obtém uma venda pelo identificador (também traz a lista de itens associados à venda em questão)
    6.3.3. DELETE /api/Sales/{id}         Remove uma venda pelo identificador
    6.3.4. PUT /api/Sales/{id}            Modifica uma venda pelo identificador
    6.3.5. PUT /api/Sale/cancel/{id}      Cancela uma venda pelo identificador
  
  6.5. SaleItems: Api para o CRUD de Itens de Venda;
    6.5.1. POST /api/SaleItems            Cria um novo item de venda
    6.5.2. GET /api/SaleItems/{id}        Obtém um item de venda pelo identificador
    6.5.3. DELETE /api/SaleItems/{id}     Remove um item de venda pelo identificador
    6.5.4. PUT /api/SaleItems/{id}        Modifica um item de venda pelo identificador
    6.5.5.  PUT /api/SaleItem/cancel/{id}  Cancela um item de venda pelo identificador

7. Testes unitários
=-=-=-=-=-=-=-=-=-=

  7.1. Os testes unitários foram criados para verificar as classes Handle de Sale e SaleItem, pois contém as aplicações das regras de negócio;
  7.2. Para a execução dos testes unitários pelo console, navegar até a pasta raiz do projeto, entrar na pasta /tests/Ambev.DeveloperEvaluation.Unit$ e executar o comando:
       $ dotnet test
  7.3. Para executar os testes pela IDE, entrar na opção de execução dos testes unitários, executar o build da aplicação (Contrl + B no VisualStudio). 
       Após o build selecionar os testes e executá-los.
