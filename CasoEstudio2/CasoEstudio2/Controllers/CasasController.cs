using CasoEstudio2.Entity;
using CasoEstudio2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        CasasModel CasasModel = new CasasModel();

        [HttpGet]
        public ActionResult ConsultaCasas()
        {
            var datos = CasasModel.ConsultarCasas();
            return View(datos);
        }

        [HttpGet]
        public ActionResult AlquilerCasas()
        {
            var casasNoAlquiladas = CasasModel.ConsultarCasasNoAlquiladas();

            return View(casasNoAlquiladas);
        }


        [HttpPost]
        public ActionResult AlquilerCasas(CasasEntity entidad)
        {
            string respuesta = CasasModel.AlquilarCasa(entidad);

            if (respuesta == "OK")
            {
                return RedirectToAction("ConsultaCasas", "Casas");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha podido alquilar la casa";
                return View();
            }
        }
    }
}
