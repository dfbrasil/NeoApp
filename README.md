# README - Projeto NeoApp.API

Este documento README destina-se a fornecer uma visão geral e insights sobre o desenvolvimento do projeto NeoApp.API. Como desenvolvedor sênior, tomei decisões específicas relacionadas à arquitetura, design e implementação para garantir a eficiência, escalabilidade e manutenibilidade do sistema.

## Arquitetura Geral

O projeto NeoApp.API foi desenvolvido como uma aplicação ASP.NET Core utilizando o padrão MVC (Model-View-Controller). A escolha do ASP.NET Core foi motivada pela sua performance, modularidade e suporte multiplataforma. A aplicação é dividida em controladores para cada entidade principal do sistema (Consulta, Médico, Paciente) seguindo princípios RESTful.

A arquitetura da API é orientada a serviços e adota um design baseado em interfaces para promover a flexibilidade e a testabilidade do código. Utilizei o Entity Framework Core como ORM (Object-Relational Mapping) para facilitar a interação com o banco de dados SQL Server.

## Swagger para Documentação da API

Optei por integrar o Swagger para documentação da API. O Swagger fornece uma interface interativa para explorar e testar a API. Além disso, usei filtros personalizados para adicionar descrições detalhadas para cada operação, facilitando a compreensão e o consumo da API.

## Segurança e Autenticação

Implementei um sistema de autenticação baseado em JWT (JSON Web Token) usando o middleware JwtBearer. Isso permite que os endpoints da API sejam acessados apenas por usuários autenticados, garantindo a segurança dos dados sensíveis. A chave JWT é gerada e validada com base em um segredo compartilhado.

## Estrutura do Banco de Dados

Utilizei o Entity Framework Core para mapear e interagir com o banco de dados SQL Server. A estrutura do banco de dados segue as melhores práticas de modelagem, com tabelas para Consulta, Médico e Paciente, mantendo relacionamentos apropriados.

## Considerações de Design

**1. Filtros de Operação Personalizados:**
   - Introduzi filtros de operação personalizados no Swagger para fornecer descrições detalhadas e amigáveis para cada operação da API. Isso facilita o entendimento e uso da API.

**2. Separação de Responsabilidades:**
   - Mantive uma clara separação de responsabilidades entre os controladores, serviços e repositórios. Cada camada tem uma função específica, promovendo a coesão e reduzindo o acoplamento.

**3. Controle de Acesso por Função:**
   - Utilizei atributos de autorização para controlar o acesso aos endpoints com base nas funções do usuário (Paciente, Médico). Isso garante que apenas usuários autorizados possam realizar determinadas ações.

## Como Contribuir

Se você deseja contribuir para o projeto NeoApp.API, siga estas etapas:

1. Faça um fork do repositório.
2. Crie uma branch para sua feature (`git checkout -b feature/nome-da-feature`).
3. Faça commit das suas alterações (`git commit -am 'Adiciona nova feature'`).
4. Faça push para a branch (`git push origin feature/nome-da-feature`).
5. Abra um pull request.

## Ambiente de Desenvolvimento

Certifique-se de ter o .NET Core SDK instalado em sua máquina. Para executar o projeto, utilize o comando:

```bash
dotnet run

Acesse a documentação da API no Swagger através do URL: http://localhost:5000/swagger.

##Considerações Finais
Este README destaca as principais decisões e considerações tomadas durante o desenvolvimento do projeto NeoApp.API. Essas escolhas foram feitas com base nas melhores práticas, visando criar uma aplicação robusta, escalável e de fácil manutenção. Obrigado por contribuir e usar este projeto!

Daniel Brasil
Data: 12/12/2023
