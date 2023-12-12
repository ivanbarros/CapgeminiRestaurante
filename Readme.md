# Projeto Capegmini

## Versão do projeto

- 1.0 (Este projeto fora desenvolvido pela primeira vez em .NET CORE 2.0)
- 2.0 (Atualizado para a versão .NET CORE 2.1)
- 3.0 (Atualizado para a versão .NET CORE 3.1)
- 4.0 (Atualizado para a versão .NET 8.0)

## Tecnologias utilizadas:

- Mediatr
- Dapper
- UnitOfWork
- SqlServer
- RabbitMq

## Preparação de ambiente:
Para ver o projeto funcionando, basta criar um banco de dados com o nome restaurantecapegmini e alterar a string de conexão dentro de appsettings.json.
O banco de dados testado foi o SQL SERVER, no caso o NAMED PIPE dentro do SQL CONFIGURATION MANAGER tem que estar habilitado.
No caso do teste utilizei um login e senha, porém não é obrigatório, somente certifique-se de alterar a connectionString dentro do appsettings.json, removendo o campo login e senha.
As tabelas serão criadas automaticamente.


##Rabbit Mq Receiver 
- Foi criado um projeto console, para que as mensagens entregues no rabbitmq sejam trafegadas e recebidas, para que possa visualizar a fila, basta trocar o campo   channel.QueueDeclare(queue: "frito" 
- e o campo  channel.BasicConsume(queue: "frito" para o nome do departamento em questão (bebidas, grelhado, frito, sobremesa e etc.)
