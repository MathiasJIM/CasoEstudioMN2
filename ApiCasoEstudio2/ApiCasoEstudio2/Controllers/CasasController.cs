using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCasoEstudio2.Controllers
{
    public class CasasController : ApiController
    {

        [HttpGet]
        [Route("ConsultarCasas")]
        public List<CasasSistema> ConsultarCasas()
        {
            using (var context = new CasoEstudioMNEntities1())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var casasConsultadas = context.CasasSistema
                    .Where(c => c.PrecioCasa >= 115000 && c.PrecioCasa <= 180000)
                    .ToList();

                return casasConsultadas;

            }
        }


        [HttpGet]
        [Route("ConsultarCasasNoAlquiladas")]
        public List<CasasSistema> ConsultarCasasNoAlquiladas()
        {
            using (var context = new CasoEstudioMNEntities1())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var casasNoAlquiladas = context.CasasSistema
                    .Where(c => c.UsuarioAlquiler == null)
                    .ToList();

                return casasNoAlquiladas;
            }
        }



        [HttpPut]
        [Route("AlquilarCasa")]
        public string AlquilarCasa(CasasSistema tCasas)
        {
            using (var context = new CasoEstudioMNEntities1())
            {
                var datos = context.CasasSistema.Where(x => x.IdCasa == tCasas.IdCasa).FirstOrDefault();

                if (datos != null)
                {
                    datos.UsuarioAlquiler = tCasas.UsuarioAlquiler;
                    datos.FechaAlquiler = DateTime.Now; 
                    context.SaveChanges();
                    return "OK";
                }
                else
                {
                    return "Error: Casa no encontrada.";
                }
            }
        }

    }
}
