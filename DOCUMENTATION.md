# User Management API - Documentación Detallada

## Descripción General
Este proyecto es una API RESTful construida con .NET 9.0 que implementa un sistema de gestión de usuarios con autenticación y autorización. Utiliza una arquitectura limpia (Clean Architecture) para mantener el código organizado y fácil de mantener.

## Arquitectura del Proyecto

### 1. Capa de Dominio (UserManagementAPI.Domain)
Contiene las entidades principales y reglas de negocio core.

#### Entidades:
- **User.cs**: Define la entidad principal de usuario con propiedades como:
  - Id (Guid)
  - Username (string)
  - Email (string)
  - PasswordHash (string)
  - Role (string)
  - CreatedAt (DateTime)
  - LastLogin (DateTime?)
  - IsActive (bool)

### 2. Capa de Aplicación (UserManagementAPI.Application)
Contiene la lógica de aplicación y casos de uso.

#### DTOs:
- **UserRegistrationDto**: Para registrar nuevos usuarios
- **UserLoginDto**: Para autenticar usuarios
- **UserDto**: Para transferir información de usuarios
- **AuthResponseDto**: Para respuestas de autenticación

#### Servicios:
- **IAuthService**: Interface para servicios de autenticación
- **AuthService**: Implementación de la autenticación
  - Registro de usuarios
  - Login de usuarios
  - Generación de tokens JWT

### 3. Capa de Infraestructura (UserManagementAPI.Infrastructure)
Maneja la persistencia de datos y servicios externos.

#### Data:
- **ApplicationDbContext**: Contexto de Entity Framework Core
- **DatabaseSeeder**: Inicialización de datos

### 4. Capa de API (UserManagementAPI.API)
Expone los endpoints REST y maneja las solicitudes HTTP.

#### Controllers:
- **AuthController**: Maneja autenticación
  - POST /api/auth/register
  - POST /api/auth/login

- **UsersController**: Maneja operaciones CRUD de usuarios
  - GET /api/users (Admin only)
  - GET /api/users/{id}
  - PUT /api/users/{id}
  - DELETE /api/users/{id}

## Flujo de Autenticación

1. **Registro de Usuario**:
   ```http
   POST /api/auth/register
   {
     "username": "usuario",
     "email": "usuario@example.com",
     "password": "contraseña"
   }
   ```

2. **Login**:
   ```http
   POST /api/auth/login
   {
     "username": "usuario",
     "password": "contraseña"
   }
   ```

3. **Uso del Token**:
   ```http
   GET /api/users
   Authorization: Bearer <token>
   ```

## Seguridad

### JWT (JSON Web Tokens)
- Tokens con expiración de 24 horas
- Validación de firma usando una clave secreta
- Claims incluidos:
  - NameIdentifier (ID del usuario)
  - Name (Username)
  - Email
  - Role

### Roles y Permisos
- **Admin**: Acceso completo a todas las operaciones
- **User**: Acceso limitado a sus propios datos

### Contraseñas
- Almacenadas como hash usando BCrypt
- Nunca se almacenan en texto plano
- Validación segura en el login

## Base de Datos
- SQLite para desarrollo local
- Esquema de base de datos:
  - Users
    - Id (Primary Key)
    - Username (Unique)
    - Email (Unique)
    - PasswordHash
    - Role
    - CreatedAt
    - LastLogin
    - IsActive

## Pruebas
- Proyecto de pruebas unitarias incluido
- Pruebas de servicios de autenticación
- Pruebas de operaciones CRUD

## Documentación API
- Swagger UI disponible en `/swagger`
- Documentación interactiva de endpoints
- Esquemas de request/response
- Autorización integrada para pruebas

## Configuración
La configuración se maneja a través de appsettings.json:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=UserManagement.db"
  },
  "Jwt": {
    "Key": "your-super-secure-key-here-minimum-length-32-chars",
    "Issuer": "UserManagementAPI",
    "Audience": "UserManagementAPI",
    "ExpiryInHours": 24
  }
}
```
