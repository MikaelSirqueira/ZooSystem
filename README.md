<h1 align="center"> 🗺️ ZooSystem 🎠 </h1>

  
## 💻 Projeto/ Funcionalidades implementadas

- Esta API foi desenvolvida para gerenciar animais e os cuidados associados a eles, permitindo o registro, atualização, listagem e exclusão de animais e cuidados.
- Dos requisitos básicos:
  - Somente o relacionemento entre as duas entidades que não consegui finalizar.
  - Implementei o Front-end com TypeScript.
- Dos desafios adicionais:
  - Utilizado SQL Server
  - Adicionei filtros avançados somente no Back-end. Se rodar por meio do Swagger é possível visualizar isso.

<br>

## 🔎 Para Rodar

Necessário ter/instalar:

BACK-END
- Visual Studio, apontando para a pasta onde está a solução do projeto (arquivo .sln)
- .Net 8
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer
- FluentValidation
- Dapper
- E configurar o data source no appsetting.json
  - Onde está "LAPTOP-K4HO4U59\\SQLEXPRESS", adicione seu usuário do SQL Server.

FRONT-END
- Entrar na pasta do front, abrir o terminal e rodar:
  - **npm i**

Para Rodar
- Ao rodar a aplicação no Visual Studio, será gerado o banco de dados com alguns dados.
- E para rodar o front-end, é necessário rodar o comando: **npm run dev**.

<br>

## 👻 Dificuldades
- Durante o desenvolvimento, enfrentei uma dificuldade inicial ao tentar conectar ao SQL Server com meu usuário. A aplicação apresentava o seguinte erro:"A network-related or instance-specific error occurred while establishing a connection to SQL Server...". Levei um tempo para identificar e resolver o problema, o que atrasou um pouco o andamento do projeto.
- No geral, o restante da implementação transcorreu de forma tranquila. No entanto, não consegui concluir todos os pontos do teste. A parte do relacionamento entre Animais e Cuidados, por exemplo, não foi completada no front-end — atualmente os dados estão mockados. A implementação completa no back-end acabou ficando pendente desta parte.
- Algumas decisões relacionadas à estruturação do projeto levaram mais tempo do que o esperado, especialmente no planejamento e organização de uma arquitetura mais adequada para a aplicação.

**Apesar dos obstáculos, consegui avançar bem na proposta e acredito que o projeto transmite claramente as intenções da arquitetura e da lógica esperada.**

<br>

## Finalização ❤

Feito por Mikael Sirqueira
