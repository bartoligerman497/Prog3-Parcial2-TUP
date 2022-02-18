using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parcial_2_Programacion_3.Models;

namespace Parcial_2_Programacion_3.Controllers
{
    public class LocalController : Controller
    {
        // GET: Local
        private GestorBD gestor = new GestorBD();

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult AgregarInstrumento()
        {
            Instrumento i = new Instrumento();

            InstrumentoViewModel ivm = new InstrumentoViewModel();

            ivm.instrumento = i;
            ivm.tipos = gestor.ObtenerTipos();

            return View(ivm);
        }

        [HttpPost]
        public ActionResult AgregarInstrumento(InstrumentoViewModel ivm)
        {
            gestor.InsertarInstrumento(ivm.instrumento);

            List<InstrumentoConTipo> instrumentosConTipo = gestor.ObtenerInstrumentosConTipo();

            return View("ListarInstrumentos", "", instrumentosConTipo);
        }

        public ActionResult ListarInstrumentos()
        {
            List<InstrumentoConTipo> instrumentosConTipo = gestor.ObtenerInstrumentosConTipo();
            return View(instrumentosConTipo);
        }

        public ActionResult ListarInstrumentosPercusion()
        {
            List<InstrumentoConTipo> instrumentosConTipo = gestor.ObtenerInstrumentosConTipoPercusion();
            return View(instrumentosConTipo);
        }

        public ActionResult Eliminar1(int id)
        {
            gestor.EliminarInstrumento(id);

            List<InstrumentoConTipo> instrumentoConTipos = gestor.ObtenerInstrumentosConTipo();

            return View("ListarInstrumentos", "", instrumentoConTipos);
        }

        public ActionResult Eliminar2(int id)
        {
            gestor.EliminarInstrumento(id);

            List<InstrumentoConTipo> instrumentosConTipos = gestor.ObtenerInstrumentosConTipoPercusion();

            return View("ListarInstrumentosPercusion", "", instrumentosConTipos);
        }
    }
}