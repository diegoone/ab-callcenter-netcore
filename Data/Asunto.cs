using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace supervisor_agente.Data
{
    public class Asunto
    {
        //codigo generado para identificar cada actividad
        public int id {get; set;}
        //indica de que trato, motivo o apuntes durante la llamada
        public string motivo {get; set;}
        //indica si es duda, consulta, reclamo
        public string tipo {get; set;}
        //indica si se resolió o no
        public bool estaResuelto {get; set;}
        public ICollection<Actividad> actividades { get; set; }
    }
}