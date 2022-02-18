using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_2_Programacion_3.Models
{
    public class InstrumentoViewModel
    {
        public Instrumento instrumento { get; set; }
        public List<Tipo> tipos { get; set; }
    }
}