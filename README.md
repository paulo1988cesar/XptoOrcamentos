# XptoOrcamentos
Projeto Entrevista

A aplicação foi desenvolvida utilizando a arquitetura DDD, Microsoft SQL Server, EntityFrameworkCore.

1) O projeto Data é responsável pela comunicação com a base de dados. 
   Para configurar a base de dados, deve-se modificar a string de conexão no arquivo ContextFactory e aplicar as migrations.
2) O projeto Domain é responsável pelos entidades de domínio da base de dados.
3) O projeto de Infra(CroosCutting) é resposável por configurar as depedências.
4) O projeto Services, implementa as interfaces criadas dentro do domínio.
5) E por último temos a aplicação WEB para o CRUD. Nesse projeto temos a string de conexão com a base de dados e ela deve ser modificada para executar a aplicação, depois de aplicada as migrations.
