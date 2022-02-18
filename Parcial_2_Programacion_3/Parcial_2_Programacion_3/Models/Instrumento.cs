using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_2_Programacion_3.Models
{
    public class Instrumento
    {
        private int idArticulo;
        private string nombre;
        private string descripcion;
        private int stock;
        private double precio;
        private int idTipo;

        public int Id { get => idArticulo; set => idArticulo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public double Precio { get => precio; set => precio = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }

        public Instrumento()
        {
        }

        public Instrumento(int idArticulo, string nombre, string descripcion, int stock, double precio, int idTipo)
        {
            this.idArticulo = idArticulo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.stock = stock;
            this.precio = precio;
            this.idTipo = idTipo;
        }
    }
}