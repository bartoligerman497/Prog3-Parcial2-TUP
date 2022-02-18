using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_2_Programacion_3.Models
{
    public class InstrumentoConTipo
    {
        public int IdInstrumento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public string NombreTipo { get; set; }

        public InstrumentoConTipo(int idInstrumento, string nombre, string descripcion, int stock, double precio, string nombreTipo)
        {
            IdInstrumento = idInstrumento;
            Nombre = nombre;
            Descripcion = descripcion;
            Stock = stock;
            Precio = precio;
            NombreTipo = nombreTipo;
        }
    }
}