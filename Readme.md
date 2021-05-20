﻿# Projeto Capegmini

## Tecnologias utilizadas:

- Mediatr
- Dapper
- UnitOfWork
- Mysql
### Pontos de consideração:
- Optei por usar o mysql devido ao fato de já possuir um servidor para testes. A conexão com o banco esta no appsettings.json

- Usei como documentação o swagger , colocando alguns dataannotations do mesmo.

- Criei somente alguns metodos para cada endpoint, justamente devido o tempo de projeto, onde todos estão devidamente testados

-Como o envio para cada setor (churrascaria, confeitaria e afins) não estava estipulado, utilizei apenas uma mensagem de envio informando para qual area responsável o pedido será enviado