# 📝 Markdown Note-Taking API

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)
![Status](https://img.shields.io/badge/Status-Completed-success)
![License](https://img.shields.io/badge/License-MIT-blue)

[🇺🇸 English version below](#-markdown-note-taking-api-english)

---

## 🇧🇷 Sobre o Projeto

Este projeto consiste em uma API RESTful para gerenciamento, upload, verificação gramatical e renderização de notas em formato Markdown.

Ele foi desenvolvido como solução para o desafio **[Markdown Note-taking App](https://roadmap.sh/projects/markdown-note-taking-app)** do site [roadmap.sh](https://roadmap.sh), focado em aprofundar conhecimentos em Backend Development.

### 🚀 Funcionalidades
* **Upload de Arquivos:** Envio de arquivos `.md` que são processados e salvos no banco de dados.
* **Renderização HTML:** Conversão automática de Markdown para HTML seguro usando **Markdig** e **HtmlSanitizer**.
* **Verificação Gramatical:** Integração com a API do **[LanguageTool](https://dev.languagetool.org/public-http-api.html)** para identificar erros de escrita.
* **Gerenciamento (CRUD):** Criação, leitura e listagem de notas.

### 🧠 Arquitetura e Aprendizados
O foco principal deste projeto foi a aplicação de **Clean Code** e boas práticas de arquitetura no ecossistema .NET 9:

1.  **Separação de Responsabilidades:**
    * **Controllers:** Apenas gerenciam a entrada/saída HTTP.
    * **Services Layer:** Contém a lógica de negócio, validações e orquestração.
    * **Repository Pattern:** Abstração do acesso a dados, facilitando testes e manutenção.
2.  **DTOs (Data Transfer Objects):** Uso estrito de DTOs (`record`) para blindar a entidade de banco de dados (`Note`).
3.  **Integração Externa:** Uso da biblioteca **RestEase** para consumir a API do LanguageTool via interfaces de maneira simples.

### 🛠️ Tecnologias Utilizadas
* **Core:** ASP.NET Core 9 (Web API)
* **Banco de Dados:** SQLite com Entity Framework Core
* **Markdown:** Markdig e HtmlSanitizer
* **Integrações:** RestEase (LanguageTool API)
* **Documentação:** Scalar / OpenAPI

---

### ⚙️ Como Executar Localmente

**Pré-requisitos:**
* [.NET 9 SDK](https://dotnet.microsoft.com/download) instalado.

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/ramos-leticia/MarkdownNoteTakeApi.git
    cd markdown-note-api
    ```

2.  **Restaure os pacotes:**
    ```bash
    dotnet restore
    ```

3.  **Configure o Banco de Dados (SQLite):**
    Execute as migrations para criar o arquivo `.db` localmente.
    ```bash
    dotnet ef database update
    ```

4.  **Execute a API:**
    ```bash
    dotnet run
    ```

5.  **Acesse a Documentação:**
    Abra seu navegador e acesse: `http://localhost:{{porta}}/scalar/v1` (porta indicada no seu terminal).

---

# 🇺🇸 Markdown Note-Taking API (English)

## About the Project

This project is a RESTful API for managing, uploading, grammar checking, and rendering Markdown notes.

It was built as a solution for the **[Markdown Note-taking App](https://roadmap.sh/projects/markdown-note-taking-app)** challenge from [roadmap.sh](https://roadmap.sh), focused on mastering Backend Development concepts.

### 🚀 Features
* **File Upload:** Upload `.md` files which are parsed and stored in the database.
* **HTML Rendering:** Automatic conversion from Markdown to secure HTML using **Markdig** and **HtmlSanitizer**.
* **Grammar Check:** Integration with the **[LanguageTool](https://dev.languagetool.org/public-http-api.html)** to detect writing errors in real-time.
* **Management (CRUD):** Create, read, and list notes.

### 🧠 Architecture & Key Learnings
The main goal was to apply **Clean Code** principles and architectural best practices within the .NET 9 ecosystem:

1.  **Separation of Concerns:**
    * **Controllers:** Only handle HTTP input/output.
    * **Services Layer:** Contains all business logic, validations, and orchestration.
    * **Repository Pattern:** Complete abstraction of data access, enabling easier testing and maintenance.
2.  **DTOs (Data Transfer Objects):** Strict use of DTOs (`records`) to shield the database entity (`Note`).
3.  **External Integration:** Usage of **RestEase** library to consume the LanguageTool API via interfaces, avoiding verbose untyped `HttpClient` usage.

### 🛠️ Tech Stack
* **Core:** ASP.NET Core 9 (Web API)
* **Database:** SQLite with Entity Framework Core
* **Markdown:** Markdig and HtmlSanitizer
* **Integrations:** RestEase (LanguageTool API)
* **Documentation:** Scalar / OpenAPI

---

### ⚙️ How to Run Locally

**Prerequisites:**
* [.NET 9 SDK](https://dotnet.microsoft.com/download) installed.

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/ramos-leticia/MarkdownNoteTakeApi.git
    cd markdown-note-api
    ```

2.  **Restore packages:**
    ```bash
    dotnet restore
    ```

3.  **Setup Database (SQLite):**
    Run migrations to create the local `.db` file.
    ```bash
    dotnet ef database update
    ```

4.  **Run the API:**
    ```bash
    dotnet run
    ```

5.  **Access Documentation:**
    Open your browser at: `http://localhost:5000/scalar/v1` (check your terminal for the correct port).
