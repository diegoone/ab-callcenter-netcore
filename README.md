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

## Usuarios y claves por defecto
### Supervisor
- supervisor@abcallcenter.com Supervis0r_
### Agentes
- agente1@abcallcenter.com Agent3_
- agente2@abcallcenter.com Agent3_
- agente3@abcallcenter.com Agent3_
- agente4@abcallcenter.com Agent3_
- agente5@abcallcenter.com Agent3_
- agente6@abcallcenter.com Agent3_
- agente7@abcallcenter.com Agent3_
- agente8@abcallcenter.com Agent3_
- agente9@abcallcenter.com Agent3_
- agente10@abcallcenter.com Agent3_
- agente11@abcallcenter.com Agent3_
- agente12@abcallcenter.com Agent3_
