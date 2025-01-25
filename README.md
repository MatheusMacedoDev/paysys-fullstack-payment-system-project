<p align="center">
        <img src="https://github.com/MatheusMacedoDev/paysys-backend/assets/67438868/d9906410-5d4a-4f30-903a-a5f4d8c5e0c2" /> 
        <h1 align="center">PaySys</h1>
</p>

<p align="center">
        <a aria-label="Portfólio - Matheus Macedo Santos" href="https://matheusmacedo.dev.br/"><img src="https://img.shields.io/badge/Portf%C3%B3lio-Matheus%20Macedo-931ad9" /></a> <a aria-label="License: MIT" href="https://github.com/MatheusMacedoDev/paysys-backend/blob/main/LICENSE"><img src="https://img.shields.io/badge/license-MIT-green)" /></a>
</p>

## :bulb: Sobre o Projeto

**PaySys** é uma abreviação de **Payment System (Sistema de Pagamento)**, o que resume as funcionalidades da aplicação. O sistema foi feito baseado no [Desafio Back-end do PicPay](https://github.com/PicPay/picpay-desafio-backend), porém suas features não se limitam a um **PicPay Simplificado**, abrangindo um escopo relativamente maior que foi pensado no uso atual e posterior do projeto. De início, os requisitos da aplicação foram pensados como um desafio para a minha própria evolução, me forçando a fazer um projeto utilizando de diversas boas práticas (como **Domain-Driven Design**, **Test-Driven Design** e os princípios **SOLID** no geral), além de tecnologias nunca antes usadas por mim. Trabalhei por meses nesse projeto e, chegando próximo ao fim do back-end do mesmo, espero este sistema sirva como um dos projetos de meu [Portfólio Pessoal](https://matheusmacedo.dev.br/).

**Implantação:** [Link para o projeto funcionando](https://paysys-fullstack-payment-system-project.onrender.com/index.html)

![PaySys Figma](https://github.com/MatheusMacedoDev/paysys-backend/assets/67438868/25cd8af5-cf6c-4378-937b-d865bb9a8a30)

## :wrench: Tecnologias

### Back-end

- C# (linguagem selecionada)
- Entity Framework Core (ORM para o code-first)
- Dapper (consultas)
- Flunt (validações)
- PostgreSQL (banco de dados)
- JWT (autenticação e autorização)
- Argon2id (criptografia)
- Swagger (documentação da API)
- MailKit e MimeKit (envio de e-mails)
- XUnit (testes unitários e de integração)
- Handlebars.Net (templates HTML)
- Docker (conteinerização)
- Docker Compose (lida com vários contêineres)
- Render (deploy)

### Front-end

- Next.js (framework React)
- Tailwind CSS (framework CSS)
- Tailwind Merge (une strings tailwind evitando conflitos)
- PostCSS (transforma JS em CSS)
- TypeScript (adição de tipos ao JavaScript)
- ESLint (linter para JavaScript e TypeScript)
- Prettier (formatador de código)
- Font Awesome (ícones)

### Implantação

Nada para ver ainda...

## :scroll: Funcionalidades

Aqui estão descritas todas as funcionalidades do projeto:

### API (Back-end)

- [x] Listar, listar dados específicos, criar, atualizar e deletar tipos de usuário;
- [x] Criar usuários dos tipos: comuns, lojistas e administradores;
- [x] Listar de forma resumida os dados dos usuário, para cada tipo;
- [x] Listar os dados de um usuário específico, para cada tipo;
- [x] Fazer login gerando um token JWT que será usado para autenticação e autorização;
- [x] Criar e listar status que uma tranferência pode ter;
- [x] Criar e listar categorias as quais uma transferência pode participar;
- [x] Fazer um transferência (pagamento) de uma conta para outra;
- [x] Listar histórico de transferências de um usuário específico;
- [x] Listar dados de uma transferência específica;
- [x] Enviar e-mail de boas-vindas para novos usuários;
- [x] Enviar um e-mail assim que uma tranferência é realizada envolvendo o usuário;
- [ ] Transferir dados sensíveis para variáveis de ambiente;
- [ ] Adicionar autorização para todas as rotas.

## :book: Planejamento

### Diagramas

Aqui estão os diagramas de modelagem de banco de dados, tanto conceitual quanto lógico. O modelo físico foi considerado desnecessário para esse projeto.

![PaySys Diagrams (without background)](https://github.com/MatheusMacedoDev/paysys-backend/assets/67438868/347e9038-f076-4b21-ba98-936023c0263a)

### Organização (com Trello)

A organização das tarefas, datas de entregas e atribuições foi feita utilizando a ferramenta Trello.

![PaySys Trello](https://github.com/MatheusMacedoDev/paysys-backend/assets/67438868/6101d017-d581-44ce-8180-3a5184784099)

## :pushpin: Pré-requisitos

Antes de fazer a instalação algumas ferramentas e softwares são necessárias para iniciar esse processo posteriormente:

### Back-end

- Um editor de código com suporte a linguagem C#, como: [Visual Studio](https://visualstudio.microsoft.com/pt-br/), [VS Code](https://code.visualstudio.com/) ou [NeoVim](https://neovim.io) (minha opção);
- Ter .NET 8 ou superior instalado e adicionado ao PATH do sitema, através do [site oficial](https://dotnet.microsoft.com/pt-br/download) ou de um gerenciador de versões de runtimes como o [ASDF](https://asdf-vm.com/);
- O gerenciador de banco de dados PostgreSQL 16 instalado e configurado através do [instalador oficial](https://www.postgresql.org/download/]) ou de uma [imagem docker](https://hub.docker.com/_/postgres).
- Ter o [Git](https://git-scm.com/) instalado.

## :floppy_disk: Instalação

O processo de instalação está brevemente descrito a seguir:

### Back-end

Primeiramente, deve-se clonar o repositório na sua máquina local com o seguinte comando:

```
git clone https://github.com/MatheusMacedoDev/paysys-backend.git
```

Depois, deve-se baixar todas as dependências do projeto usando o seguinte comando do [.NET CLI](https://learn.microsoft.com/pt-br/dotnet/core/tools/) na raiz do projeto da API (não de testes):

**.NET CLI**

```
dotnet restore
```

Então, você deverá modificar o arquivo _appsettings.json_, em especial na parte relativa a string de conexão que deve ser alterada para as configurações, como indicado no trecho a seguir:

```json
"ConnectionStrings": {
        "LocalConnection": "Host = localhost; Port = your-database-port; Pooling = true; Database = database-name; User Id = your-user; Password = your-password"
},
```

Os seus dados devem ser colocadas substituindo os campos acima. Mais detalhes sobre strings de conexão no Entity Framework Core podem ser vistas [aqui](https://www.macoratti.net/17/05/aspcore_pgsqlef1.htm).
Logo em seguida, deve-se executar o seguinte comando que vai gerar o banco de dados que foi especificado na string de conexão. Portanto, se houver algum erro na string de coneção, o comando falhará.

**.Net CLI**

```
dotnet ef update database
```

Por fim, agora é só executar a aplicação usando o seguinte comando

**.Net CLI**

```
dotnet watch run
```
