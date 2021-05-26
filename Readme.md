# Projeto Capegmini

## Tecnologias utilizadas:

- Mediatr
- Dapper
- UnitOfWork
- SqlServer
- RabbitMq

## Preparação de ambiente:
Para ver o projeto funcionando, basta criar um banco de dados com o nome restaurantecapegmini e alterar a string de conexão dentro de appsettings.json
As tabelas serão criadas automaticamente.


##Rabbit Mq Receiver 
- Foi criado um projeto console, para que as mensagens entregues no rabbitmq sejam trafegadas e recebidas, para que possa visualizar a fila, basta trocar o campo   channel.QueueDeclare(queue: "frito" 
- e o campo  channel.BasicConsume(queue: "frito" para o nome do departamento em questão (bebidas, grelhado, frito, sobremesa e etc.)
