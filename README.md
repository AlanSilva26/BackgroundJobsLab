# BackgroundJobsLab

Laboratório de estudos e implementação de **jobs agendados e assíncronos** utilizando **Hangfire** integrado ao **.NET 9**.  
O objetivo principal é explorar boas práticas de execução de rotinas de back-end em segundo plano, com monitoramento, persistência em banco de dados e execução dentro de containers.

---

## 🚀 Tecnologias Utilizadas

- **.NET 9 (C#)** – API principal do projeto
- **Hangfire** – Agendamento e execução de jobs em segundo plano
- **SQL Server** – Persistência de jobs e dados via Entity Framework Core
- **Entity Framework Core** – ORM para mapeamento e acesso ao banco
- **MongoDB.Driver** – Suporte a persistência NoSQL
- **MediatR** – Implementação de padrões CQRS e mediador
- **Serilog** – Logging estruturado, com sinks configuráveis (Console, File, Debug, etc.)
- **Swagger / Swashbuckle** – Documentação e testes de endpoints
- **Docker + docker-compose** – Containerização de API, banco e Hangfire Dashboard

---

## 📌 Funcionalidades

- Configuração de **jobs recorrentes** com CRON expressions  
- **Execução assíncrona** sem impacto no fluxo da aplicação principal  
- **Persistência de histórico** de jobs no SQL Server  
- Suporte a **MongoDB** para cenários de dados não-relacionais  
- Painel de monitoramento do **Hangfire** acessível via browser  
- **Logs estruturados** com Serilog  
- Documentação de API com Swagger/OpenAPI  
- Estrutura preparada para **escalabilidade horizontal** (multi-workers via Docker)  

---

## ⚙️ Estrutura do Projeto

```
BackgroundJobsLab/
│── BackgroundJobsLab.sln                # Solução principal
│── docker-compose.yml                   # Subida de containers (API + SQL Server + Hangfire)
│── src/
│   └── BackgroundJobsLab.Api/           # Projeto principal (API .NET 9 + Hangfire)
│       ├── Program.cs
│       ├── appsettings.json
│       ├── appsettings.Development.json
│       ├── BackgroundJobsLab.Api.csproj
```

---

## 🐳 Executando com Docker

1. **Subir containers**  
   ```bash
   docker-compose up -d
   ```

2. **Acessar aplicação**  
   - API: http://localhost:5111  
   - Hangfire Dashboard: http://localhost:5111/hangfire  

3. **Banco de Dados**  
   - SQL Server exposto em `localhost,14333`  

---

## 📖 Roadmap

- [x] Estrutura inicial do projeto (.NET 9 + Hangfire)  
- [x] Persistência de jobs no SQL Server  
- [x] Dockerização do ambiente  
- [x] Exemplos de jobs simples, recorrentes e parametrizados  
- [ ] Integração com notificações por e-mail  
- [ ] Automação de relatórios em background  

---

## 🧑‍💻 Autor

Projeto desenvolvido por **Alan Silva**, com foco em estudos avançados de **background jobs**, **containerização** e **boas práticas de backend em .NET 9**.
