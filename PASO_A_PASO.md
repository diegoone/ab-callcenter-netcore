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