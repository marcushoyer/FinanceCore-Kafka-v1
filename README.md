# 🏦 FinanceCore - Módulo de Saldos (Worker)

Este serviço é um **Worker .NET** focado em processamento de eventos financeiros de alta performance, utilizando uma arquitetura baseada em eventos (Event-Driven Architecture).

## 🚀 Fluxo de Dados
1. A **API de Transações** publica um evento `MovimentacaoRealizada` no **Apache Kafka**.
2. Este **Worker** consome a mensagem via **MassTransit**.
3. O saldo é processado e persistido em um banco **PostgreSQL** rodando em Docker.

## 🛠️ Tecnologias Utilizadas
- **.NET 8/9** (C#)
- **MassTransit** (Abstração de mensageria)
- **Apache Kafka** (Broker de mensagens)
- **Entity Framework Core** (ORM)
- **PostgreSQL** (Banco de dados relacional)

## 🏗️ Padrões de Projeto
- **Repository Pattern** para abstração de dados.
- **Domain-Driven Design (DDD)** simplificado (Entidade com lógica de negócio).
- **Dependency Injection** nativa do .NET.
