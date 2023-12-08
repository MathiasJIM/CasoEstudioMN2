using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using CasoEstudio2.Entity;

namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public List<CasasEntity> ConsultarCasas()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarCasas";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<CasasEntity>>().Result;
            }
        }

        public List<CasasEntity> ConsultarCasasNoAlquiladas()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarCasasNoAlquiladas";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<CasasEntity>>().Result;
            }
        }


        public string AlquilarCasa(CasasEntity entidad)
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "AlquilarCasa";
                var jsonData = JsonContent.Create(entidad);
                var res = client.PutAsync(url, jsonData).Result;
                return res.Content.ReadFromJsonAsync<string>().Result;
            }
        }
    }
}