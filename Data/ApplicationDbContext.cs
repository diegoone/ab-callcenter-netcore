using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace supervisor_agente.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Asunto> Asuntos {get; set;}
        public virtual DbSet<UsuarioApp> UsuariosApp {get; set;}
        public virtual DbSet<Actividad>  Actividades {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actividad>().HasKey(a => new { a.asuntoId, a.correlativo });
            
        }
    }
}
