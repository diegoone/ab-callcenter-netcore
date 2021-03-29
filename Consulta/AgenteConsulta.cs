using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace supervisor_agente.Consulta
{
    public class AgenteConsulta
    {
        public string Id {get;set;}
        public int Total {get;set;}
        public string UserName {get;set;}
    }
}