# Semeando

Semeando é um sistema para gerenciar usuários, níveis e perguntas, fornecendo funcionalidades de cadastro, consulta e edição. Este projeto foi desenvolvido com ASP.NET Core e segue o padrão de arquitetura MVC (Model-View-Controller). Ele permite que administradores possam gerenciar dados de usuários, níveis, perguntas e outras entidades relacionadas.

## Funcionalidades

- **Cadastro de Usuário**: Permite a criação de novos usuários com informações como nome, email e ranking.
- **Consulta de Usuários**: Exibe uma lista de todos os usuários cadastrados no sistema.
- **Edição de Usuário**: Permite editar os dados de um usuário existente.
- **Exclusão de Usuário**: Permite excluir um usuário existente.
- **Cadastro, Consulta e Edição de Níveis, Perguntas, Opções e Respostas**: Funcionalidades similares às de usuário para as demais entidades.

## Estrutura do Projeto

O projeto segue a estrutura MVC, com separação de responsabilidades para facilitar a manutenção e escalabilidade. A estrutura do projeto é composta pelas seguintes camadas:

- **Controllers**: Contém os controladores que gerenciam as rotas e a interação com as views.
- **Views**: Contém as páginas HTML que são renderizadas para o usuário final.
- **Models**: Contém as classes que representam as entidades e a lógica de validação.
- **Domain**: Contém as entidades de domínio e interfaces para comunicação com o banco de dados.
- **Interfaces**: Define contratos para repositórios que interagem com o banco de dados.

## Requisitos

- .NET 6.0 ou superior
- SQL Server ou outro banco de dados relacional (configurável)
- Visual Studio ou VS Code com suporte para C# e .NET

# Rotas e Endpoints

## Usuário

### Cadastro de Usuário

- **Método**: Exibição do formulário de cadastro
  - Recupera e prepara os dados para o formulário de novo usuário
- **Método**: Submissão de cadastro
  - Processa o formulário e cria um novo usuário no sistema
  - Valida as informações inseridas
  - Redireciona após cadastro bem-sucedido

### Consulta de Usuário

- **Método**: Listagem de usuários
  - Recupera todos os usuários cadastrados
  - Exibe em formato de lista ou tabela
  - Permite visualização detalhada

### Edição de Usuário

- **Método**: Carregamento do formulário de edição
  - Busca dados do usuário específico
  - Preenche formulário com informações atuais
- **Método**: Submissão da edição
  - Atualiza informações do usuário
  - Valida dados modificados
  - Redireciona após atualização

### Exclusão de Usuário

- **Método**: Remoção de usuário
  - Remove usuário do sistema
  - Executa validações de permissão
  - Mantém integridade referencial

## Estrutura de Diretórios

### Camadas Principais

- **Controladores**: 
  - Gerenciamento de requisições HTTP
  - Intermediação entre modelo e visualização
  - Processamento de regras de negócio simples

- **Visualizações**: 
  - Arquivos de interface (.cshtml)
  - Renderização de conteúdo dinâmico
  - Implementação da camada de apresentação

- **Modelos**: 
  - Definição de DTOs
  - Representação de entidades
  - Validações de dados

- **Domínio**: 
  - Entidades core do sistema
  - Interfaces de repositório
  - Regras de negócio fundamentais

- **Recursos Estáticos**: 
  - Arquivos CSS
  - Scripts JavaScript
  - Imagens e ícones
  - Recursos de design
