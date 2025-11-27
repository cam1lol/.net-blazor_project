# 🎯 TaskManager – Aplicación Full-Stack

![TaskManager Logo](https://via.placeholder.com/250x60?text=TaskManager)

[![.NET](https://img.shields.io/badge/.NET-10-blue)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-orange)](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
[![SQLite](https://img.shields.io/badge/MySql-8.4.2-lightgrey)](https://www.sqlite.org/)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)

---

## 📌 Sobre el Proyecto

**TaskManager** es una aplicación web full-stack desarrollada con **Blazor WebAssembly** y **ASP.NET Core 10** que permite a los usuarios gestionar sus tareas de manera sencilla y eficiente.  

**Funcionalidades principales:**
- Crear, editar y eliminar tareas.  
- Filtrar tareas por estado: Pendiente, En progreso o Completada.  
- Administrar usuarios y asociarles sus tareas.  
- Interfaz moderna, interactiva y responsiva con **Bootstrap 5** y animaciones CSS.  

> Esta aplicación fue diseñada como un ejercicio práctico para demostrar buenas prácticas de desarrollo full-stack y modularidad.

---

## 🏗 Arquitectura del Proyecto

```text
TaskManager
│
├─ TaskManager.Client       ← Frontend Blazor WebAssembly
│  ├─ Pages                 ← Users, Tasks, Home
│  ├─ Components            ← UserCard, TaskCard
│  └─ Services              ← UserService, TaskService
│
├─ TaskManager.Shared       ← Modelos compartidos (User, TaskItem)
│
└─ TaskManager.Api          ← API RESTful
   ├─ Controllers           ← Endpoints Users & Tasks
   └─ Data                  ← DbContext y EF Core

🔗 Diagrama conceptual

flowchart LR
    A[Frontend: Blazor WebAssembly] <--HTTP/JSON--> B[Backend: ASP.NET Core API]
    B <--EF Core--> C[Base de datos MySql

🛠 Tecnologías Utilizadas

Área	Tecnología
Backend	ASP.NET Core 10, C#
Frontend	Blazor WebAssembly, Razor Components
Base de Datos	MySql
UI / UX	Bootstrap 5, Animaciones CSS
Servicios	Entity Framework Core
Control de Versiones	Git & GitHub

🚀 Guía de Instalación y Ejecución

1️⃣ Clonar el repositorio
git clone https://github.com/tuusuario/TaskManager.git
cd TaskManager

2️⃣ Configurar la base de datos

La API utiliza SQLite.

EF Core aplicará las migraciones automáticamente al ejecutar la API por primera vez, creando TaskManager.db en TaskManager.Api/Data.

3️⃣ Restaurar dependencias y compilar

API:

cd TaskManager.Api
dotnet restore
dotnet build
dotnet run


URLs por defecto:

https://localhost:5001

http://localhost:5000

Frontend:

cd TaskManager.Client
dotnet restore
dotnet build
dotnet run

⚙ Configuración de Puertos y Base de Datos
🔹 Configuración de Puertos

La API se ejecuta por defecto en:

https://localhost:5001 (HTTPS)

http://localhost:5000 (HTTP)

El frontend (Blazor WebAssembly) se sirve por defecto en:

http://localhost:5032

Estos valores se pueden modificar en Properties/launchSettings.json de cada proyecto si se necesita otro puerto.

🔹 Configuración de la Conexión a la Base de Datos

La API utiliza SQLite como base de datos ligera.

El archivo TaskManager.db se genera automáticamente en TaskManager.Api/Data la primera vez que ejecutas la API.

La conexión a SQLite está definida en TaskManager.Api/Data/AppDbContext.cs:

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
}


La cadena de conexión se encuentra en appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=Data/TaskManager.db"
  }
}


EF Core aplicará las migraciones automáticamente al ejecutar la API y creará la base de datos si no existe.

La aplicación Blazor WebAssembly se servirá en http://localhost:5032.

4️⃣ Conectar Frontend con API

En Program.cs del cliente:

builder.Services.AddScoped(sp => 
    new HttpClient { BaseAddress = new Uri("https://localhost:5001/") });

🔌 API Endpoints
Users
Método	Endpoint	Descripción
GET	/api/users	Obtener todos los usuarios
GET	/api/users/{id}	Obtener usuario por ID
POST	/api/users	Crear un usuario
PUT	/api/users/{id}	Actualizar un usuario
DELETE	/api/users/{id}	Eliminar un usuario
Tasks
Método	Endpoint	Descripción
GET	/api/tasks	Obtener todas las tareas
GET	/api/tasks/{id}	Obtener tarea por ID
POST	/api/tasks	Crear una tarea
PUT	/api/tasks/{id}	Actualizar una tarea
DELETE	/api/tasks/{id}	Eliminar una tarea

Puedes usar Postman, Swagger (/swagger) o Insomnia para probar los endpoints de forma interactiva.

🎨 Interfaz de Usuario

Cards animadas para mostrar Users y Tasks.

Formularios con validación de campos obligatorios.

Dashboard interactivo y responsivo.

Filtros y búsqueda dinámica de tareas.

📄 Decisiones Técnicas

Blazor WebAssembly para UI interactiva y modular.

Entity Framework Core para persistencia ligera y rápida.

Shared Models (TaskManager.Shared) para evitar duplicación de código.

Componentes reutilizables (UserCard, TaskCard) para mantener el proyecto modular y limpio.

Validación de datos y separación de responsabilidades siguiendo SRP.

-- Colecciones en Postman para probar Endpoinds --

Controlador Tareas
https://.postman.co/workspace/My-Workspace~38a4c6e3-8f8a-4aff-8e69-8779202ecd32/collection/36399364-b855c4d5-1ba4-462e-84fd-027fce018ea9?action=share&creator=36399364

Controlador Usuarios
https://.postman.co/workspace/My-Workspace~38a4c6e3-8f8a-4aff-8e69-8779202ecd32/collection/36399364-b855c4d5-1ba4-462e-84fd-027fce018ea9?action=share&creator=36399364

💡 Posibles Mejoras

Implementar autenticación y roles de usuario.

Dashboard con estadísticas y gráficos interactivos.

Filtros avanzados y búsqueda en tiempo real.

Despliegue a Azure, Docker o GitHub Pages.

📌 Contacto

Correo: kmilo0230@gmail.com

Portafolio: cv-cami.vercel.app
