using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using supervisor_agente.Data;
namespace supervisor_agente
{
    public class SeedData
    {
        public List<UsuarioApp> listSupervisores {get; set;}
        public List<UsuarioApp> listAgentes {get; set;}
        public SeedData() {
            
            listSupervisores = new List<UsuarioApp>();
            listSupervisores.Add(new UsuarioApp {
                Email = "supervisor@abcallcenter.com"
            });
            
            listAgentes = new List<UsuarioApp>();
            
            listAgentes.Add(new UsuarioApp {
                Email = "agente1@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente2@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente3@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente4@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente5@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente6@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente7@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente8@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente9@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente10@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente11@abcallcenter.com"
            });
            listAgentes.Add(new UsuarioApp {
                Email = "agente12@abcallcenter.com"
            });
        }
    }
}
