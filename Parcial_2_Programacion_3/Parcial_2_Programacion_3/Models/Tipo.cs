using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_2_Programacion_3.Models
{
    public class Tipo
    {
        public int idTipo { get; set; }
        public string Nombre { get; set; }

        public Tipo(int id, string nombre)
        {
            idTipo = id;
            Nombre = nombre;
        }
    }
}