using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace supervisor_agente.Data
{
    public class Actividad
    {
        //fecha hora a la que se recibió la llamada
        public DateTime fecha {get; set;}

        public int correlativo {get; set;}
        //duracion en segundos
        public int duracion {get; set;}
        public int asuntoId {get; set;}
        public Asunto asunto {get; set;}
    }
}