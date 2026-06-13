# Sistema de Portaria Inteligente

## Sobre o Projeto

O Sistema de Portaria Inteligente é uma solução para controle de acesso em condomínios, eventos e ambientes institucionais. A plataforma utiliza QR Codes seguros baseados em JWT para autenticação de usuários, permitindo o registro e validação de acessos de forma rápida e segura.

O projeto está sendo desenvolvido seguindo os princípios da Clean Architecture, garantindo organização, escalabilidade e facilidade de manutenção.

## Funcionalidades Implementadas

### Usuários

* Cadastro de usuários
* Consulta de usuários cadastrados
* Geração de QR Code individual
* Geração de token JWT para autenticação

### Controle de Acesso

* Validação de QR Code
* Verificação de autenticidade do token
* Registro de acessos autorizados
* Histórico de logs de acesso

### Veículos

* Cadastro de veículos vinculados ao usuário
* Consulta de veículos cadastrados

## Funcionalidades Planejadas

* Reconhecimento facial
* Leitura de placas veiculares
* Dashboard administrativo
* Controle de operadores
* Relatórios de acesso
* Aplicação PWA
* Controle de visitantes e convidados

## Segurança

* Autenticação baseada em JWT
* QR Codes assinados digitalmente
* Controle de expiração de tokens
* Validação de acesso em tempo real
* Registro de auditoria

## Tecnologias Utilizadas

### Backend

* C#
* ASP.NET Core
* Entity Framework Core
* JWT Authentication

### Banco de Dados

* PostgreSQL

### Arquitetura

* Clean Architecture
* Repository Pattern
* Dependency Injection

## Estrutura do Projeto

* ParkingSystem.Domain
* ParkingSystem.Application
* ParkingSystem.Infrastructure
* ParkingSystem.Api
* ParkingSystem.Tests

## Objetivo

Automatizar e modernizar o controle de acesso, aumentando a segurança e reduzindo falhas operacionais por meio da utilização de QR Codes seguros e mecanismos de autenticação modernos.

## Status do Projeto

Em desenvolvimento.
Primeira entrega contendo estrutura arquitetural, autenticação via JWT, geração de QR Code, cadastro de usuários, cadastro de veículos e registro de acessos.
