# User Management API

## Description
RESTful API for user management with JWT authentication and role-based authorization built with .NET 9.0 and Clean Architecture principles.

## Technologies
- .NET 9.0
- Entity Framework Core
- SQLite Database
- JWT Authentication
- Swagger/OpenAPI
- Clean Architecture
- BCrypt for Password Hashing

## Prerequisites
- .NET SDK 9.0 or later

## Installation

1. Clone the repository
```bash
git clone [your-repository-url]
cd UserManagementAPI
```

2. Build and run the project
```bash
dotnet build
cd UserManagementAPI.API
dotnet run
```

3. Access Swagger UI
Open your browser and navigate to:
```
https://localhost:5001/swagger
```

## Quick Start Guide

1. Register an admin user
```http
POST https://localhost:5001/api/auth/register
Content-Type: application/json

{
    "username": "admin",
    "email": "admin@example.com",
    "password": "Admin123!"
}
```

2. Login and get JWT token
```http
POST https://localhost:5001/api/auth/login
Content-Type: application/json

{
    "username": "admin",
    "password": "Admin123!"
}
```

3. Use the token in Swagger
- Click the "Authorize" button (lock icon)
- Enter the token in format: Bearer <your-token>
- Now you can access all endpoints

## API Endpoints

### Authentication
- POST /api/auth/register - Register new user
- POST /api/auth/login - Login and get JWT token

### Users
- GET /api/users - Get all users (Admin only)
- GET /api/users/{id} - Get user by ID
- PUT /api/users/{id} - Update user
- DELETE /api/users/{id} - Delete user (Admin only)

## Project Structure
- UserManagementAPI.API - Web API layer
- UserManagementAPI.Application - Application logic layer
- UserManagementAPI.Domain - Domain entities and interfaces
- UserManagementAPI.Infrastructure - Data access and external services
- UserManagementAPI.Tests - Unit tests

## Security
- JWT token-based authentication
- Role-based authorization
- Password hashing
- Input validation
- HTTPS enabled
