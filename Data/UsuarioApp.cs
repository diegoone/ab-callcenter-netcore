using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace supervisor_agente.Data {
    public class UsuarioApp: IdentityUser {
        public ICollection<Actividad> actividades {get; set;}
    }
}