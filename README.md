# FIAP - HACKATHON
## API de Agendamento de Consultas Médicas

Esta é uma API para o agendamento de consultas médicas desenvolvida em C# utilizando o framework .NET. A API fornece endpoints para realizar operações relacionadas a usuários, agenda médica e agendamentos de consulta.

## Configuração do Ambiente

1. **Pré-requisitos:**
   - [.NET SDK](https://dotnet.microsoft.com/download/)
   - [Postgres](https://www.postgresql.org/download/)

2. **Configuração do Banco de Dados:**
   - Execute a migration para a criação das tabelas no banco de dados com o comando abaixo:
   
   Visual Studio
   ```bash
   Update-Database

   CLI do .NET
   ```bash
   dotnet ef database update

   - Execute os scripts de criação de tabelas localizados em `DatabaseScripts` no seu servidor SQL Server.

3. **Configuração da Aplicação:**
   - Abra o arquivo `appsettings.json` e atualize a string de conexão com o banco de dados.
   -- Sugestão: Utilizar o [Supabase] (https://supabase.com/), para hospedagem do banco de dados.
   - Alterar as configurações do SMTP
   -- Sugestão: Utilizar o [Sendgrip] (https://sendgrid.com/en-us), para envio do e-mails.

## Como Executar a Aplicação

1. Navegue até o diretório raiz da aplicação no terminal.

2. Execute o seguinte comando para restaurar as dependências, compilar e executar a aplicação:

   ```bash
   dotnet run

3.Acesse a API em `http://localhost:5258` no seu navegador ou através de ferramentas como o Postman.

## Documentação da API
A documentação da API está disponível no endpoint /swagger. Acesse `http://localhost:5258/swagger` para explorar os endpoints e testar as operações.

**Endpoints Principais**
- Autenticação

  - `POST /login: Login do usuário no sistema.`

- Usuários:

  - `POST /api/user: Criação de usuários.`

- Agendas:

  - `POST /api/schedule: Criação de agenda para atendimento.`
  - `GET /api/doctor/{id}/schedule: Lista toda a agenda do médico.`
  - `GET /api/doctor/{id}/avaliable-schedule: Lista somente a agenda disponível do médico.`

- Médicos:

  - `GET /api/doctor: Lista todos os médicos disponíveis.`

- Consultas:

  - `POST /api/medicalAppointment: Criação de agendamento.`
  - `GET /api/medicalAppointment/{id}: Consulta um agendamento específico.`
  
Para mais detalhes sobre os endpoints e seus parâmetros, consulte a documentação da API.

## Contribuição
Contribuições são bem-vindas! Antes de contribuir, abra uma issue para discutir as mudanças propostas.

## Nome dos participantes
André Fonseca -  RM353003
Cleyber Silva - RM353086
Gustavo Kazuo - RM352485
Janderson Campelô - RM352814

## Licença
Este projeto está licenciado sob a MIT License - veja o arquivo LICENSE para detalhes.

**Desenvolvido por André Fonseca et al. | 2024**
