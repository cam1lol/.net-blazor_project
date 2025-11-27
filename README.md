# 🎯 TaskManager Full-Stack Application

![TaskManager Logo](https://via.placeholder.com/200x60?text=TaskManager)

[![.NET](https://img.shields.io/badge/.NET-10-blue)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-orange)](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
[![SQLite](https://img.shields.io/badge/SQLite-3.41.2-lightgrey)](https://www.sqlite.org/)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)

---

## 📌 Descripción del Proyecto
**TaskManager** es una aplicación web **full-stack** creada con **Blazor WebAssembly** y **ASP.NET Core 10**, enfocada en la gestión de tareas por usuario.  

- Crear, editar y eliminar tareas.  
- Filtrar tareas por estado: Pendiente, En progreso, Completada.  
- Administrar usuarios y sus tareas.  
- UI responsiva con **Bootstrap 5** y animaciones CSS en cards.

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
Diagrama conceptual interactivo:

flowchart LR
    A[Frontend: Blazor Client] <--HTTP/JSON--> B[Backend: ASP.NET Core API]
    B <--EF Core--> C[Base de datos SQLite]

🛠 Tecnologías Usadas
Área	Tecnología
Backend	ASP.NET Core 10, C#
Frontend	Blazor WebAssembly, Razor Components
Base de Datos	SQLite
UI/UX	Bootstrap 5, Animaciones CSS
Servicios	Entity Framework Core
Control de Versiones	Git & GitHub
🚀 Cómo clonar y ejecutar el proyecto
1️⃣ Clonar el repositorio
git clone https://github.com/tuusuario/TaskManager.git
cd TaskManager

2️⃣ Configurar la base de datos

La API utiliza SQLite. EF Core aplicará migraciones automáticamente al ejecutar la API por primera vez y creará TaskManager.db en TaskManager.Api/Data.

3️⃣ Restaurar dependencias y compilar

API:

cd TaskManager.Api
dotnet restore
dotnet build
dotnet run


URL por defecto: https://localhost:5001 / http://localhost:5000

Client:

cd TaskManager.Client
dotnet restore
dotnet build
dotnet run


La aplicación Blazor WebAssembly se servirá en http://localhost:5032.

4️⃣ Configurar la conexión del frontend con la API

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

Puedes usar Postman, Swagger (/swagger) o Insomnia para probar los endpoints.

🎨 Interfaz de Usuario

Cards animadas para Users y Tasks.

Formulario de creación y edición con validación.

Dashboard interactivo y responsivo.

Filtro de tareas por estado y búsqueda dinámica.

📄 Decisiones técnicas

Blazor WebAssembly para UI interactiva.

EF Core para persistencia ligera.

Modelos compartidos (TaskManager.Shared) para evitar duplicación de código.

Componentes reutilizables (UserCard, TaskCard) para mantener modularidad.

Validación de datos y separación de responsabilidades (SRP).

💡 Posibles mejoras

Autenticación y roles de usuario.

Dashboard con estadísticas y gráficos.

Filtros avanzados y búsqueda en tiempo real.

Deploy a Azure, Docker o GitHub Pages.

📌 Contacto

Correo: kmilo0230@gmail.com

Portafolio: https://cv-cami.vercel.app/
