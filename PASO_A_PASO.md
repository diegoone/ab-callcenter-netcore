# Supervisor Agente

## Crear proyecto
- dotnet new mvc -o supervisor_agente --auth Individual

## eliminar sqlite
- dotnet remove package Microsoft.EntityFrameworkCore.Sqlite

## agregar EF Core, sql server y utilerías para scafold
- dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
- dotnet add package Microsoft.AspNetCore.Identity.UI
- dotnet add package Microsoft.EntityFrameworkCore.sqlserver
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
- dotnet add package Microsoft.VisualStudio.Web.CodeGenerators.Mvc

## gestión de migraciones
### agregar
- dotnet ef migrations add NOMBRE_MIGRACION
### quitar
- dotnet ef migrations add NOMBRE_MIGRACION

## hacer scaffold a un modelo
- dotnet aspnet-codegenerator controller -name ActividadController -m Actividad -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
- dotnet aspnet-codegenerator controller -name AsuntoController -m Asunto -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries