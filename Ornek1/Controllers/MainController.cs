using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ornek1.Controllers
{
    public class MainController : ApiController
    {
        Dictionary<string, string> verilerim = new Dictionary<string, string>() {{"ali","veli"},{"ayse","fatma"},{"ahmet","mehmet"} 
        };
        
        //localhost:Portno/api/Main?ad=ayse
        //localhost:Portno/api/Main?ad=ahmet

        [HttpGet]
        public HttpResponseMessage Getir(string ad) 
        {
            string sonuc;
            verilerim.TryGetValue(ad, out sonuc);

            if (sonuc==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Aradığınız veri bulunamadı!");
            }


            return Request.CreateResponse(HttpStatusCode.OK, sonuc);
        }
    }
}
