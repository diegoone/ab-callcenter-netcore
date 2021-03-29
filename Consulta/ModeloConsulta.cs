using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace supervisor_agente.Consulta
{
    public class ModeloConsulta
    {
        public IList<ConsultaSemana> listaConsultaPorSemana {get; set;}
        public IList<AgenteConsulta> listaAgenteMasLlamadas {get; set;}
        public IList<AgenteConsulta> listaAgenteMenosLlamadas {get; set;}
    }
}