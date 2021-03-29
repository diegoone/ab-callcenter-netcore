using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace supervisor_agente.Consulta
{
    public class ConsultaSemana
    {
        public int semana {get;set;}
        public int total {get;set;}
    }
}