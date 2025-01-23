# Backend API Documentation

## Project Overview

This **Backend API** is built with **.NET 9**, leveraging **Entity Framework Core** (EF Core) for data persistence and a **CQRS** (Command Query Responsibility Segregation) architecture. It provides a secure API with **JWT** authentication and utilizes **JOSE** for handling JSON Web Tokens. The project includes layers for persistence, domain, application logic, and web API. The application is designed with **PostgreSQL** as the database, and the entire system is containerized using **Docker** for easy deployment and scalability.

The backend follows a layered architecture:
- **Persistence Layer**: Handles data access and communication with PostgreSQL.
- **Domain Layer**: Contains business logic and domain entities.
- **Application Layer**: Implements CQRS, orchestrating commands and queries.
- **WebAPI Layer**: Exposes endpoints to the client and integrates JWT authentication.
- **Tests Layer**: Contains unit and integration tests for the API.

The backend is containerized using Docker, with the API running on port `5000`.

## Features

- **JWT Authentication**: Secure token-based authentication for accessing protected routes.
- **CQRS Architecture**: Separation of concerns with command and query handling.
- **Swagger**: API documentation and testing interface powered by Swagger.
- **Entity Framework Core**: ORM used for data access with PostgreSQL.
- **PostgreSQL Database**: The database used to persist data, hosted within a Docker container.
- **JOSE**: Used for securely generating and validating JWTs.
- **Dockerized**: The entire backend is containerized for consistent and scalable deployments.

## Technologies & Libraries Used

### Core Technologies

- **.NET 9**: The framework used for building the backend API.
- **Entity Framework Core**: ORM for interacting with the PostgreSQL database.
- **PostgreSQL**: Relational database used for persistence.
- **CQRS**: Architecture pattern used to separate commands (write) and queries (read).
- **JWT (JSON Web Tokens)**: For user authentication and secure access control.
- **JOSE**: A library for handling JWT creation and validation.
- **Swagger**: Tool for API documentation and testing endpoints interactively.
- **Docker**: Containerization tool to run the backend and database.

### Libraries and Frameworks

- **`Microsoft.EntityFrameworkCore`**: Core package for working with databases in .NET.
- **`Microsoft.AspNetCore.Authentication.JwtBearer`**: Used for JWT bearer token authentication.
- **`System.IdentityModel.Tokens.Jwt`**: Library used to generate and validate JWT tokens.
- **`Swashbuckle.AspNetCore`**: Provides Swagger integration for API documentation.
- **`Npgsql.EntityFrameworkCore.PostgreSQL`**: PostgreSQL provider for Entity Framework Core.
- **`MediatR`**: Library for implementing CQRS in the application layer, handling requests and responses.
- **`FluentValidation`**: Validation library for ensuring correct data models.
- **`Serilog`**: Logging library for structured logging and tracking application behavior.
- **`xUnit`**: Testing framework for unit and integration tests.
- **`NUnit`**: Alternative testing framework used for testing.
  
## Installation

### Prerequisites

- Docker
- .NET 9 SDK
- PostgreSQL (running in Docker)

### Steps

1
